using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3test3
{
    class Student
    {
        string name;
        string id;
        string dep;
        float cgpa;

        public Student(string name,string id,string dep, float cgpa)
        {
            this.name = name;
            this.id = id;
            this.dep = dep;
            this.cgpa = cgpa;
        }

        public void ShowInfo()
        {
            Console.WriteLine("------Student Info-------");
            Console.WriteLine($"Student Name:{name}\n Student Id:{id}\n Student Dep:{dep}\n Student Cgpa:{cgpa}");
            Console.WriteLine();
        }

        
    }
}
