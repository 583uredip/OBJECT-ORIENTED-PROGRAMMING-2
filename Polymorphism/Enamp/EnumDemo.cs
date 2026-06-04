using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enamp
{
     public enum DaysOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    public enum StatuesCode
    {
        Success = 200,
        BadRequest = 400,
        NotFound = 404,
        InternalServerError = 500
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            DaysOfWeek today = DaysOfWeek.Monday;
            switch(today)
            {
                case DaysOfWeek.Friday:
                    Console.WriteLine("This is Gov holiday week");
                    break;
                case DaysOfWeek.Saturday:
                    Console.WriteLine("This is my university holiday week");
                    break;
                case DaysOfWeek.Sunday:
                    Console.WriteLine("This is My 1st day class--C# & Toc");
                    break;
                case DaysOfWeek.Monday:
                    Console.WriteLine("This is My 2nd day class--Dlc lab, Math 5 & Dlc");
                    break;
                case DaysOfWeek.Tuesday:
                    Console.WriteLine("This is my 3rd day class--C# & Toc");
                    break;
                case DaysOfWeek.Wednesday:
                    Console.WriteLine("This is my 4th day class--ECONOMICS,Math 5,Dlc");
                    break;
                default:
                    Console.WriteLine("It's a Mackup class.");
                    break;
            }
            Console.WriteLine($"Today is:{today}");
            Console.WriteLine($"The intigar value of my class:{(int)today}");
            //Program p = new Program();
            //p.Day = class_Day.Monday;
            //Console.WriteLine("Today Is:"+p.Day);
            //Console.WriteLine((int)class_Day.Thursday);
            //foreach (class_Day day in Enum.GetValues(typeof(class_Day)))
            //Console.WriteLine(day + " = " + (int)day);
            //Console.ReadLine();
            StatuesCode responseStatus = StatuesCode.NotFound;
            Console.WriteLine($"\nHTTP Status: {responseStatus}"); // Prints "HTTP Status: NotFound"
            Console.WriteLine($"Numeric value of NotFound: {(int)responseStatus}"); // Prints "Numeric value of NotFound: 404"
            Console.WriteLine("\nAll days of the week:");
            foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
            {
                Console.WriteLine($"- {day}");
            }
            Console.ReadKey();
        }
    }
}
