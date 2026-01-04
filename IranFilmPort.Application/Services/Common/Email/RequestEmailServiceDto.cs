namespace IranFilmPort.Application.Services.Common.Email
{
    public class RequestEmailServiceDto
    {
        public bool Group { get; set; } // {false}: individually send {true}: group-y send
        public Guid? UserId { get; set; } // اگه میخوایم برای کاربرای ثبت نام شده و دارای ایمیل ارسال بشه
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Text { get; set; }
        public string? Link { get; set; }
    }
}
