using Bank.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class ExecuteWithdraw : IAdapter
    {
        private readonly Customer customer;
        public ExecuteWithdraw(Customer customer)
        {
            this.customer = customer;
        }
        public void Withdraw(double amountToWithdraw, Customer getCustomer)
        {
            getCustomer.Wallet = getCustomer.Wallet - amountToWithdraw;
            Singelton.Instance.IncreaseCount();
            Console.WriteLine("Uttag: " + amountToWithdraw  + " KR");
            Console.WriteLine("Saldo kvar: " + getCustomer.Wallet);
            Console.WriteLine("\nGodkänt");
            Console.WriteLine("\n\nEnter för avsluta");
            Console.ReadKey();
        }
    }
}
