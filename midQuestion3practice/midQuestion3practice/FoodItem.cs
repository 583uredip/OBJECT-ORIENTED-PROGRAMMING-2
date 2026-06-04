using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midQuestion3practice
{
    class FoodItem
    {
        public string itemName;
        public double basePrice;
        public FoodItem(string itemName,double basePrice)
        {
            this.itemName = itemName;
            this.basePrice = basePrice;
        }

        public virtual double CalculatePrice()
        {
            return basePrice;
        }
    }
}
