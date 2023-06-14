using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class SingeltonCustomer
    {
        private static SingeltonCustomer myInstance;
        private List<Customer> customers;
        private static readonly object lockObject = new object();
        private SingeltonCustomer()
        {
            customers = new List<Customer>();
        }

        public static SingeltonCustomer Instance
        {
            get
            {
                if (myInstance == null)
                {
                    lock (lockObject)
                    {
                        myInstance = new SingeltonCustomer();
                    }
                }
                return myInstance;
            }
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public List<Customer> CustomerList()
        {
            return customers;
        }
    }
}

