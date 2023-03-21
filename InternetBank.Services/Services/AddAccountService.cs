using CommonServices.Db.Entities;
using CommonServices.Repositores;
using InternetBank.API.Requests;
using InternetBank.Models.Requests;

namespace InternetBank.Services;

public interface IAddAccountService
{ 
    Task AddAccountAsync(RegisterAccountRequest request,  string iban);
}
public class AddAccountService : IAddAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;

    public AddAccountService(IAccountRepository accountRepository, 
        IUserRepository userRepository)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
    }
    public async Task AddAccountAsync(RegisterAccountRequest request,string iban)
    {
        var user = await _userRepository.FindUserByPersonalIdAsync(request.PersonalId)
            ?? throw new Exception("Incorrect Personal Id");
        var account = new AccountEntity();
        account.Iban = iban;
        account.Amount = request.Amount;
        account.Currency = request.Currency;
        account.UserId = user.Id;
        await _accountRepository.RegisterAccountAsync(account);
        await _accountRepository.SaveChangesAsync();
    }


    
}