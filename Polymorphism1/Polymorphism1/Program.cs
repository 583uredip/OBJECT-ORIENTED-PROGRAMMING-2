using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism1
{
    class Program
    {
        public void Test()
        {
            Console.WriteLine("Aiub,Nsu");
        }
        public void Test(int x)
        {
            Console.WriteLine("test with 1 int parameter");
        }
        public void Test(string x)
        {
            Console.WriteLine("test with 1 string parameter");
        }
        public void Test(int x,string y)
        {
            Console.WriteLine("test with 1 int parameter & string ");
        }

        
    }

    class Program2:Program
    {
        public void Test(string x,int y)
        {
            Console.WriteLine("test with 1 string parameter & int parametar");
        }

        public new void Test()//method hiding
        {
            Console.WriteLine("My name is mou");
        }
        static void Main(string[] args)
        {
            Program2 p = new Program2();
            p.Test();
            p.Test(100);
            p.Test("Redip Biswas");
            p.Test(200, "AIUB");
            p.Test("TYU", 34);
            Program p2 = new Program();
            p2.Test();
          

            Console.ReadKey();

        }
    }
}
