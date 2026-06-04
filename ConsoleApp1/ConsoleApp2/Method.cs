using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Method
    {
        static void Myname()
        {
            Console.WriteLine("Redip Biswas");
        }
        static void MyMethod(string name, int age)
        {
            Console.WriteLine(name + " is " + age);
        }
        static void MySum(int a, int b)
        {
            int result = a + b;

            Console.WriteLine("Sub Answer Is:" + result);
        }
        static void MyDefalt(int age = 18)
        {
            Console.WriteLine("Your age is:" + age);
        }
        static int MulAns(int a, int b)
        {
            return a * b;
        }

        //"------------------ See Your Age --------------------")
        
        static int SeeAge(int c_year, int b_year)
        {
            int age = c_year - b_year;
            return age;
        }
        static int SubAns(int a, int b)
        {
            return a - b;
        }
        //Method Overloading
        static double Myover(int a,int b)
        {
            return (double)a / b;
        }
        static string Myover(string name)
        {
            return name;
        }
        static void Main(string[] args)
        {
            Console.Write("My name is:");
            Myname();
            MyMethod("Redip", 23);
            MySum(20, 25);
            MyDefalt(10);
            MyDefalt(22);
            MyDefalt();
            MyDefalt(30);
           int  result= MulAns(30,50) ;
            Console.WriteLine("Mul Answer Is:" + result);
            Console.WriteLine();
            Console.WriteLine("------------------ See Your Age --------------------");
            Console.Write("Enter Current Year:");
            int C_year = int.Parse(Console.ReadLine());
            Console.Write("Enter Your Brith Year:");
            int B_year = int.Parse(Console.ReadLine());
            int ageAns = SeeAge(C_year, B_year);
            Console.WriteLine("Your Age Is Now:" + ageAns);
            if (ageAns < 18)
            {
                Console.WriteLine("Message: Listen to your parents.");
            }
            else if (ageAns >= 18 && ageAns <= 30)
            {
                Console.WriteLine("Message: Get a proper job and take responsibility for the family.");
            }
            else if (ageAns > 30 && ageAns <= 60)
            {

                Console.WriteLine("Message: Get married and live happily.");
            }
            else if (ageAns > 60 && ageAns < 100)
            {

                Console.WriteLine("Message: Remember God; the real life begins after death.");
            }
            else
            {

                Console.WriteLine("Message: You are a Legend!");
            }
            //End See Your Age
            Console.WriteLine("--------------------------------------------------------------------------");
            int result2 = SubAns(b: 50, a: 100);
            Console.WriteLine("Sub Answer Is:" + result2);
            double result3 = Myover(30, 100);
            Console.WriteLine("Divison Ans:" +result3);
            string fullname = Myover("Redip Biswas");
            Console.WriteLine("Your Name Is:" + fullname);
            Console.ReadKey();
        }
    }
}
