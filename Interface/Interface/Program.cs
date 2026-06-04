using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Test3 t3 = new Test3();
            t3.print1();
            t3.print2();
            t3.print3();
            t3.print4();
            /*ITest1 t = t3;
            t.print();
            ITest2 t1 = t3;
            t1.print();*/
            ((ITest1)t3).print();
            ((ITest2)t3).print();

            Console.ReadKey();
        }
    }
}
