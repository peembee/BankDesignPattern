using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Bank
{
    internal class WithdrawMenu
    {
        private readonly BankMenu bank;
        private readonly ExecuteWithdraw executeWithdraw;
        Customer saveCustomer;
        public WithdrawMenu(BankMenu bank, ExecuteWithdraw executeWithdraw)
        {
            this.bank = bank;
            this.executeWithdraw = executeWithdraw;
        }

        public void WithDraw()
        {
            string id;
            string password;
            bool isLoggedIn = false;
            List<Customer> customerList = bank.CustomerList();

            while (isLoggedIn == false)
            {
                Console.Clear();
                Console.WriteLine("Uttag\n");
                Console.WriteLine("Ditt ID: ");
                id = Console.ReadLine();
                id = id.Trim();
                Console.WriteLine("Lösenord: ");
                password = Console.ReadLine();
                password = password.Trim();
                foreach (var customer in customerList)
                {
                    if (customer.id == id && customer.Password == password)
                    {
                        isLoggedIn = true;
                        saveCustomer = customer;
                        break;
                    }
                }
                if (isLoggedIn)
                {
                    break;
                }
                Console.WriteLine("ID eller lösenord stämmer inte överens");
            }
            doWithdraw();
        }
        private void doWithdraw()
        {
            double amount = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ditt Saldo: " + saveCustomer.Wallet + "\n");
                Console.WriteLine("Hur mycket vill du ta ut: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount > 0 && amount <= saveCustomer.Wallet)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    // do nothing 
                }
                Console.WriteLine("Felaktigt format");
                System.Threading.Thread.Sleep(1000);

            }
            executeWithdraw.Withdraw(amount, saveCustomer);
            Console.WriteLine("Återgår till meny...");
            System.Threading.Thread.Sleep(1000);
            bank.OpenBank();
        }
    }
}
