using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services.Models.Requests
{
    public class LoginRequest
    {
        public string? CardNumber { get; set; }
        public short Pin { get; set; }

    }
}
