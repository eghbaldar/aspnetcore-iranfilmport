using Microsoft.AspNetCore.Http;

namespace IranFilmPort.Application.Services._Token
{
    public class CookieService
    {
        private readonly HttpContext _httpContext;
        public CookieService(HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        public string GenerateCookie(string cookieName, string value, DateTimeOffset exp)
        {
            _httpContext.Response.Cookies.Append(cookieName, value, new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // NOTE: change this value to TRUE for development environment!
                SameSite = SameSiteMode.Lax,
                //Expires = exp
                Expires = exp
            });
            return $"Cookie '{cookieName}' set with expiration: {exp}";
        }
    }
}
