using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BankMenu
    {
        private List<Customer> customers = new List<Customer>(); // gör en statisk class istället för båda listorna
        private List<Admin> admins = new List<Admin>();

        public void OpenBank()
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("Välkommen till banken");
                Console.WriteLine("#1: Bli Kund"); // Factory-Pattern
                Console.WriteLine("#2: Uttag"); // Adapter-Pattern
                Console.WriteLine("#3: Uttags-statistik för admin"); // Singelton-Pattern
                Console.WriteLine("#4: Se alla kunder"); // Singelton-Pattern
                Console.WriteLine("#0: Avsluta Bank"); // Singelton-Pattern
                Console.Write("Ange val: ");
                input = Console.ReadLine();
                input = input.Trim();


                switch (input)
                {
                    case "1":
                        CreateUser createUser = new CreateUser();
                        createUser.Create();
                        break;

                    case "2":
                        //WithdrawMenu withdrawMenu = new WithdrawMenu();
                        //withdrawMenu.WithDraw();
                        break;

                    case "3":
                        Console.WriteLine("Antal totala uttag: " + Singelton.Instance.GetCount() + " St");
                        Console.ReadKey();
                        break;
                    case "4":
                        foreach (var item in customers)
                        {
                            Console.WriteLine(item);
                        };
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Ange ett giltigt val");
                        break;
                }
            } while (input != "0");
            Console.Clear();
            Console.WriteLine("Avslutar applikation");
            System.Threading.Thread.Sleep(1500);
            Environment.Exit(0);
        }

        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }
        public List<Customer> CustomerList()
        {
            return customers;
        }
        public void addCustomer(Admin admin)
        {
            admins.Add(admin);
        }
        public List<Admin> AdminList()
        {
            return admins;
        }
    }
}
