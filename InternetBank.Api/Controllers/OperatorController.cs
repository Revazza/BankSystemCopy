using BankSystem.Common.Models;
using BankSystem.InternetBank.Models.Requests;
using BankSystem.InternetBank.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.InternetBank.Api.Controllers;

[ApiController]
[Authorize("ApiOperator", AuthenticationSchemes = "Bearer")]
[Route("[controller]")]
public class OperatorController : ControllerBase
{
    private readonly IbanService _ibanService;
    private readonly IAddUserService _addUserService;
    private readonly IAddAccountService _addAccountService;
    private readonly IAddCardService _addCardService;
    private readonly IOperatorService _operatorService;


    public OperatorController(
        IbanService ibanService,
        IAddUserService addUserService,
        IAddAccountService addAccountService,
        IAddCardService addCardService,
        IOperatorService operatorService
    )
    {
        _ibanService = ibanService;
        _addUserService = addUserService;
        _addAccountService = addAccountService;
        _addCardService = addCardService;
        _operatorService = operatorService;
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
        var accountDto = _operatorService.GetAccountDetails(account);
        var result = new HttpResult();
        result.Payload.Add("account", accountDto);
        return Ok(result);
    }

    [HttpPost("register-card")]
    public async Task<IActionResult> RegisterCardAsync(RegisterCardRequest? request)
    {
        var card = await _addCardService.AddCardAsync(request);
        var cardDto = _operatorService.GetCardDetails(card);
        var result = new HttpResult();
        result.Payload.Add("card", cardDto);
        return Ok(result);
    }
}