using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] age = { 12, 45, 87, 46, 78, 98, 78, 79, 50, 77, 53,10,15};
            //var a = from i in age where i > 20 orderby i select i;
            //var b = from i in age where i > 20 orderby i descending select i;
            string[] names = {"Redip","Rahul","Preonty","Ali","Rihanul"};
           // var a = from name in names where name.Contains("r") select name;
            var a = from name in names where name.StartsWith("P") select name;
            foreach (string item in a)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine("-----------For Descending Order-------------");
            //foreach(int item1 in b)
            //{
            //    Console.WriteLine(item1);
            //}

            Console.ReadKey();
        }
    }
}
