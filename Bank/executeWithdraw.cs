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

        public void Withdraw(int amountToWithdraw, Customer getCustomer)
        {
            getCustomer.Wallet = getCustomer.Wallet - amountToWithdraw;
            Singelton.Instance.IncreaseCount();
            Console.WriteLine("Uttag: " + amountToWithdraw  + " KR");
            Console.WriteLine("Kontrollerar...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Saldo kvar: " + getCustomer.Wallet + " KR");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\n-----------");
            Console.WriteLine("Godkänt");
            Console.WriteLine("-----------");
            Console.WriteLine("\nEnter för avsluta");
            Console.ReadKey();
        }

        public void Deposit(int amountToWithdraw, Customer getCustomer)
        {
            Console.WriteLine("Nuvarande saldo: " + getCustomer.Wallet + " KR");
            getCustomer.Wallet = getCustomer.Wallet + amountToWithdraw;
            Singelton.Instance.IncreaseCount();
            Console.WriteLine("Arbetar...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Nytt saldo: " + getCustomer.Wallet + " KR");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\n-----------");
            Console.WriteLine("Godkänt");
            Console.WriteLine("-----------");
            Console.WriteLine("\nEnter för avsluta");
            Console.ReadKey();
        }
    }
}
