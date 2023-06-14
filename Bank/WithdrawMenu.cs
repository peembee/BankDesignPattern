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
        Customer saveCustomer;  

        public void TrancactionPage(int direction)
        {
            string id = "";
            string password = "";
            bool isLoggedIn = false;

            while (isLoggedIn == false)
            {
                Console.Clear();
                foreach (var item in SingeltonCustomer.Instance.CustomerList())
                {
                    Console.WriteLine(item.Name + ". ID: " + item.id);
                }
                Console.WriteLine("#0 för att återgå till meny");
                Console.WriteLine("\nUttag");
                Console.Write("Ange ditt ID: ");
                id = Console.ReadLine();
                id = id.Trim();
                if(id == "0")
                {
                    break;
                }
                Console.Write("Lösenord: ");
                password = Console.ReadLine();
                password = password.Trim();
                foreach (var customer in SingeltonCustomer.Instance.CustomerList())
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
                System.Threading.Thread.Sleep(1000);
            }
            if (id != "0")
            {
                if (direction == 1)
                {
                    doWithdraw();
                }
                else
                {
                    doDeposit();
                }
            }
                        Console.WriteLine("Återgår till meny...");
            System.Threading.Thread.Sleep(1000);
        }
        private void doWithdraw()
        {
            int amount = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Kund: " + saveCustomer.Name + ". ID: " + saveCustomer.id);
                Console.WriteLine("Ditt Saldo: " + saveCustomer.Wallet + " KR\n");
                Console.Write("Hur mycket vill du ta ut: ");
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
            ExecuteWithdraw executeWithdraw = new ExecuteWithdraw(saveCustomer);
            executeWithdraw.Withdraw(amount, saveCustomer);
        }
        private void doDeposit()
        {
            int amount = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Kund: " + saveCustomer.Name + ". ID: " + saveCustomer.id);
                Console.WriteLine("Ditt Saldo: " + saveCustomer.Wallet + " KR\n");
                Console.Write("Ange summa att sätta in: ");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    // do nothing 
                }
                Console.WriteLine("Felaktigt format");
                System.Threading.Thread.Sleep(1000);
            }
            ExecuteWithdraw executeWithdraw = new ExecuteWithdraw(saveCustomer);
            executeWithdraw.Deposit(amount, saveCustomer);
        }
    }
}
