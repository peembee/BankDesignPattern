using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Interface
{
    internal interface IAdapter
    {
        void Withdraw(double amountToWithdraw, Customer getCustomer);
    }
}
