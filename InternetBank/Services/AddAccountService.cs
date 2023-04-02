using BankSystem.Common.Db.Entities;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using BankSystem.InternetBank.Validations;

namespace BankSystem.InternetBank.Services;

public interface IAddAccountService
{ 
    Task<AccountEntity> AddAccountAsync(RegisterAccountRequest request,  string iban);
}
public class AddAccountService : IAddAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private readonly RegisterAccountValidator _registerAccountValidator;

    public AddAccountService(IAccountRepository accountRepository, 
        IUserRepository userRepository,
        RegisterAccountValidator registerAccountValidator)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _registerAccountValidator = registerAccountValidator;
    }
    public async Task<AccountEntity>AddAccountAsync(RegisterAccountRequest request,string iban)
    {
        _registerAccountValidator.Validate(request);
        var user = await _userRepository.FindUserByPersonalIdAsync(request.PersonalId);
        var account = new AccountEntity();
        account.Iban = iban;
        account.Amount = request.Amount;
        account.Currency = request.Currency;
        account.UserId = user.Id;
        await _accountRepository.RegisterAccountAsync(account);
        await _accountRepository.SaveChangesAsync();
        return account;
    }
}
