using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
 
    class Program
    {
        static void Main(string[] args)
        {

            Person p = new Person();
            Console.WriteLine(p._Id);
            p._Id = 20;
            Console.WriteLine(p._Name);
            Console.WriteLine(p._Name = "Redip Biswas");
            //p._Salary= 268.244;
            //Console.WriteLine($"Your Salary Is: { p._Salary } tk ");
            Console.WriteLine($"Your Salary Is: { p._Salary } tk ");
            Console.ReadKey();


        }
    }
}
