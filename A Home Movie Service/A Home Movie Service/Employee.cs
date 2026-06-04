using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Home_Movie_Service
{
   public class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Employee(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($" Employee Id:{id}, Employee Name:{name}, Employee Address:{address}");
        }

        public virtual bool EmployeeStatus()
        {
            return false;
        }

    }
}
