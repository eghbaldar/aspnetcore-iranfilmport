using IranFilmPort.Application.Services.UserProjects.Commands.PostUserProject;
using IranFilmPort.Application.Services.UserProjects.Commands.UpdateUserProject;
using IranFilmPort.Application.Services.UserProjects.Commands.UpdateUserProjectStatus;
using IranFilmPort.Application.Services.UserProjects.Queries.GetAllProjectsByUserId;
using IranFilmPort.Application.Services.UserProjects.Queries.GetAllUserProjectsForAdmin;
using IranFilmPort.Application.Services.UserProjects.Queries.GetAllUserProjectsForSitemap;
using IranFilmPort.Application.Services.UserProjects.Queries.GetUserProjectByIdForAdmin;
using IranFilmPort.Application.Services.UserProjects.Queries.GetUserProjectForUser;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IUserProjectsFacadePattern
    {
        public PostUserProjectService PostUserProjectService { get; }
        public UpdateUserProjectService UpdateUserProjectService { get; }
        public GetAllUserProjectsForSitemapService GetAllUserProjectsForSitemapService { get; }
        public GetGetAllUserProjectsForAdminService GetGetAllUserProjectsForAdminService { get; }
        public GetUserProjectByIdForAdmin GetUserProjectByIdForAdmin { get; }
        public GetAllProjectsByUserIdService GetAllProjectsByUserIdService { get; }
        public GetUserProjectForUserService GetUserProjectForUserService { get; }
        public UpdateUserProjectStatusService UpdateUserProjectStatusService { get; }
    }
}
