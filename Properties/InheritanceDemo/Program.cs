using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{ 
    public class Person
    {
      public  int age;
        public Person()
        {
            Console.WriteLine("Ahre baba");
        }
        public Person(int a)
        {
            this.age = a;
            Console.WriteLine("My Age Is:" +a);
        }
    }
    public class Teacher :Person
    {
        int id;
        double salary;
        public Teacher()
        {

        }
        public Teacher(int age, int id, double s) : base(age)
        {
            this.id = id;
            this.salary = s;
            Console.WriteLine("Teacher Age Is:"+age);
        }
    }
    
    public class Student : Person
    {
        float cgpa;
        public Student()
        {
            Console.WriteLine("Emty");
        }
        public Student(int age,float cg) : base(age)
        {
            this.cgpa = cg;
            Console.WriteLine("Student age is:"+age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(21);
            Student s = new Student(20,20.5f);
            Person p1 = new Person();
            Console.WriteLine(p1.age = 20);
            Student s1 = new Student();
            
            Teacher t = new Teacher(30, 25, 55.565);
            
            Console.ReadKey();
        }
    }
}
