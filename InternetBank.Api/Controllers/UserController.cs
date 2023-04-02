using System.Text.Json;
using System.Text.Json.Serialization;
using BankSystem.Common.Db.Entities;
using BankSystem.Common.Models;
using BankSystem.InternetBank.Api.Validations;
using BankSystem.InternetBank.Models.Dto;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using BankSystem.InternetBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace BankSystem.InternetBank.Api.Controllers;


[ApiController]
[Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly TransactionValidator _transactionValidator;
    private readonly UserManager<UserEntity> _userManager;
    private readonly ITransferService _transferService;
    private readonly IUserLoginService _userLoginService;
    private readonly ICardRepository _cardRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUserRepository _userRepository;


    public UserController(TransactionValidator transactionValidator,
        UserManager<UserEntity> userManager,
        ITransferService transferService,
        IUserLoginService userLoginService,
        ICardRepository cardRepository,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository,
        IUserRepository userRepository)
    {
        _transactionValidator = transactionValidator;
        _userManager = userManager;
        _transferService = transferService;
        _userLoginService = userLoginService;
        _cardRepository = cardRepository;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;
    }
    
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody]LoginRequest request)
    {
        var token = await _userLoginService.LoginUserAsync(request);
        var result = new HttpResult();
        result.Payload.Add("token", token);
        
        return Ok(result);
    }
    [HttpPost("transfer-money")]
    public async Task<IActionResult> TransferMoney(TranferRequest request)
    {
        var user = await _userManager.GetUserAsync(User);
        _transactionValidator.Validate(request, user);
        await _transferService.TransferMoneyAsync(request, user.Id);
        var result = new HttpResult();
        result.Payload.Add("Result", "Successful transaction");
        
        return Ok(result);
    }
    [HttpGet("get-cards")]
    public async Task<IActionResult> GetCards()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest("User Not Found");
        }

        var cards = await _cardRepository.GetCardsByUserIdAsync(user.Id);
        var result = new HttpResult();
        result.Payload.Add("cards",cards);
        return Ok(result);
    }
    
    [HttpGet("get-transactions")]
    public async Task<IActionResult> GetTransactions(string iban)
    {
        var transactions = await _transactionRepository.GetTransactionsAsync(iban);
        var result = new HttpResult();
        var transactionList = transactions
            .Select(t => new TransactionDto()
            {
                CreatedAt = t.CreatedAt,
                fee = t.Fee,
                SendFromIban = t.AccountFromIban,
                SendToIban = t.AccountToIban,
                RequestedAmount = t.ReceivedAmount,
                TransactionType = t.TransactionType

            });
        result.Payload.Add("transactions",transactions);
        return Ok(result);
    }
    [HttpGet("get-accounts")]
    public async Task<IActionResult> GetAccounts()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest("User Not Found");
        }
        var accounts = await _userRepository.GetUserAccountsAsync(user);
        var result = new HttpResult();
        var accountList = accounts
            .Select(a =>
                new AccountDto()
                {
                    Amount = a.Amount,
                    Currency = a.Currency,
                    Iban = a.Iban
                })
            .ToList();
        result.Payload.Add("accounts",accountList);

        return Ok(result);
    }
   
}
