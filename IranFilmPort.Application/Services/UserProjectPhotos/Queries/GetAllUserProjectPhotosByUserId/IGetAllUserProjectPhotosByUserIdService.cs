using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.UserProjectPhotos.Queries.GetAllUserProjectPhotosByUserId
{
    public class RequestGetAllUserProjectPhotosByUserIdServiceDto
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
    }
    public class GetAllUserProjectPhotosByUserIdServiceDto
    {
        public Guid PhotoId { get; set; }
        public string File { get; set; }
        public byte Type { get; set; } // UserProjectPhotoTypes.cs
        public byte Status { get; set; } // StatusConstants.cs
        public DateTime InsertDateTime { get; set; }
    }
    public class ResultGetAllUserProjectPhotosByUserIdServiceDto
    {
        public List<GetAllUserProjectPhotosByUserIdServiceDto> Result { get; set; }
        public string ProjectTitleFa { get; set; }
        public byte ProjectType { get; set; }
        public Guid ProjectId { get; set; } // derived from UserProjects.cs
    }
    public interface IGetAllUserProjectPhotosByUserIdService
    {
        ResultGetAllUserProjectPhotosByUserIdServiceDto Execute(RequestGetAllUserProjectPhotosByUserIdServiceDto req);
    }
    public class GetAllUserProjectPhotosByUserIdService : IGetAllUserProjectPhotosByUserIdService
    {
        private readonly IDataBaseContext _context;
        public GetAllUserProjectPhotosByUserIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetAllUserProjectPhotosByUserIdServiceDto Execute(RequestGetAllUserProjectPhotosByUserIdServiceDto req)
        {
            if (req == null || req.UserId == Guid.Empty || req.ProjectId == Guid.Empty) return null;
            var project = _context.UserProjects
            .FirstOrDefault(x => x.UserId == req.UserId && x.Id == req.ProjectId);

            if (project == null) return null;

            var photos = _context.UserProjectPhotos
                .Where(x => x.ProjectId == req.ProjectId)
                .Select(x => new GetAllUserProjectPhotosByUserIdServiceDto
                {
                    File = x.File,
                    InsertDateTime = x.InsertDateTime,
                    PhotoId = x.Id,
                    Status = x.Status,
                    Type = x.Type
                })
                .OrderByDescending(x => x.InsertDateTime)
                .ToList();
            if (photos == null) return null;
            return new ResultGetAllUserProjectPhotosByUserIdServiceDto
            {
                Result = photos,
                ProjectTitleFa = project.TitleFa,
                ProjectType = project.Type,
                ProjectId = project.Id,
            };
        }
    }
}
