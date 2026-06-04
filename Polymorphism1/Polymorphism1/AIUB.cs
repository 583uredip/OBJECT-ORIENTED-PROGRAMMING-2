using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism1
{
    class Nsu
    {

    }
    class Iub
    {

    }
    class AIUB
    {
        public static void Test(object I)
        {
            Iub i = I as Iub;

            if (i != null)
            {
                Console.WriteLine("Iub object");
                return;
            }
            if (I is AIUB)
            {
                AIUB b = (AIUB)I;
                Console.WriteLine("I is a AIUb type");
            }
            else if(I is Nsu)
            {
                Nsu s = (Nsu)I;
                Console.WriteLine("I is a Nsu type");
            }
            else if(I is string)
            {
                Console.WriteLine("I is string type");
            }
            else
            {
                Console.WriteLine("I is Int type");
            }

        }
        static void Main(string[] args)
        {
            AIUB a = new AIUB();
            Nsu n = new Nsu();
            Iub u = new Iub();
            

            Test(a);
            Test(n);
            Test("I Love my country");
            Test(100);
            Test(u);
            Console.ReadKey();


        }
    }
}
