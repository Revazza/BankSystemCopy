using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Common.Db.Entities
{
    public class CurrencyEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public int Quantity { get; set; }
        public string RateFormated { get; set; }
        public string DiffFormated { get; set; }
        [Precision(18, 3)]
        public decimal Rate { get; set; }
        public string Name { get; set; }
        [Precision(18, 3)]
        public decimal Diff { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

    }
}
