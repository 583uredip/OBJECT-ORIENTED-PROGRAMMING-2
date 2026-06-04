using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Home_Movie_Service
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee [] employee = new Employee[4];

            employee[0] = new Laborer("214251", "Redip", "Kustiha", 100.00,12);
            employee[1] = new Laborer("145987", "Prottoy", "Puran Dhaka", 8.00, 8);
            employee[2] = new Manager("58747", "Shad", "Rangpur", 10);
            employee[3] = new Manager("547825", "Abdulla", "Gagipur", 100);
            foreach(Employee emp in employee)
            {
                emp.ShowInfo();
            }

            Console.ReadLine();



        }
    }
}
