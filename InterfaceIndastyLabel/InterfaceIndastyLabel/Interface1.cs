using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceIndastyLabel
{
    interface IEmployee
    {
        int id { get; set; }
        string Name { get; set; }
        double salary { get; set; }
        void ShowBasicInfo();
    }
    
    interface IWork
    {
        void Dowork();
        void AttendMeeting();
    }

    interface IReport
    {
        void SubmitReport();
    }
    interface IManager: IEmployee, IWork, IReport
    {
        void ManageTeam();
    }

    class Developer : IEmployee, IWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string ProgrammingLanguage { get; set; }

        public Developer(int id, string name, double salary, string programmingLanguage)
        {
            Id = id;
            Name = name;
            Salary = salary;
            ProgrammingLanguage = programmingLanguage;
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine("----- Developer Information -----");
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Salary: " + Salary);
            Console.WriteLine("Programming Language: " + ProgrammingLanguage);
        }

        public void DoWork()
        {
            Console.WriteLine(Name + " is developing software using " + ProgrammingLanguage + ".");
        }

        public void AttendMeeting()
        {
            Console.WriteLine(Name + " is attending the developer team meeting.");
        }
    }
}
}

