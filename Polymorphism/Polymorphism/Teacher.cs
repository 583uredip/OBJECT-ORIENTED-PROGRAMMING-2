using System;

namespace Polymorphism
{
    class Teacher
    {
        public int mark;
        public double cgpa;

        // Constructor
        public Teacher(int m, double c)
        {
            this.mark = m;
            this.cgpa = c;
        }

        // Property
        public int _Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        // Virtual Method
        public virtual void Mark(int m, double c)
        {
            this.mark = m;
            this.cgpa = c;
            Console.WriteLine("Teacher set the mark " + m + " & set cgpa " + c);
        }
    }

    // Child Class
    
    class Program
    {
        static void Main(string[] args)
        {
            Teacher t = new Teacher(88, 3.50);
            t.Mark(88, 3.50);

            Teacher s = new Student(95, 3.90);
            s.Mark(95, 3.90);

            Console.ReadLine();
        }
    }
}