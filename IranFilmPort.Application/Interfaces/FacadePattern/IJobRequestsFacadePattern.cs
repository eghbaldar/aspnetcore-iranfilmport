using IranFilmPort.Application.Services.JobRequests.Commands.PostJobRequest;
using IranFilmPort.Application.Services.JobRequests.Commands.UpdateJobRequestStatusByAdmin;
using IranFilmPort.Application.Services.JobRequests.Queries.GetAllJobRequests;

namespace IranFilmPort.Application.Interfaces.FacadePattern
{
    public interface IJobRequestsFacadePattern
    {
        public GetAllJobRequestsService GetAllJobRequestsService { get; }
        public UpdateJobRequestStatusByAdminService UpdateJobRequestStatusByAdminService { get; }
        public PostJobRequestService PostJobRequestService { get;  }
    }
}
