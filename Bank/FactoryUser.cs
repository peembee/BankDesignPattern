using Bank.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class FactoryUser
    {
        public IUser CreateUser(string userType, string name, string password, double wallet = 0)
        {
            if (userType == "1")
            {
                Customer customer = new Customer();
                customer.Name = name;
                customer.Password = password;
                customer.Wallet = wallet;
                customer.id = GenerateRandomId();
                SingeltonCustomer.Instance.AddCustomer(customer);

                return customer;
            }
            else if (userType == "2")
            {
                Admin admin = new Admin();
                admin.Name = name;
                admin.Password = password;
                admin.id = GenerateRandomId();
                SingeltonAdmin.Instance.AddAdmin(admin);

                return admin;
            }
            return null;
        }
        private string GenerateRandomId()
        {
            string id = "";
            Random rnd = new Random();
            bool breakLoop = false;
            while (breakLoop == false)
            {
                breakLoop = true;
                for (int i = 0; i < 4; i++)
                {
                    int number = rnd.Next(1, 9);
                    id += number.ToString();
                }
                id = id.Trim();
                foreach (var item in SingeltonAdmin.Instance.AdminList())
                {
                    if(item.id == id)
                    {
                        breakLoop = false;
                        id = "";
                    }
                }
                foreach (var item in SingeltonCustomer.Instance.CustomerList())
                {
                    if (item.id == id)
                    {
                        breakLoop = false;
                        id = "";
                    }
                }
            }
            return id;
        }
    }
}
