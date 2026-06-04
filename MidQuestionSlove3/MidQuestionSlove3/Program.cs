using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionSlove3
{
    class Program
    {
        static void Main(string[] args)
        {

            Product[] prd = new Product[3];
            prd[0] = new Local("P-001", "Soap", new DateType(12, 09, 2023), 150, 200);
            prd[1] = new Local("P-002", "Toothpaste", new DateType(21, 11, 2023), 95, 70);
            prd[2] = new Imported("P-003", "Shampoo", new DateType(09, 08, 2023), 120, 500);

            foreach(Product p in prd)
            {
                p.ShowInfo();
                p.TotalBill();
            }
            Console.ReadKey();

        }
    }
}
