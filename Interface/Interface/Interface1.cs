using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface ITest1
    {
        //defalt pubblic/abstract
      void print();
      void  print1();
      void print2();
    }

    interface ITest2 
    {
        void print();
        void print3();
        void print4();
    }

    class Test3:ITest1,ITest2
    {
         void ITest1.print()//explisive
        {
            Console.WriteLine("I am Form Test 1 Interfase");
        }
        void ITest2.print()
        {
            Console.WriteLine("I am From Test 2 Interfase");
           
        }
        public void print1()
        {
            Console.WriteLine("Print 1 ");
        }
        public void print2()
        {
            Console.WriteLine("Print 2 ");
        }
        public void print3()
        {
            Console.WriteLine("Print 3 ");

        }
        public void print4()
        {

            Console.WriteLine("Print 4 ");
        }
    }
    
}
