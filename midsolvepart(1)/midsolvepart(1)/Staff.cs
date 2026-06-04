using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midsolvepart_1_
{
    class Staff
    {
        string name;
        int stf_id;
        double salary;
        public Staff()
        {
            name = "";
            stf_id =0;
            salary = 0.00;

        }
        public Staff(string name,int stf_id,double salary)
        {
           this. name = name;
           this.stf_id = stf_id;
           this.salary = salary;
        }
        public void display_info()
        {
            Console.WriteLine($"Staff name: {name}");
            Console.WriteLine($"Staff id:{stf_id}");
            Console.WriteLine($"Staff salary:{salary}");
            Console.WriteLine("------------------------");

        }
        static void Main(string[] args)
        {
            Staff s = new Staff();
            Staff s2 = new Staff("Preonty Kundu", 10, 1000.697);
            s.display_info();
            s2.display_info();
            Console.ReadKey();
        }
    }
}
