using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Singelton
    {
        private int withdrawCounter = 0;
        private static Singelton myInstance;
        private static readonly object lockObject = new object();

        private Singelton(){}

        public static Singelton Instance
        {
            get
            {
                if (myInstance == null)
                {
                    lock (lockObject)
                    {
                        myInstance = new Singelton();
                    }
                }
                return myInstance;
            }
        }
        public void IncreaseCount()
        {
            withdrawCounter++;
        }

        public int GetCount()
        {
            return withdrawCounter;
        }
    }
}
