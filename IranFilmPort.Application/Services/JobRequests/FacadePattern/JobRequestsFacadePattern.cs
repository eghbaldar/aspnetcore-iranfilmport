using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Application.Interfaces.FacadePattern;
using IranFilmPort.Application.Services.JobRequests.Commands.PostJobRequest;
using IranFilmPort.Application.Services.JobRequests.Commands.UpdateJobRequestStatusByAdmin;
using IranFilmPort.Application.Services.JobRequests.Queries.GetAllJobRequests;

namespace IranFilmPort.Application.Services.JobRequests.FacadePattern
{
    public class JobRequestsFacadePattern: IJobRequestsFacadePattern
    {
        private readonly IDataBaseContext _context;
        public JobRequestsFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }
        // GetAllJobRequestsService
        public GetAllJobRequestsService _getAllJobRequestsService;
        public GetAllJobRequestsService GetAllJobRequestsService
        {
            get { return _getAllJobRequestsService = _getAllJobRequestsService ?? new GetAllJobRequestsService(_context); }
        }
        // UpdateJobRequestStatusByAdminService
        public UpdateJobRequestStatusByAdminService _updateJobRequestStatusByAdminService;
        public UpdateJobRequestStatusByAdminService UpdateJobRequestStatusByAdminService
        {
            get { return _updateJobRequestStatusByAdminService = _updateJobRequestStatusByAdminService ?? new UpdateJobRequestStatusByAdminService(_context); }
        }
        // PostJobRequestService
        public PostJobRequestService _postJobRequestService;
        public PostJobRequestService PostJobRequestService
        {
            get { return _postJobRequestService = _postJobRequestService ?? new PostJobRequestService(_context); }
        }
    }
}
