using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midQuestion3practice
{
    class Drink:FoodItem
    {
        string size;
        public Drink(string itemName,string size):base(itemName,50)
        {
            this.size = size;
        }

        public override double CalculatePrice()
        {
            double total = basePrice;
            if(size=="Medium")
            {
                total += 20;
            }
            else if(size=="Large")
            {
                total += 40;
            }
            Console.WriteLine("Drink:" +itemName);
            Console.WriteLine("Size:" +size);
            Console.WriteLine("Total Price:" +total);
            return total;
        }
    }
}
