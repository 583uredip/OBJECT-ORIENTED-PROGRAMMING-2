using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessmodifiers2 //non child class for difrent assembily
{
    class Program5
    {
        static void Main(string[] args)
        {
            Accessmodifiers.Program1 ap = new Accessmodifiers.Program1();
            ap.Test1();
            Console.ReadKey();
            

        }
    }
}
