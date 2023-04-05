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
[Authorize("ApiOperator", AuthenticationSchemes = "Bearer")]
[Route("[controller]")]
public class OperatorController : ControllerBase
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IbanService _ibanService;
    private readonly IAddUserService _addUserService;
    private readonly IAddAccountService _addAccountService;
    private readonly IAddCardService _addCardService;
    private readonly IUserLoginService _userLoginService;


    public OperatorController(
        UserManager<UserEntity> userManager,
        IbanService ibanService,
        IAddUserService addUserService,
        IAddAccountService addAccountService,
        IAddCardService addCardService,
        IUserLoginService userLoginService
    )
    {
        _userManager = userManager;
        _ibanService = ibanService;
        _addUserService = addUserService;
        _addAccountService = addAccountService;
        _addCardService = addCardService;
        _userLoginService = userLoginService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
    {
        var token = await _userLoginService.LoginUserAsync(request);
        var result = new HttpResult();
        result.Payload.Add("token", token);

        return Ok(result);
    }

    [HttpPost("register-user")]
    public async Task<IActionResult> RegisterUserAsync(RegisterUserRequest request)
    {
        var newUser = await _addUserService.AddUserAsync(request);
        var result = new HttpResult();
        result.Payload.Add("user", newUser);

        return Ok(result);
    }

    [HttpPost("register-bank-account")]
    public async Task<IActionResult> RegisterAccountAsync(RegisterAccountRequest request)
    {
        var iban = _ibanService.GenerateIBan();
        var account = await _addAccountService.AddAccountAsync(request, iban);
        var accountDto = new AccountDto()
        {
            Amount = account.Amount,
            Iban = account.Iban,
            Currency = account.Currency
        };
        var result = new HttpResult();
        result.Payload.Add("account", accountDto);
        return Ok(result);
    }

    [HttpPost("register-card")]
    public async Task<IActionResult> RegisterCardAsync(RegisterCardRequest? request)
    {
        var card = await _addCardService.AddCardAsync(request);
        var cardDto = new CardDto()
        {
            CardNumber = card.CardNumber,
           
            ExpiresAt = card.ExpiresAt,
            CreatedAt = card.CreatedAt,
            FullName = card.FullName
        };
        var result = new HttpResult();
        result.Payload.Add("card", cardDto);
        return Ok(result);
    }
}