using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midQuestion3practice
{
    class Burger:FoodItem
    {
        bool extraCheese;
        public Burger(string itemName,bool extraCheese):base(itemName,50)
        {
            this.extraCheese = extraCheese;
        }

        public override double CalculatePrice()
        {
            double total = basePrice;
            if(extraCheese)
            {
                total += 30;
            }

            Console.WriteLine("Burger:"  +itemName);
            Console.WriteLine("Extra Cheese:" +extraCheese);
            Console.WriteLine("Total Price:"  +total);
            Console.WriteLine("--------------------------");

            return total;

        }
    }
}
