using IranFilmPort.Application.Interfaces.Context;

namespace IranFilmPort.Application.Services.Users.Queries.GetUserById
{
    public class GetUserByIdServiceDto
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public byte ProviderId { get; set; } // ProviderConstants.cs
        public Guid RoleId { get; set; } // RoleConstants.cs
        public DateTime InsertDateTime { get; set; }
        // MORE INFORMATION

        public string? Firstname_En { get; set; }
        public string? Lastname_En { get; set; }
        public string? Resume { get; set; }
        public string? Resume_En { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Phone_Visibility { get; set; }
        public bool? Email_Visibility { get; set; }
        public byte? Degree { get; set; } // DegreeContants.cs
        public byte Position { get; set; } // PositionContants.cs
        public string? DegreeField { get; set; }
        public string? Website { get; set; }
        public string? Twitter { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? IMDb { get; set; }

        public string? Headshot { get; set; }
        public byte? HeadshotStatus { get; set; } // StatusConstants.cs
        public string? HeadshotStatusMessage { get; set; }  // ادمین میتواند پیغامی برای کاربر بگذارد

        public string? MeliCard { get; set; }        
        public byte? MeliCardStatus { get; set; } // StatusConstants.cs
        public string? MeliCardStatusMessage { get; set; }  // ادمین میتواند پیغامی برای کاربر بگذارد

        public byte MainStatus { get; set; } // StatusConstants.cs
        public string? MainStatusMessage { get; set; }  // ادمین میتواند پیغامی برای کاربر بگذارد

    }
    public class RequestGetUserByIdServiceDto
    {
        public Guid? Id { get; set; }
    }
    public interface IGetUserByIdService
    {
        GetUserByIdServiceDto Execute(RequestGetUserByIdServiceDto req);
    }
    public class GetUserByIdService : IGetUserByIdService
    {
        private readonly IDataBaseContext _context;
        public GetUserByIdService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetUserByIdServiceDto? Execute(RequestGetUserByIdServiceDto req)
        {
            if (req == null || req.Id == Guid.Empty) return null;
            var result =
                _context.Users
                .Where(x => x.Id == req.Id)
                .Select(x => new GetUserByIdServiceDto
                {
                    Id = x.Id,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Email = x.Email,
                    Password = x.Password,
                    ProviderId = x.ProviderId,
                    InsertDateTime = x.InsertDateTime,
                    Username = x.Username,
                    Phone = x.Phone,
                    RoleId = x.RoleId,
                    Headshot = x.Headshot,
                    Birthday = x.Birthday,
                    Degree = x.Degree,
                    DegreeField = x.DegreeField,
                    Email_Visibility = x.Email_Visibility,
                    Facebook = x.Facebook,
                    Firstname_En = x.Firstname_En,
                    MeliCardStatus = x.MeliCardStatus,
                    IMDb = x.IMDb,
                    Instagram = x.Instagram,
                    Lastname_En = x.Lastname_En,
                    MeliCard = x.MeliCard,
                    Phone_Visibility = x.Phone_Visibility,
                    Resume = x.Resume,
                    Resume_En = x.Resume_En,
                    Twitter = x.Twitter,
                    Website = x.Website,
                    HeadshotStatus = x.HeadshotStatus,
                    Position = x.Position,
                    MainStatus = x.MainStatus,
                    MainStatusMessage = x.MainStatusMessage,
                    HeadshotStatusMessage = x.HeadshotStatusMessage,
                    MeliCardStatusMessage = x.MeliCardStatusMessage,
                })
                .FirstOrDefault();
            if (result == null) return null;
            return result;
        }
    }
}
