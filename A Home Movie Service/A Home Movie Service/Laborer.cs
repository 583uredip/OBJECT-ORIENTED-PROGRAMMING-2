using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Home_Movie_Service
{
    class Laborer:Employee
    {
        double userRating;
        const int chargePerService = 500;
         int noOfServices;

        public Laborer(string id, string name, string address, double userRating,int noOfServices) :base(id,name,address)
        {
            this.userRating = userRating;
            this.noOfServices = noOfServices;
        }

        public override bool EmployeeStatus()
        {
            if(userRating>70 && noOfServices>=10)
            {
                return true;
            }
            return false;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("----------Labor Information---------------");
            Console.WriteLine($"Laborer Id:{id}\nLaborer Name:{name}\nLaborer Address:{address}\nLabarer User Rating:{userRating}\nLaborer ChargePerSarvice:{chargePerService}\nLaborer NoofServices:{noOfServices}");
            Console.WriteLine("Eligible for Bonus: " + (EmployeeStatus() ? "Yes" : "No"));

        }
    }
}
