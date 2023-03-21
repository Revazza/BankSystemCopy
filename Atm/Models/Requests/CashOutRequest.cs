using CommonServices.Db.FinancialEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services.Models.Requests
{
    public class CashOutRequest
    {
        public decimal Amount { get; set; }
        public CurrencyType CurrencyTo { get; set; }
    }
}
