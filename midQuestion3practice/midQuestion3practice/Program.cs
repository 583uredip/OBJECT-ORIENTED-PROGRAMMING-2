using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midQuestion3practice
{
    class Program
    {
        static void Main(string[] args)
        {

            FoodItem[] items = new FoodItem[3];

            items[0] = new Pizza("Pepperoni Pizza", 3);
            items[1] = new Burger("Chicken Burger", false);
            items[2] = new Drink("7Up", "Large");

            foreach(FoodItem item in items)
            {
                item.CalculatePrice();
            }

            Console.ReadKey();

        }
    }
}
