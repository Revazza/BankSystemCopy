using BankSystem.Common.Extensions;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace EmailService
{
    public class AppSettings
    {
        public string DatabaseConnectionString { get; set; }
        public string CompanyEmail { get; set; }

        public AppSettings()
        {
            var baseFolderPath = FileExtensions.GetParentFolderPath("BankSystem");
            var configuration = GetConfiguration(baseFolderPath);

            CompanyEmail = configuration["CompanyEmail"];
            DatabaseConnectionString = configuration.GetConnectionString("DefaultConnection");

        }

        private IConfigurationRoot GetConfiguration(string baseFolderPath)
        {
            var os = Environment.OSVersion.Platform.ToString().ToLower();

            return new ConfigurationBuilder()
                .SetBasePath(baseFolderPath)
                .AddJsonFile($"SharedSettings.{os}.json", optional: true)
                .Build();
        }

    }
}
