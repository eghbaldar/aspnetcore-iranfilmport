namespace IranFilmPort.Application.Services._Token
{
    public class UserTokenDto
    {
        public string UserId { get; set; }
        public string Role { get; set; }
        // NOTE: // this is the User's Token's Expiration DateTime
        // NOTE: // this value is different from Cookie's Expiration
        public string? Username { get; set; }
        public string Fullname { get; set; }
        public DateTime Exp { get; set; }
    }
}
