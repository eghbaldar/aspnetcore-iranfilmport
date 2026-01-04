using IranFilmPort.Application.Interfaces.Context;
using IranFilmPort.Common.Constants;

namespace IranFilmPort.Application.Services.UserProjectPhotos.Queries.GetAllUserProjectPhotosForAdmin
{
    public class GetAllUserProjectPhotosForAdminServiceDto
    {
        public Guid PhotoId { get; set; }
        public Guid ProjectId { get; set; } // derived from UserProjects.cs
        public string ProjectTitleFa { get; set; }
        public string File { get; set; }
        public byte Type { get; set; } // UserProjectPhotoTypes.cs
        public byte Status { get; set; } // StatusConstants.cs
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllUserProjectPhotosForAdminServiceDto
    {
        public List<GetAllUserProjectPhotosForAdminServiceDto> Result { get; set; }
        public string ProjectTitleFa { get; set; }
    }
    public interface IGetAllUserProjectPhotosForAdminService
    {
        ResultGetAllUserProjectPhotosForAdminServiceDto Execute();
    }
    public class GetAllUserProjectPhotosForAdminService : IGetAllUserProjectPhotosForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetAllUserProjectPhotosForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllUserProjectPhotosForAdminServiceDto Execute()
        {
            var photos = _context.UserProjectPhotos
                .Where(x => x.Status == StatusConstants.UnderConsideration)
                .Select(x => new GetAllUserProjectPhotosForAdminServiceDto
                {
                    File = x.File,
                    InsertDateTime = x.InsertDateTime,
                    PhotoId = x.Id,
                    ProjectId = x.ProjectId,
                    Status = x.Status,
                    Type = x.Type,
                    ProjectTitleFa = _context.UserProjects.First(y => y.Id == x.ProjectId).TitleFa,
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            if (photos == null) return null;
            return new ResultGetAllUserProjectPhotosForAdminServiceDto
            {
                Result = photos,
            };
        }
    }
}
