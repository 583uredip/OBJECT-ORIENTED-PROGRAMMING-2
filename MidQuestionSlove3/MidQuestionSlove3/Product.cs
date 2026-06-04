using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuestionSlove3
{
     public class Product
    {


        public string id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public DateType productDate;
        public double price_Info { get; set; }


        public Product(string id,string name, DateType productDate, int quantity, double price_Info)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.productDate = productDate;
            this.price_Info = price_Info;
        }
            
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Id:{id},Name:{name},Quantity{quantity},Date:{productDate},Price:{price_Info}");
        }

        public virtual void TotalBill()
        {
            double total = quantity * price_Info;
            Console.WriteLine("Total Bill"+total);
        }


    }
}
