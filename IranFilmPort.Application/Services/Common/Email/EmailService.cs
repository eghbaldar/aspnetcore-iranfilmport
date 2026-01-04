using IranFilmPort.Application.Common;
using IranFilmPort.Application.Interfaces.Context;
using System.Net;
using System.Net.Mail;

namespace IranFilmPort.Application.Services.Common.Email
{
    public class EmailService : IEmailService
    {
        private readonly string smtpServer = "mail.kingeto.ir";
        private readonly int smtpPort = 587;
        private readonly string fromEmail = "noreply@kingeto.ir";
        private readonly string username = "noreply@kingeto.ir";
        private readonly string password = "Ir#43u3s";

        private readonly IDataBaseContext _context;
        public EmailService(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(RequestEmailServiceDto req)
        {
            if (!req.Group)
            {
                string? To;
                if (req.UserId == null || req.UserId == Guid.Empty) To = req.To;
                else To = GetUserEmail((Guid)req.UserId);

                if (!string.IsNullOrEmpty(To))
                {
                    // Email body
                    string SUBJECT = req.Subject;
                    string linkDisplay = string.IsNullOrEmpty(req.Link?.Trim()) ? "display:none;" : req.Link;
                    try
                    {
                        await SendEmailAsync(To, SUBJECT, req.Text, linkDisplay);
                        return new ResultDto { IsSuccess = true };
                    }
                    catch (FormatException ex) { return new ResultDto { IsSuccess = false }; }
                }
                else return new ResultDto { IsSuccess = false };
            }
            else
            {
                // Handle group emails
                var allUsers = _context.Users.Select(x => x.Email).ToList();
                var allNewsletterMembers = _context.Newsletters.Select(x => x.Email).ToList();
                var mergedEmails = allUsers.Union(allNewsletterMembers).Distinct().ToList();

                foreach (var user in mergedEmails)
                {
                    string SUBJECT = req.Subject;
                    if (!string.IsNullOrEmpty(user))
                    {
                        // Set link display property if link is empty or null
                        string linkDisplay = string.IsNullOrEmpty(req.Link?.Trim()) ? "display:none;" : req.Link;
                        try
                        {
                            await SendEmailAsync(user, SUBJECT, req.Text, linkDisplay);
                            System.Threading.Thread.Sleep(1000);
                        }
                        catch (FormatException ex) { }
                    }
                }
                return new ResultDto { IsSuccess = true };
            }
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content, string link)
        {
            // Get the template path
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserTemplate", "assets", "html-templates", "email.html");
            // Check if the template file exists
            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException("Email template not found.", templatePath);
            }

            // Read the email template
            var body = await File.ReadAllTextAsync(templatePath);

            // Prepare the email message
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail, "کینگتو"),
                Subject = subject,
                Body = string.IsNullOrEmpty(content) ? "خطایی رُخ داده داست" : string.Format(body, content, link, (link == "display:none;") ? "display:none;" : string.Empty),
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.EnableSsl = false; // Adjust according to your SMTP server's requirements

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                }
                catch (SmtpException smtpEx)
                {
                    // Handle SMTP-specific exceptions
                    throw new Exception("Error sending email: " + smtpEx.Message);
                }
                catch (Exception ex)
                {
                    // Handle any other exceptions
                    throw new Exception("An error occurred while sending email: " + ex.Message);
                }
            }
        }
        private string? GetUserEmail(Guid userId)
        {
            return _context.Users.Where(x => x.Id == userId).FirstOrDefault()?.Email;
        }
    }
}
