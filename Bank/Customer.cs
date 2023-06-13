using Bank.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Customer : IUser
    {

        public string Name { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public double Wallet { get; set; }
    }
}
