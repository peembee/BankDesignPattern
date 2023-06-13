using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Interface
{
    internal interface IUser
    {
        public string Name { get; set; }
        public string id { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
