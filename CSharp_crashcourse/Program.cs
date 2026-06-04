using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_crashcourse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Your Cgpa:");
            double cgpa = double.Parse(Console.ReadLine());
            string result = (cgpa > 3.75) ? "You Can Selected For Scolarship" : "Your Cg Is Not For Scolarship";
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
