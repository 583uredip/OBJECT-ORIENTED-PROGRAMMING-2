using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Home_Movie_Service
{
    class Manager:Employee
    {
        int yearsOfExperience;
        public Manager(string id, string name, string address, int yearsOfExperience):base(id, name, address)
        {
            this.yearsOfExperience = yearsOfExperience;
        }

        public override bool EmployeeStatus()
        {
           if(yearsOfExperience>2)
            {
                return true;
            }
            return false;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("-----------Manager Information-----------");
            Console.WriteLine($"Manager Id:{id}\nManager Name:{name}\nManager Address:{address}\nYearsOfExperience:{yearsOfExperience}");
            Console.WriteLine("Eligible for Bonus:" + (EmployeeStatus() ? "Yes":"No"));
        }
    }
}
