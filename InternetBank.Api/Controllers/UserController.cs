using BankSystem.Common.Db.Entities;
using BankSystem.InternetBank.Api.Validations;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Repositories;
using BankSystem.InternetBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.InternetBank.Api.Controllers;


[ApiController]
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


    public UserController(TransactionValidator transactionValidator,
        UserManager<UserEntity> userManager,
        ITransferService transferService,
        IUserLoginService userLoginService,
        ICardRepository cardRepository,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository)
    {
        _transactionValidator = transactionValidator;
        _userManager = userManager;
        _transferService = transferService;
        _userLoginService = userLoginService;
        _cardRepository = cardRepository;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody]LoginRequest request)
    {
        var token = await _userLoginService.LoginUserAsync(request);
        return Ok(token);
    }
    [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
    [HttpPost("transfer-money")]
    public async Task<IActionResult> TransferMoney(TranferRequest request)
    {
        var user = await _userManager.GetUserAsync(User);
        _transactionValidator.Validate(request, user);
        await _transferService.TransferMoneyAsync(request, user.Id);
        return Ok("successful transaction");
    }
    [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
    [HttpGet("get-cards")]
    public async Task<IActionResult> GetCards()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest("User Not Found");
        }

        var cards = await _cardRepository.GetCardsByUserIdAsync(user.Id);
        return Ok(cards);
    }
    [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
    [HttpPost("get-amount-of-account")]
    public async Task<IActionResult> GetAmount(string iban)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest("User Not Found");
        }
        var amount = await _accountRepository.GetAmountByIbanAsync(iban);
        return Ok(amount);
    }
    
    [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
    [HttpGet("get-transactions")]
    public async Task<IActionResult> GetTransactions(string iban)
    {
        var transactions = await _transactionRepository.GetTransactionsAsync(iban);
        return Ok(transactions);
    }
   
}
