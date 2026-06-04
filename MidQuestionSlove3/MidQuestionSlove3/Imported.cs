using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionSlove3
{
   public  class Imported:Product
    {
        public Imported(string id, string name, DateType productDate, int quantity, double price_Info):base(id, name, productDate, quantity, price_Info)
        {

        }

        public override void TotalBill()
        {
            double total = quantity * price_Info;
            total += total * 0.15;

            Console.WriteLine("Imported Bill:"+total);
        }
    }
}
