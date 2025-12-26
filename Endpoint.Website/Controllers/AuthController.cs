using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services._Token;
using IranFilmPort.Application.Services.UserRefreshToken;
using IranFilmPort.Application.Services.Users.Queries.CheckUsernamePassword;
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
        public AuthController(IUsersFacadePattern usersFacadePattern,
            IDataBaseContext context)
        {
            _usersFacadePattern = usersFacadePattern;
            _context = context;
        }

        [KingCheckUserAttribute(Role.King, Role.SuperAdmin, Role.Admin, Role.Client, Role.User)]
        public IActionResult index()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect("/user/");
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
        public IActionResult GetLogin(RequestCheckUsernamePasswordServiceDto req)
        {
            // remove cookies & sessions
            Clearup();
            // the rest of process ...
            var login = _usersFacadePattern.CheckUsernamePasswordService.Execute(req);
            if (login != null)
            {
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
                }
            }
            return Json(login);
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
