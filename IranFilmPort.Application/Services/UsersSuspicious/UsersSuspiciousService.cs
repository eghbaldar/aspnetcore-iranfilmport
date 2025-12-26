using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Services._Token;

namespace IranFilmPort.Application.Services.UsersSuspicious
{
    public class UsersSuspiciousService
    {
        private readonly IDataBaseContext _context;
        public UsersSuspiciousService(IDataBaseContext context)
        {
            _context = context;
        }
        public bool CheckForBan(string ip, string userAgent, Guid? userId, string requestPath, string methodName)
        {
            // Is Banned?
            var now = DateTime.UtcNow;
            var IsBanned = _context.UsersSuspicious
                .Any(s => s.IP == ip && (s.ExpireDate == null || s.ExpireDate > now));
            if (IsBanned) return true;

            // Find suspicious activities
            var recentAttempts = _context.UsersLogs
                .Where(log => log.IP == ip && log.RequestPath == requestPath && log.MethodName == methodName)
                .Where(log => log.InsertDateTime > DateTime.UtcNow.AddMinutes(-1))
                .Count();

            if (recentAttempts >= TokenStatics.AllowedUserTriesToAccess)
            {
                // Ban user
                var ban = new IranFilmPort.Domain.Entities.User.UsersSuspicious
                {
                    UserId = userId,
                    IP = ip,
                    UserAgent = userAgent,
                    BanDate = DateTime.UtcNow,
                    ExpireDate = DateTime.UtcNow.AddHours(TokenStatics.HourBannedUser),
                    Reason = (userId == Guid.Empty) ? "Too many [Unauthorized] attempts." : "Too many [Authorized] attempts.",
                };
                _context.UsersSuspicious.Add(ban);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
