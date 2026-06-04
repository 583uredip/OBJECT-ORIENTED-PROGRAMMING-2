using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cost_Type_and_readonly
{
    class Bank
    {
        // const int limit = 10000;
        readonly int limit;
        public Bank(int l)
        {
            limit = l;
        }
        public void Show()
        {
            Console.WriteLine("Limit" + limit);
        }
        static void Main(string[] args)
        {

            Bank b1 = new Bank(1000);
            Bank b2 = new Bank(5000);
            Bank b3 = new Bank(45000);

            b1.Show();
            b2.Show();
            b3.Show();

            Console.ReadKey();

        }
    }
}
