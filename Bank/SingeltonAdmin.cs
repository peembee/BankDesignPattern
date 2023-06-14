using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class SingeltonAdmin
    {
        private static SingeltonAdmin myInstance;
        private List<Admin> admins;
        private static readonly object lockObject = new object();
        private SingeltonAdmin()
        {
            admins = new List<Admin>();
        }

        public static SingeltonAdmin Instance
        {
            get
            {
                if (myInstance == null)
                {
                    lock (lockObject)
                    {
                        myInstance = new SingeltonAdmin();
                    }
                }
                return myInstance;
            }
        }

        public void AddAdmin(Admin admin)
        {
            admins.Add(admin);
        }

        public List<Admin> AdminList()
        {
            return admins;
        }
    }
}
