using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.UsersLogs.Commands.PostUserLog
{
    public class RequestUserLogsServiceDto
    {
        public Guid? UserId { get; set; }
        public string RequestPath { get; set; }
        public string Method { get; set; }
        public string IP { get; set; }
        public string MethodName { get; set; }
        public string UserAgent { get; set; }
        public bool Auth { get; set; }
    }
    public class UserLogsService
    {
        private readonly IDataBaseContext _context;
        public UserLogsService(IDataBaseContext context)
        {
            _context = context;
        }
        public void PostUserLog(RequestUserLogsServiceDto req)
        {
            IranFilmPort.Domain.Entities.User.UsersLogs userLogs = new IranFilmPort.Domain.Entities.User.UsersLogs()
            {
                IP = req.IP,
                Method = req.Method,
                UserAgent = req.UserAgent,
                RequestPath = req.RequestPath,
                Auth = req.Auth,
                MethodName = req.MethodName,
                UserId = req.UserId,
            };
            _context.UsersLogs.Add(userLogs);
            _context.SaveChanges();
        }
    }
}
