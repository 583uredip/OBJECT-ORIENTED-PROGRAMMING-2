using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Student : Teacher
    {
        public Student(int m, double c) : base(m, c)
        {
        }

        public override void Mark(int m, double c)
        {
            this.mark = m;
            this.cgpa = c;
            Console.WriteLine("Student set the mark " + m + " & set cgpa " + c);
        }
    }

}
