using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Atm.Services.Models.Requests
{
    public class ChangePinRequest
    {
        public short OldPin { get; set; }
        public short NewPin { get; set; }
    }
}
