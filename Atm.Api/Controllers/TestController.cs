using CommonServices.Db;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly BankSystemDbContext _context;

        public TestController(BankSystemDbContext context)
        {
            _context = context;
        }


        [HttpGet("throw-unhandled-exception")]
        public IActionResult ThrowUnhandledException()
        {
            throw new Exception("Unhandled Exception occured");
        }

        [HttpGet("throw-unhandled-null-division")]
        public IActionResult ThrowNullDivision()
        {
            throw new DivideByZeroException();
        }

        [HttpGet("get-all-cards")]
        public IActionResult GetAllCards()
        {
            return Ok(_context.Cards.ToList());
        }

        [HttpGet("get-all-transactions")]
        public IActionResult GetAllTransactions()
        {
            return Ok(_context.Transactions.ToList());
        }

        [HttpGet("get-all-accounts")]
        public IActionResult GetAllAccounts()
        {
            return Ok(_context.Accounts.ToList());
        }

        [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            return Ok(_context.Users.ToList());
        }

        


    }
}
