using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism1
{
    class Parant
    {
        public virtual void Name()
        {
            Console.WriteLine("My name is Redip");
        }
    }
    class Child : Parant
    {
        public sealed override void Name()
        {
            Console.WriteLine("My name is preonty");
        }


    }
    class Child2 : Child
    {
        //public override void Name()
        //{
        //    Console.WriteLine("My name is Rahul");
        //}
        static void Main(string[] args)
        {
            Child c = new Child();
            c.Name();
            Child2 c2 = new Child2();
            c2.Name();
            //Child c1 = (Child) new Parant();
            Parant p = new Child();
            //Child2 c3 = (Child2)p;
            if(p is Child)
            {
                Console.WriteLine("P is a Child instant");
                Child c4 = (Child)p;
            }
            else if(p is Child2)
            {
                Console.WriteLine("P is a Child2 instant");
                Child2 c4 = (Child2)p;
            }
            Console.ReadKey(); 

        }
    }


}
