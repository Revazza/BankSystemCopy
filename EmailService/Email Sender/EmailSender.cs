using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using BankSystem.Common.Extensions;

namespace EmailService.Email_Sender
{
    public class EmailSender
    {
        private readonly BankSystemDbContext _context;
        private readonly string _companyEmail;

        public EmailSender(
            DbContextOptions<BankSystemDbContext> options,
            string companyEmail)
        {
            _context = new BankSystemDbContext(options);
            _companyEmail = companyEmail;
        }

        private string GetHTMLTemplate(string parentFolderName, string subFolderName, string fileName)
        {
            var folderPath = FileExtensions.GetParentFolderPath(parentFolderName);
            var htmlContentPath = FileExtensions.GetSubFolderFilePath(folderPath, subFolderName, fileName);
            var htmlBody = File.ReadAllText(htmlContentPath);
            return htmlBody;
        }

        private string GenerateHTMLTableData(string messageBody)
        {
            var splittedBody = messageBody.Split("/").ToList();
            var template = GetHTMLTemplate("EmailService","HtmlTemplate","tableDataTemplate.html");

            var attributes = new List<string>();
            foreach (var info in splittedBody)
            {
                var splitted = info.Split(':');

                var str = template
                    .Replace("KEY", splitted.First())
                    .Replace("VALUE", splitted.Last());

                attributes.Add(str);
            }
            return string.Join("", attributes);

        }

        private string CreateHTMLContent(EmailRequestEntity request)
        {
            var htmlTableData = GenerateHTMLTableData(request.Body!);

            var htmlBody = GetHTMLTemplate("EmailService","HtmlTemplate","template.html");
            htmlBody = htmlBody
                .Replace("CHANGE HERE", htmlTableData)
                .Replace("MyOwnSubject", request.Subject);

            return htmlBody;
        }

        private MailMessage CreateEmailMessage(
            EmailRequestEntity request,
            string htmlBody)
        {
            var to = new MailAddress(request.ToAddress!);
            var from = new MailAddress(_companyEmail);

            var message = new MailMessage(from, to)
            {
                Subject = request.Subject,
                Body = htmlBody,
                IsBodyHtml = true,
            };
            message.Headers.Add("Content-Type", "text/html");
            
            return message;

        }

        public void SendEmail(EmailRequestEntity request)
        {
            var htmlBody = CreateHTMLContent(request);
            var message = CreateEmailMessage(request,htmlBody);

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(_companyEmail, "mpgxkmdghrdddzxz"),
                EnableSsl = true,
            };

            try
            {
                client.Send(message);
                Console.WriteLine($"Email sent to {request.ToAddress}");
                _context.EmailRequests.Remove(request);
            }
            catch (SmtpException e)
            {
                request.Status = EmailRequestStatus.Failed;
                _context.EmailRequests.Update(request);
                Console.WriteLine(e.Message);
            }

        }

        public async Task<List<EmailRequestEntity>> GetAllEmailRequestsAsync()
        {
            return await _context.EmailRequests
                .Where(e => e.Status == EmailRequestStatus.NotSent)
                .ToListAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
