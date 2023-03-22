using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Common.Repositores
{
    public interface IEmailRequestRepository
    {
        void RemoveEmailRequest(EmailRequestEntity emailRequestToRemove);
        Task<List<EmailRequestEntity>> GetAllEmailRequestsAsync();
        Task AddEmailRequestAsync(EmailMessage message);
    }

    public class EmailRequestRepository : IEmailRequestRepository
    {
        private readonly BankSystemDbContext _context;

        public EmailRequestRepository(BankSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmailRequestEntity>> GetAllEmailRequestsAsync()
        {
            return await _context.EmailRequests.ToListAsync();
        }

        public void RemoveEmailRequest(EmailRequestEntity emailRequestToRemove)
        {
            _context.Remove(emailRequestToRemove);
        }

        public async Task AddEmailRequestAsync(EmailMessage message)
        {
            var newEmailRequest = new EmailRequestEntity
            {
                Subject = message.Subject,
                Body = message.Body,
                ToAddress = message.Email
            };

            await _context.EmailRequests.AddAsync(newEmailRequest);

        }

    }

}