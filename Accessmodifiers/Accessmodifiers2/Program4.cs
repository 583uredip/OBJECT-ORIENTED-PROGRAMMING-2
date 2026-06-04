using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessmodifiers;

namespace Accessmodifiers2
    //case 4 child cls for diffrent asembaly
{
    class Program4 : Program1
    {
        static void Main(string[] args)
        {
            Program4 p4 = new Program4();
            p4.Test1();
            p4.Test3();
            p4.Test5();
            Console.ReadKey();
        }
    }
}
