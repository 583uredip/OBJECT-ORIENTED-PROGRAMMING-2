using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    class Redip
    {
        static void Main(string[] args)
        {
            int x = 10;
            double d = x;//type casting int to double 
            int y = (int)d;
            string name = "AIUB";
            int a=int.Parse(name);
            name = a.ToString(name);
            Console.WriteLine(x);

        }     
    }
}
