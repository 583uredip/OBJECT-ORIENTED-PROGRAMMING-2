using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class
{


    abstract class Parant
    {
        public abstract void updateEmployee();
        public void ShowOne()
        {
            Console.WriteLine("Show 1");
        }
        public abstract void ShowTow();
        public abstract void ShowThree();
        public abstract void ShowFour();



    }

    class Child : Parant
    {
        public override void updateEmployee()
        {
            Console.WriteLine("Updated");
        }
        public override void ShowTow()
        {
            Console.WriteLine("Show 2");
        }

        public override void ShowThree()
        {
            Console.WriteLine("Show 3");
        }
        public override void ShowFour()
        {
            Console.WriteLine("Show 4");
        }
        /* public abstract void ShowFive();
         public abstract void ShowSix();
         public abstract void ShowSeven();*/

    }








    class Program
    {
        static void Main(string[] args)
        {

            Child c = new Child();
            c.ShowOne();
            c.ShowThree();
            c.ShowTow();
            Console.ReadKey();

        }
    }

}