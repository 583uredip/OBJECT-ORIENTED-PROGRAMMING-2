using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Expression
{
    public delegate int MyDelegate(int num1,int num2);
    class Program
    {

        static void Main(string[] args)
        {
            MyDelegate obj = (d,e) =>
              d * e;
            MyDelegate obj1 = (d,e) =>
             d * e* d;
            int cube = obj1.Invoke(6,7);
            Console.WriteLine(cube);
            Console.ReadKey();
            //MyDelegate obj =  (a) =>
            //{
            //    a += 5;
            //    return a;
            //};
            //Console.WriteLine(obj(5));
            //Console.ReadKey();
        }
    }

} 



