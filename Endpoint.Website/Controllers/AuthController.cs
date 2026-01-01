using Endpoint.Website.Utilities.Claim;
using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services._Token;
using IranFilmPort.Application.Services._Turnstile;
using IranFilmPort.Application.Services.UserRefreshToken;
using IranFilmPort.Application.Services.Users.Queries.CheckUsernamePassword;
using IranFilmPort.Common.Constants;
using IranFilmPort.Infranstructure.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Role = IranFilmPort.Common.Enums.KingAttributeEnum.UserRole;

namespace Endpoint.Website.Controllers
{
    public class AuthController : Controller
    {
        private readonly IDataBaseContext _context;
        private readonly IUsersFacadePattern _usersFacadePattern;
        private readonly ITurnstileService _turnstileService;

        public AuthController(
            IUsersFacadePattern usersFacadePattern,
            IDataBaseContext context,
            ITurnstileService turnstileService)
        {
            _usersFacadePattern = usersFacadePattern;
            _context = context;
            _turnstileService = turnstileService;
        }

        [KingCheckUserAttribute(Role.King, Role.SuperAdmin, Role.Admin, Role.Client, Role.User)]
        public IActionResult index()
        
        {
            if (User.Identity.IsAuthenticated)
            {
                var roles = ClaimUtility.GetUserRole(User as ClaimsPrincipal);
                if (roles.Contains(RoleConstants.King) || 
                    roles.Contains(RoleConstants.SuperAdmin) ||
                    roles.Contains(RoleConstants.Admin))
                {
                    return Redirect("/admin/");
                }
                else if (roles.Contains(RoleConstants.User))
                {
                    return Redirect("/user/");
                }
                else if (roles.Contains(RoleConstants.Client))
                {
                    return Redirect("/client/");
                }
                else
                {
                    return RedirectToAction(TokenStatics.DestinationActionAfterLogout, TokenStatics.DestinationControllerAfterLogout);
                }
            }
            else
                return View();
        }
        protected void Clearup()
        {
            // 1. Remove the auth & refresh cookie
            Response.Cookies.Delete(TokenStatics.AuthCookieName);
            Response.Cookies.Delete(TokenStatics.RefreshCookieName);

            // 2. Clear claims identity (optional)
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());
        }
        public async Task<IActionResult> GetLogin(RequestCheckUsernamePasswordServiceDto req)
        {
            // Add more comprehensive validation
            if (req == null || string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
            {
                return Json(new { IsSuccess = false, Message = "نام کاربری و رمز عبور الزامی است." });
            }

            // Add try-catch for error handling
            string _role = "";
            try
            {
                // captcha
                if (!await _turnstileService.VerifyAsync(req.TurnstileToken))
                    return Json(new { IsSuccess = false, Message = "هویت شما ربات تشخیص داده شده است، لطفا دوباره و یا در زمان دیگری اقدام کنید." });
                // remove cookies & sessions
                Clearup();
                // the rest of process ...
                var login = await _usersFacadePattern.CheckUsernamePasswordService.Execute(req);
                // ... rest of the code
                if (login.IsSuccess)
                {
                    ///////////////////////////////////////////////////////////////
                    ///                      RefreshToken
                    ///////////////////////////////////////////////////////////////


                    // generate the refresh cookie
                    CookieService cookieService = new CookieService(HttpContext);
                    var exp = DateTimeOffset.UtcNow.AddDays(TokenStatics.ExpirationDayRefreshCookie); // TODO: change AddMinutes to AddDays
                    var refreshToken = Guid.NewGuid();
                    cookieService.GenerateCookie(TokenStatics.RefreshCookieName, EncryptionHelper.EncryptGuidWithPublicKey(refreshToken, TokenStatics.RefreshTokenKey), exp);

                    // post into userRefreshToken Entity

                    UserRefreshTokenService refreshTokenService = new UserRefreshTokenService(_context);
                    refreshTokenService.PostUserRefreshToken(new RequestUserRefreshTokenServiceDto
                    {
                        UserId = login.Data.UserId,
                        IP = HttpContext.Connection.RemoteIpAddress?.ToString(),
                        UserAgent = req.UserAgent,
                        Exp = exp.UtcDateTime, // Convert DateTimeOffset to DateTime (UTC time)
                        Token = refreshToken.ToString(),
                    });

                    ///////////////////////////////////////////////////////////////
                    ///                      AccessToken
                    ///////////////////////////////////////////////////////////////


                    exp = DateTimeOffset.UtcNow.AddDays(TokenStatics.ExpirationDayAuthCookie);// TODO: change [AddMinutes] to [AddDays]
                                                                                              // generate token
                    TokenAccessService tokenService = new TokenAccessService();
                    UserTokenDto userTokenDto = new UserTokenDto()
                    {
                        Fullname = login.Data.Fullname,
                        Username = login.Data.Username,
                        UserId = login.Data.UserId.ToString(),
                        Role = login.Data.Role,
                        Exp = exp.UtcDateTime, // Convert DateTimeOffset to DateTime (UTC time)
                    };
                    string token = tokenService.GenerateToken(userTokenDto, TokenStatics.AccessTokenKey);
                    // generate cookie
                    var checkCookie = cookieService.GenerateCookie(TokenStatics.AuthCookieName, token, exp);
                    _role = login.Data.Role;
                }
                else
                {
                    return Json(new { IsSuccess = false, Message = login.Message });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return Json(new { IsSuccess = false, Message = "خطایی در سامانه رخ داده است. لطفا مجددا تلاش کنید." });
            }

            string _reutrnedUrl = "";
            switch (_role)
            {
                case RoleConstants.King:
                case RoleConstants.SuperAdmin:
                case RoleConstants.Admin:
                    _reutrnedUrl = "/admin/";
                    break;
                case RoleConstants.Client:
                    _reutrnedUrl = "/client/";
                    break;
                case RoleConstants.User:                
                    _reutrnedUrl = "/user/";
                    break;
            }
            return Json(new { IsSuccess = true , ReutrnedUrl = _reutrnedUrl });
        }
        public IActionResult Logout()
        {
            // remove cookies & sessions
            Clearup();
            // Redirect to login/home page
            return RedirectToAction(TokenStatics.DestinationActionAfterLogout, TokenStatics.DestinationControllerAfterLogout);
        }
    }
}
