using BankSystem.Common.Db;
using BankSystem.Common.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Atm.Repositories
{
    public interface IAccountRepository
    {
#nullable enable
        Task<AccountEntity?> GetAccountByCardIdAsync(Guid cardId);
        Task<AccountEntity?> GetAccountByIdAsync(Guid accountId);
        void UpdateAccount(AccountEntity account);
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly BankSystemDbContext _contex;

        public AccountRepository(
            BankSystemDbContext contex)
        {
            _contex = contex;
        }

        public async Task<AccountEntity?> GetAccountByCardIdAsync(Guid cardId)
        {
            return await _contex.Accounts
                .Include(a => a.UserEntity)
                .FirstOrDefaultAsync(a => a.Cards.Any(c => c.Id == cardId));
        }

        public async Task<AccountEntity?> GetAccountByIdAsync(Guid accountId)
        {
            return await _contex.Accounts
                .FirstOrDefaultAsync(a => a.Id == accountId);
        }

        public void UpdateAccount(AccountEntity account)
        {
            _contex.Update(account);
        }
    }
}
