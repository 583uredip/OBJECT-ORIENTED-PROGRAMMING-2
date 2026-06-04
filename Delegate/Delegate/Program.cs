using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    //delegate void HelloDelegate(string n);//costom Data Type
    class Program
    {
        public static bool PromoteRule(Employee emp)
        {
            return emp.salary > 85000  ;
        }
        
        /* public static void Hello(string name)
         {
             Console.WriteLine(name + " Hello ");
         }
         public static void Hello1(string name)
         {
             Console.WriteLine(name + " Hello 1 ");
         }
         public static void Hello2(string name)
         {
             Console.WriteLine(name + " Hello 2 ");
         }*/
        static void Main(string[] args)
        {
            /*HelloDelegate hd = new HelloDelegate(Hello);//hello er ref pass kortesi ba address //hd er sate hello bind kore falci 
            hd = Hello1;
            hd = Hello2;
            Hello("Redip");
            hd("Rahul");
            hd.Invoke("Josim");
            Console.ReadKey();*/
            List<Employee> list = new List<Employee>()
            {
                new Employee { id="1", name="Rahim", age=30, Experience=6, salary=40000 },
                new Employee { id="2", name="Karim", age=25, Experience=3, salary=30000 },
                new Employee { id="3", name="Sakib", age=35, Experience=10, salary=80000 },
                new Employee { id="4", name="Jahid", age=28, Experience=7, salary=50000 },
                new Employee { id="5", name="Naim", age=40, Experience=12, salary=90000 }
            };

            Employee obj = new Employee();
            obj.PromoteEmployee(list, PromoteRule);
            Console.ReadKey();
        }
    }
}






