using BankSystem.Common.Models;
using BankSystem.Reports.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Reports.Controllers;

//[Authorize("ApiOperator", AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class CustomerStatisticsController : ControllerBase
{
    private readonly ICustomersStatisticsRepository _customersStatisticsRepository;

    public CustomerStatisticsController(ICustomersStatisticsRepository customersStatisticsRepository)
    {
        _customersStatisticsRepository = customersStatisticsRepository;
    }

    [HttpGet("customer-registered-this-year")]
    public async Task<IActionResult> GetCustomersRegisteredThisYear()
    {
        var customerRegisteredCurrentYear = await _customersStatisticsRepository.GetCustomersRegisteredThisYear();
        var result = new HttpResult();
        result.Payload.Add("customerRegisteredCurrentYear", customerRegisteredCurrentYear);

        return Ok(result);
    }

    [HttpGet("customer-registered-last-12-months")]
    public async Task<IActionResult> GetUsersRegisteredLast12Months()
    {
        var customerRegisteredLast12Months = await _customersStatisticsRepository.GetCustomersRegisteredLast12Months();
        var result = new HttpResult();
        result.Payload.Add("customerRegisteredLast12Months", customerRegisteredLast12Months);

        return Ok(result);
    }

    [HttpGet("customer-registered-last-30-days")]
    public async Task<IActionResult> GetCustomersRegisteredLast30Days()
    {
        var customerRegisteredLast30Days = await _customersStatisticsRepository
            .GetCustomersRegisteredLast30Days();
        var result = new HttpResult();
        result.Payload.Add("customerRegisteredLast30Days", customerRegisteredLast30Days);

        return Ok(result);
    }

}