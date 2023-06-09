using BankSystem.Common.Db.Entities;
using BankSystem.Common.Models;
using BankSystem.InternetBank.Api.Validations;
using BankSystem.InternetBank.Models.Requests;
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
    
    private readonly IUserService _userService;


    public UserController(TransactionValidator transactionValidator,
        UserManager<UserEntity> userManager,
        ITransferService transferService,
        IUserLoginService userLoginService
      ,IUserService userService)
    {
        _transactionValidator = transactionValidator;
        _userManager = userManager;
        _transferService = transferService;
        _userLoginService = userLoginService;
      
        _userService = userService;
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
    [AllowAnonymous]
    [HttpPost("reset-password-request")]
    public async Task<IActionResult> ResetPasswordRequest(RequestPasswordResetRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return NotFound("User not found");
        }
        
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = new HttpResult();
        result.Payload.Add("token", token);
        
        return Ok(result);
    
    }
    [AllowAnonymous]
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return NotFound("User not found");
        }
        var resetResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
      
        if (!resetResult.Succeeded)
        {
            var firstError = resetResult.Errors.First();
            return StatusCode(500, firstError.Description);
        }
        var result = new HttpResult();
        result.Payload.Add("result", "Password reset successfully");
        
        return Ok(result);

    }
    [HttpPost("transfer-money")]
    public async Task<IActionResult> TransferMoney(TranferRequest request)
    {
        var user = await _userManager.GetUserAsync(User);
        _transactionValidator.Validate(request, user);
        await _transferService.TransferMoneyAsync(request, user.Id);
        var result = new HttpResult();
        result.Payload.Add("result", "successful transaction");
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

        var cards = await _userService.GetUserCardsAsync(user.Id);
        var result = new HttpResult();
        result.Payload.Add("cards",cards);
        return Ok(result);
    }
    
    [HttpGet("get-transactions")]
    public async Task<IActionResult> GetTransactions(string iban)
    {
        var result = new HttpResult();
        var transactions = await _userService.GetUserTransactionsDtoAsync(iban);
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

        var accounts = await _userService.GetUserAccountsAsync(user);
        var result = new HttpResult();
        result.Payload.Add("accounts",accounts);

        return Ok(result);
    }
    [HttpGet("get-account-cards")]
    public async Task<IActionResult> GetAccountCards(string iban)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest("User Not Found");
        }

        var cards = await _userService.GetAccountCards(iban);
        var result = new HttpResult();
        result.Payload.Add("cards",cards);

        return Ok(result);
    }

    [HttpGet("get-total-withdrawal-amount")]
    public async Task<IActionResult> GetTotalWithdrawalAmount(string iban)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest("User Not Found");
        }

        var totalAmount = await _userService.GetTotalWithdrawalAmountByIbanAsync(iban);
        var result = new HttpResult();
        result.Payload.Add("withdrawalAmount",totalAmount);

        return Ok(result);
    }
    [HttpGet("get-total-received-amount")]
    public async Task<IActionResult> GetTotalReceivedAmount(string iban)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return BadRequest("User Not Found");
        }

        var totalAmount = await _userService.GetTotalReceivedAmountByIbanAsync(iban);
        var result = new HttpResult();
        result.Payload.Add("receivedAmount",totalAmount);

        return Ok(result);
    }
   
}
