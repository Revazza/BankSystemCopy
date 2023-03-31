using BankSystem.Common.Models;
using BankSystem.Reports.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Reports.Controllers;

[Authorize("ApiOperator", AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class CustomersStatisticsController : ControllerBase
{
    private readonly ICustomersStatisticsRepository _customersStatisticsRepository;

    public CustomersStatisticsController(ICustomersStatisticsRepository customersStatisticsRepository)
    {
        _customersStatisticsRepository = customersStatisticsRepository;
    }

    [HttpGet("customers-registered-this-year")]
    public async Task<IActionResult> GetCustomersRegisteredThisYear()
    {
        var customersRegisteredThisYear = await _customersStatisticsRepository.GetCustomersRegisteredThisYear();
        var result = new HttpResult();
        result.Payload.Add("customersRegisteredCurrentYear", customersRegisteredThisYear);

        return Ok(result);
    }

    [HttpGet("customers-registered-last-12-months")]
    public async Task<IActionResult> GetUsersRegisteredLast12Months()
    {
        var customersRegisteredLast12Months = await _customersStatisticsRepository.GetCustomersRegisteredLast12Months();
        var result = new HttpResult();
        result.Payload.Add("customersRegisteredLast12Months", customersRegisteredLast12Months);

        return Ok(result);
    }

    [HttpGet("customers-registered-last-30-days")]
    public async Task<IActionResult> GetCustomersRegisteredLast30Days()
    {
        var customersRegisteredLast30Days = await _customersStatisticsRepository
            .GetCustomersRegisteredLast30Days();
        var result = new HttpResult();
        result.Payload.Add("customersRegisteredLast30Days", customersRegisteredLast30Days);

        return Ok(result);
    }

}