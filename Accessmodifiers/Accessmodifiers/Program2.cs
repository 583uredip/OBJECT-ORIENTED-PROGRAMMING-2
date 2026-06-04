using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessmodifiers //child class from same assembly
{
    class Program2 : Program1
    {
        static void Main(string[] args)
        {
            Program2 p2 = new Program2();
                p2.Test1();
                p2.Test3();
                p2.Test4();
                p2.Test5();
                p2.Test6();
                Console.ReadKey();

        }
    }
}
