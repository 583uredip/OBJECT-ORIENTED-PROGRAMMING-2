using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo
{
    public enum Gender
    {

        mail, femail, other

    }
    public enum Days
    {

        Monday,    // Default value 0
        Tuesday,   // Default value 1
        Wednesday, // Default value 2
        Thursday,  // Default value 3
        Friday,    // Default value 4
        Saturday,  // Default value 5
        Sunday     // Default value 6

    }

    class Enum
    {
        

        static void Main(string[] args)
        {
            string name="Redip Biswas";

            //Console.BackgroundColor = ConsoleColor.Yellow;
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(name);

            Gender g1 = Gender.mail;
            Console.WriteLine(g1);
            Days d1 = Days.Friday;
            Console.WriteLine(d1);


            Console.ReadKey();
        } 



    }
}
