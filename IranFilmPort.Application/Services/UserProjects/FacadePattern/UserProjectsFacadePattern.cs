using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.UserProjects.Commands.PostUserProject;
using IranFilmPort.Application.Services.UserProjects.Commands.UpdateUserProject;
using IranFilmPort.Application.Services.UserProjects.Commands.UpdateUserProjectStatus;
using IranFilmPort.Application.Services.UserProjects.Queries.GetAllProjectsByUserId;
using IranFilmPort.Application.Services.UserProjects.Queries.GetAllUserProjectsForAdmin;
using IranFilmPort.Application.Services.UserProjects.Queries.GetAllUserProjectsForSitemap;
using IranFilmPort.Application.Services.UserProjects.Queries.GetUserProjectByIdForAdmin;
using IranFilmPort.Application.Services.UserProjects.Queries.GetUserProjectForUser;

namespace IranFilmPort.Application.Services.UserProjects.FacadePattern
{
    public class UserProjectsFacadePattern : IUserProjectsFacadePattern
    {
        private readonly IDataBaseContext _context;
        private readonly IServiceProvider _serviceProvider;
        public UserProjectsFacadePattern(IDataBaseContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        // DeleteNewsService
        public PostUserProjectService _postUserProjectService;
        public PostUserProjectService PostUserProjectService
        {
            get { return _postUserProjectService = _postUserProjectService ?? new PostUserProjectService(_context, _serviceProvider); }
        }
        // DeleteNewsService
        public UpdateUserProjectService _updateUserProjectService;
        public UpdateUserProjectService UpdateUserProjectService
        {
            get { return _updateUserProjectService = _updateUserProjectService ?? new UpdateUserProjectService(_context, _serviceProvider); }
        }
        // GetAllUserProjectsForSitemapService
        public GetAllUserProjectsForSitemapService _getAllUserProjectsForSitemapService;
        public GetAllUserProjectsForSitemapService GetAllUserProjectsForSitemapService
        {
            get { return _getAllUserProjectsForSitemapService = _getAllUserProjectsForSitemapService ?? new GetAllUserProjectsForSitemapService(_context); }
        }
        // GetGetAllUserProjectsForAdminService
        public GetGetAllUserProjectsForAdminService _getGetAllUserProjectsForAdminService;
        public GetGetAllUserProjectsForAdminService GetGetAllUserProjectsForAdminService
        {
            get { return _getGetAllUserProjectsForAdminService = _getGetAllUserProjectsForAdminService ?? new GetGetAllUserProjectsForAdminService(_context); }
        }
        // GetUserProjectByIdForAdmin
        public GetUserProjectByIdForAdmin _getUserProjectByIdForAdmin;
        public GetUserProjectByIdForAdmin GetUserProjectByIdForAdmin
        {
            get { return _getUserProjectByIdForAdmin = _getUserProjectByIdForAdmin ?? new GetUserProjectByIdForAdmin(_context); }
        }
        // GetAllProjectsByUserIdService
        public GetAllProjectsByUserIdService _getAllProjectsByUserIdService;
        public GetAllProjectsByUserIdService GetAllProjectsByUserIdService
        {
            get { return _getAllProjectsByUserIdService = _getAllProjectsByUserIdService ?? new GetAllProjectsByUserIdService(_context); }
        }
        // GetUserProjectForUserService
        public GetUserProjectForUserService _getUserProjectForUserService;
        public GetUserProjectForUserService GetUserProjectForUserService
        {
            get { return _getUserProjectForUserService = _getUserProjectForUserService ?? new GetUserProjectForUserService(_context); }
        }
        // UpdateUserProjectStatusService
        public UpdateUserProjectStatusService _updateUserProjectStatusService;
        public UpdateUserProjectStatusService UpdateUserProjectStatusService
        {
            get { return _updateUserProjectStatusService = _updateUserProjectStatusService ?? new UpdateUserProjectStatusService(_context); }
        }
    }
}
