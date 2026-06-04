using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midQuestion3practice
{
    class Pizza:FoodItem
    {
        int numberOfToppings;

        public Pizza(string itemName,int numberOfToppings) :base(itemName,50)
        {
            this.numberOfToppings = numberOfToppings;
        }

        public override double CalculatePrice()
        {
            double total = basePrice + (numberOfToppings * 50);
            Console.WriteLine("Pizza:" + itemName);
            Console.WriteLine("Number Of Toppings:" +numberOfToppings);
            Console.WriteLine("Total Price:" +total);
            Console.WriteLine("--------------------------");
            return total;
        }

    }
}
