using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BankMenu
    {
        // val 1 = Factory Pattern
        // val 2 = Adapter Pattern
        // val 3 = Singelton Pattern
        // val 4 = Singelton Pattern
        // val 5 = Singelton Pattern

        public void OpenBank()
        {
            string input;
            do
            {
                Console.Clear();

                if (SingeltonCustomer.Instance.CustomerList().Count != 0)
                {
                    Console.WriteLine("Kunder:");
                    foreach (var item in SingeltonCustomer.Instance.CustomerList())
                    {
                        Console.WriteLine("ID: " + item.id + ". Namn: " + item.Name);
                    }
                    Console.WriteLine("---------");
                }
                if (SingeltonAdmin.Instance.AdminList().Count != 0)
                {
                    Console.WriteLine("\nAdmins:");
                    foreach (var item in SingeltonAdmin.Instance.AdminList())
                    {
                        Console.WriteLine("ID: " + item.id + ". Namn: " + item.Name);
                    }
                    Console.WriteLine("---------");
                }

                Console.WriteLine("Välkommen till banken");
                Console.WriteLine("#1: Bli Kund"); // Factory-Pattern - IUser, Customer, Admin, FactoryUser
                Console.WriteLine("#2: Uttag"); // Adapter-Pattern - IAdapter, ExecuteWithdraw
                Console.WriteLine("#3: Insättning"); // Adapter-Pattern - IAdapter, ExecuteWithdraw
                Console.WriteLine("#4: Uttags-statistik för admin"); // Singelton-Pattern - Singelton
                Console.WriteLine("#5: Se alla kunder - för admin"); // Singelton-Pattern - SingeltonCustomer
                Console.WriteLine("#6: Se alla Admins - för admin"); // Singelton-Pattern - SingeltonAdmin
                Console.WriteLine("#0: Avsluta Bank");
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
                        if (SingeltonCustomer.Instance.CustomerList().Count != 0)
                        {
                            WithdrawMenu withdrawMenu = new WithdrawMenu();
                            withdrawMenu.TrancactionPage(1);
                        }
                        else
                        {
                            Console.WriteLine("\n-----------------");
                            Console.WriteLine("Tyvärr finns det inga kunder hos denna bank..");
                            Console.WriteLine("-----------------");
                            System.Threading.Thread.Sleep(1500);
                        }
                        break;
                    case "3":
                        if (SingeltonCustomer.Instance.CustomerList().Count != 0)
                        {
                            WithdrawMenu withdrawMenu = new WithdrawMenu();
                            withdrawMenu.TrancactionPage(0);
                        }
                        else
                        {
                            Console.WriteLine("\n-----------------");
                            Console.WriteLine("Tyvärr finns det inga kunder hos denna bank..");
                            Console.WriteLine("-----------------");
                            System.Threading.Thread.Sleep(1500);
                        }
                        break;

                    case "4":
                        string id = "1";
                        string password = "1";
                        bool logedIn = false;
                        if (SingeltonAdmin.Instance.AdminList().Count > 0)
                        {                           
                            while (logedIn == false)
                            {
                                Console.Clear();
                                Console.WriteLine("#0 för att återgå till meny");
                                Console.WriteLine("Logga in som admin");
                                Console.Write("ID: ");
                                id = Console.ReadLine();
                                id = id.Trim();
                                if (id == "0")
                                {
                                    break;
                                }
                                Console.Write("Lösenord: ");
                                password = Console.ReadLine();
                                password = password.Trim();

                                foreach (var item in SingeltonAdmin.Instance.AdminList())
                                {
                                    if (item.id == id && item.Password == password)
                                    {
                                        logedIn = true;
                                        break;
                                    }
                                }
                                if (logedIn == false)
                                {
                                    Console.WriteLine("Kontrollera dina inloggningsuppgifter");
                                    System.Threading.Thread.Sleep(1000);
                                }
                            }
                            if (id != "0")
                            {
                                Console.Clear();
                                Console.WriteLine("Laddar..");
                                System.Threading.Thread.Sleep(500);
                                Console.WriteLine("Antal totala uttag: " + Singelton.Instance.GetCount() + " St");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vänligen lägg till Admin");
                            System.Threading.Thread.Sleep(1000);
                        }
                        break;
                    case "5":
                        id = "1";
                        password = "1";
                        if (SingeltonAdmin.Instance.AdminList().Count > 0)
                        {                            
                            logedIn = false;
                            while (logedIn == false)
                            {
                                Console.Clear();
                                Console.WriteLine("#0 för att återgå till meny");
                                Console.WriteLine("Logga in som admin");
                                Console.Write("ID: ");
                                id = Console.ReadLine();
                                id = id.Trim();
                                if (id == "0")
                                {
                                    break;
                                }
                                Console.Write("Lösenord: ");
                                password = Console.ReadLine();
                                password = password.Trim();

                                foreach (var item in SingeltonAdmin.Instance.AdminList())
                                {
                                    if (item.id == id && item.Password == password)
                                    {
                                        logedIn = true;
                                        break;
                                    }
                                }
                                if (logedIn == false)
                                {
                                    Console.WriteLine("Kontrollera dina inloggningsuppgifter");
                                    System.Threading.Thread.Sleep(1000);
                                }

                            }
                            if (id != "0")
                            {
                                Console.Clear();
                                Console.WriteLine("Laddar..");
                                System.Threading.Thread.Sleep(500);
                                Console.Clear();
                                Console.WriteLine("Kunder:");
                                foreach (var item in SingeltonCustomer.Instance.CustomerList())
                                {
                                    Console.WriteLine("-----------------------");
                                    Console.WriteLine("ID# " + item.id);
                                    Console.WriteLine("Namn: " + item.Name);
                                    Console.WriteLine("Lösenord: " + item.Password);
                                    Console.WriteLine("Plånbok: " + item.Wallet + " KR");
                                    Console.WriteLine("\n");
                                };
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vänligen lägg till kund");
                            System.Threading.Thread.Sleep(1000);
                        }
                        break;
                    case "6":
                        id = "1";
                        password = "1";
                        logedIn = false;
                        if (SingeltonAdmin.Instance.AdminList().Count > 0)
                        {
                            while (logedIn == false)
                            {
                                Console.Clear();
                                Console.WriteLine("#0 för att återgå till meny");
                                Console.WriteLine("Logga in som admin");
                                Console.Write("ID: ");
                                id = Console.ReadLine();
                                id = id.Trim();
                                if (id == "0")
                                {
                                    break;
                                }
                                Console.Write("Lösenord: ");
                                password = Console.ReadLine();
                                password = password.Trim();

                                foreach (var item in SingeltonAdmin.Instance.AdminList())
                                {
                                    if (item.id == id && item.Password == password)
                                    {
                                        logedIn = true;
                                        break;
                                    }
                                }
                                if (logedIn == false)
                                {
                                    Console.WriteLine("Kontrollera dina inloggningsuppgifter");
                                    System.Threading.Thread.Sleep(1000);
                                }
                            }

                            if (id != "0")
                            {
                                Console.Clear();
                                Console.WriteLine("Admins:");
                                foreach (var item in SingeltonAdmin.Instance.AdminList())
                                {
                                    Console.WriteLine("-----------------------");
                                    Console.WriteLine("ID# " + item.id);
                                    Console.WriteLine("Namn: " + item.Name);
                                    Console.WriteLine("Lösenord: " + item.Password);
                                    Console.WriteLine("\n");
                                };
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vänligen lägg till Admin");
                            System.Threading.Thread.Sleep(1000);
                        }
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
    }
}
