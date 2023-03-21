using CommonServices.Db.Entities;
using CommonServices.Repositores;

using InternetBank.API.Requests;
using InternetBank.API.Validations;
using InternetBank.Models.Requests;
using InternetBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InternetBank.API.Controllers;
[ApiController]
[Route("[controller]")]
public class InternetBankController : ControllerBase
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly RegisterUserValidator _registerUserValidator;
    private readonly RegisterCardValidator _registerCardValidator;
    private readonly IOperatorRepository _operatorRepository;
    private readonly IbanService _ibanService;
    private readonly ITransferService _transferService;
    private readonly IAddUserService _addUserService;
    private readonly IAddAccountService _addAccountService;
    private readonly IAddCardService _addCardService;
    private readonly IUserLoginService _userLoginService;
    private readonly ITransactionRepository _transactionRepository;
    private readonly TransactionValidator _transactionValidator;
    private readonly ICardRepository _cardRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;

    public InternetBankController(
        UserManager<UserEntity> userManager,
        RegisterUserValidator registerUserValidator,
        RegisterCardValidator registerCardValidator,
        IOperatorRepository operatorRepository,
        IbanService ibanService,
        ITransferService transferService, IAddUserService addUserService, 
        IAddAccountService addAccountService,
        IAddCardService addCardService,
        IUserLoginService userLoginService, ITransactionRepository transactionRepository,
        TransactionValidator transactionValidator, 
        ICardRepository cardRepository,
        IAccountRepository accountRepository, 
        IUserRepository userRepository)
    {
        _userManager = userManager;
        _registerUserValidator = registerUserValidator;
        _registerCardValidator = registerCardValidator;
        _operatorRepository = operatorRepository;
        _ibanService = ibanService;
        _transferService = transferService;
        _addUserService = addUserService;
        _addAccountService = addAccountService;
        _addCardService = addCardService;
        _userLoginService = userLoginService;
        _transactionRepository = transactionRepository;
        _transactionValidator = transactionValidator;
        _cardRepository = cardRepository;
        _accountRepository = accountRepository;
        _userRepository = userRepository;
    }

    [HttpPost("operator-login")]
    public async Task<string> LoginOperatorAsync(string name)
    {
        var token = await _operatorRepository.OperatorLoginAsync(name);
        return token;
    }

    [Authorize("ApiAdmin", AuthenticationSchemes = "Bearer")]
    [HttpPost("register-user")]
    public async Task<IActionResult> RegisterUserAsync(RegisterUserRequest request)
    {
        try
        {
            _registerUserValidator.Validate(request);
            await _addUserService.AddUserAsync(request);
            return Ok("User has been Registered successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody]LoginRequest request)
    {
        var token = await _userLoginService.LoginUserAsync(request);
        return Ok(token);
    }

    [Authorize("ApiAdmin", AuthenticationSchemes = "Bearer")]
    [HttpPost("register-bank-account")]
    public async Task<IActionResult> RegisterAccountAsync(RegisterAccountRequest request)
    {
        var iban = _ibanService.GenerateIBan();
        await _addAccountService.AddAccountAsync(request, iban);
        return Ok();
    }

    [Authorize("ApiAdmin", AuthenticationSchemes = "Bearer")]
    [HttpPost("register-card")]
    public async Task<IActionResult> RegisterCardAsync(RegisterCardRequest? request)
    {
        _registerCardValidator.Validate(request);
        await _addCardService.AddCardAsync(request);
        return Ok("Card has been Added successfully");
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

    [Authorize("ApiUser", AuthenticationSchemes = "Bearer")]
    [HttpPost("exists")]
    public async Task<IActionResult> ibanExists(string iban)
    {
        var exists = _transactionRepository.IbanExists(iban);
        return Ok(exists);
    }

}