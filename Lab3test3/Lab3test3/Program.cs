using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3test3
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Student s1 = new Student("Rahim", "S101", "CSE", 3.75f);
            Student s2 = new Student("Karim", "S102", "EEE", 3.20f);

            s1.ShowInfo();
            s2.ShowInfo();

           
            Triangel t1 = new Triangel(5, 5, 5);
            Triangel t2 = new Triangel(5, 5, 3);
            Triangel t3 = new Triangel(3, 4, 5);

            t1.ShowInfo();
            t1.TestTriangle();

            t2.ShowInfo();
            t2.TestTriangle();

            t3.ShowInfo();
            t3.TestTriangle();

            Console.ReadLine();

        }
    }
}
