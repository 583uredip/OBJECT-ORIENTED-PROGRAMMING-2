using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
   class Program 
    {
        static int pass=50;
        private int marks;

        static void Main(string[] args)
        {
            //For Program Class 

            Program p1 = new Program();
            Program p2 = new Program();
            Program p3 = new Program();
            Program.pass = 60;//ei kanhe class er trough static er mahn change kora hoche ...
            p1.marks = 80;
            p2.marks = 50;
            p3.marks = 100;

            Console.WriteLine("-----Out Put Of Program Class------");
            if (p1.marks >= pass)
            {
                Console.WriteLine("P1 Student Is Passed");
            }
            else
            {
                Console.WriteLine("P1 Is Faild");
            }
            if (p2.marks >= pass)
            {
                Console.WriteLine("P2 Student Is Passed");
            }
            else
            {
                Console.WriteLine("P2 Is Faild");
            }
            if (p3.marks >= pass)
            {
                Console.WriteLine("P3 Student Is Passed");
            }
            else
            {
                Console.WriteLine("P3 Is Faild");
            }
            //Program class is end 
            Console.WriteLine("----------------------------");
            //Student class start
            Console.WriteLine("-------Out Put Of Student Class------");
            Student s1 = new Student();
            Student s2 = new Student();
            Student s3 = new Student();
            Student.pass1 = 50;///ei kanhe class er trough static er mahn change kora hoche ...

            s1.marks1 = 100;
            s2.marks1 = 45;
            s3.marks1 = 80;

            CheckResult(s1, "Student 1");
            CheckResult(s2, "Student 2");
            CheckResult(s3, "Student 3");
          
            void CheckResult(Student s,string name)
            {
                if (s.marks1 >= 95)
                {
                    Console.WriteLine(name + " Is Excellent Student");

                }
                else if (s.marks1 >= Student.pass1)
                {
                    Console.WriteLine(name + " Is Passed");

                }

                else
                {
                    Console.WriteLine(name + " Is Failed");

                }

            }
            Console.ReadKey();
        }
    }
}
