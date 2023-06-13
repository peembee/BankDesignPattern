using Bank.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bank
{
    internal class CreateUser
    {
        FactoryUser factoryUser = new FactoryUser();
        string userType;
        string name;
        string password;
        double wallet = 0;
        public void Create()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välj typ av användare");
                Console.WriteLine("#1: Kund");
                Console.WriteLine("#2: Admin");
                Console.Write("Ange val: ");
                userType = Console.ReadLine();
                userType = userType.Trim();

                if (userType != "1" && userType != "2")
                {
                    Console.WriteLine("Ogiltigt val, försök igen..");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    break;
                }
            }

            Console.Clear();

            while (true)
            {
                Console.Write("\nFullständigt namn: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Ogiltigt format");
                }
                else
                {
                    break;
                }
            }
            name = name.Trim();

            while (true)
            {
                Console.Write("\nLösenord: ");
                password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("Ogiltigt format");
                }
                else
                {
                    break;
                }
            }
            password = password.Trim();

            if (userType == "1")
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nLägg in belopp: ");
                        wallet = Convert.ToDouble(Console.ReadLine());
                        if (wallet > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Summan måste vara mer än 0..");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ogiltigt format");
                    }
                }
                IUser user = factoryUser.CreateUser(userType, name, password, wallet);
            }
            else
            {
                IUser user = factoryUser.CreateUser(userType, name, password);
            }
            Console.WriteLine("Användaren har skapats. Återgår till huvudmenyn...");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
