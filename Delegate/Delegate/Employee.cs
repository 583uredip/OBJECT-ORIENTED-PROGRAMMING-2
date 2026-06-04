using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//.net site devoloper
namespace Delegate
{
    delegate bool PromoteDelegate(Employee emp);
   class Employee
    {
        public string id { get; set; }
        public string name {get; set; }
        public int age { get; set; }
        public int Experience { get; set; }
        public double salary { get; set; }

        public void PromoteEmployee(List<Employee> employees, PromoteDelegate promote)
        {

            foreach(Employee emp in employees)
            {
               /* if(emp.Experience>5)
                {
                    Console.WriteLine(emp.name+" Promote ");
                }

                else
                {
                    Console.WriteLine(emp.name+" Not Promote ");
                }*/
               if(promote(emp))
                {
                    Console.WriteLine(emp.name+" Promot ");
                }

               else
                {
                    Console.WriteLine(emp.name+ " Not Promot ");
                }
            }
        }

    }
}
