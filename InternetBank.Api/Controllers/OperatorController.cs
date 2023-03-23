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
public class OperatorController : ControllerBase
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IOperatorRepository _operatorRepository;
    private readonly IbanService _ibanService;
    private readonly IAddUserService _addUserService;
    private readonly IAddAccountService _addAccountService;
    private readonly IAddCardService _addCardService;
    

    public OperatorController(
        UserManager<UserEntity> userManager,
        IOperatorRepository operatorRepository,
        IbanService ibanService,
        IAddUserService addUserService, 
        IAddAccountService addAccountService,
        IAddCardService addCardService
    )
    {
        _userManager = userManager;
        _operatorRepository = operatorRepository;
        _ibanService = ibanService;
        _addUserService = addUserService;
        _addAccountService = addAccountService;
        _addCardService = addCardService;
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
            await _addUserService.AddUserAsync(request);
            return Ok("User has been Registered successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
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
        await _addCardService.AddCardAsync(request);
        return Ok("Card has been Added successfully");
    }
}