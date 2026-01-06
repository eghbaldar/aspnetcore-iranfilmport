using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services._AdminStuff.Queries.GetPanelNotification
{
    public class GetPanelNotificationServiceDto
    {
        public int UserProfileStatus { get; set; }
        public int UserHeadshotStatus { get; set; }
        public int UserMeliCardStatus { get; set; }
        public int UserProjects { get; set; }
        public int UserProjectPhotos { get; set; }
        public int SendInformation { get; set; }
        public int Contacts { get; set; }
    }
    public interface IGetPanelNotificationService
    {
        GetPanelNotificationServiceDto Execute();
    }
    public class GetPanelNotificationService : IGetPanelNotificationService
    {
        private readonly IDataBaseContext _context;
        public GetPanelNotificationService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetPanelNotificationServiceDto Execute()
        {
            return new GetPanelNotificationServiceDto()
            {
                UserHeadshotStatus = _context.Users.Count(x => x.HeadshotStatus == StatusConstants.UnderConsideration),
                UserProfileStatus = _context.Users.Count(x => x.MainStatus == StatusConstants.UnderConsideration),
                UserMeliCardStatus = _context.Users.Count(x => x.MeliCardStatus == StatusConstants.UnderConsideration),
                UserProjects = _context.UserProjects.Count(x => x.Status == StatusConstants.UnderConsideration),
                UserProjectPhotos = _context.UserProjectPhotos.Count(x => x.Status == StatusConstants.UnderConsideration),
                SendInformation = _context.SendInformation.Count(x => x.Status == StatusConstants.UnderConsideration),
                Contacts = _context.Contacts.Count(x => !x.Status),
            };
        }
    }
}
