using BankSystem.Common.Db;
using EmailService;
using EmailService.Email_Sender;
using Microsoft.EntityFrameworkCore;

var appSettings = new AppSettings();
var optionsBuilder = new DbContextOptionsBuilder<BankSystemDbContext>();
optionsBuilder.UseSqlServer(appSettings.DatabaseConnectionString);

var emailSender = new EmailSender(optionsBuilder.Options, appSettings.CompanyEmail!);


while (true)
{
    var emailRequests = await emailSender.GetAllEmailRequestsAsync();
    if (!emailRequests.Any())
    {
        Console.WriteLine("No emails to sent");
    }
    else
    {
        foreach (var request in emailRequests)
        {
            emailSender.SendEmail(request);
        }

        emailSender.SaveChanges();
    }

    await Task.Delay(10000);
}







