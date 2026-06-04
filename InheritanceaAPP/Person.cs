using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceaAPP
{
   public class Person
    {
        public string Name
        {
            get;
            private set;
        }
        public int Age
        {
            get;
            private set;
        }
        public Person(string name,int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine("Person constructor called");
        }

        public void DisplayPersonInfo()
        {
            Console.WriteLine($"Name:{Name},Age:{Age}");
        }



    }

    class Employee:Person
    {
        public Employee(string name,int age):base(name,age)
        {
           // name = "Rahul";
            Console.WriteLine("Employee (drived class) constructor called");
        }
    }
}
