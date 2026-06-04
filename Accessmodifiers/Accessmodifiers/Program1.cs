using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessmodifiers
{//Case 1:Within the class; no restriction 
  public  class Program1 //class er jono sudu public and internall ei 2 ta e apply korte parbo c# e...
    {
        public void Test1()
        {
            Console.WriteLine("public test method ");
        }
        private void Test2()// jodi kono accessmodifiers na takhe oi ta private hisabe count hobe 
                             //defalt hole internal
        {
            Console.WriteLine("private test method ");
        }
        protected void Test3()
        {
            Console.WriteLine("protected test method ");
        }
           internal void Test4()
            {
                Console.WriteLine("internal test method ");
            }
        protected internal void Test5()
        {
            Console.WriteLine("protected internal  test method ");
        }
        private protected void Test6()
        {
            Console.WriteLine(" private protected test method ");
        }

        static void Main(string[] args)
        {
            Program1 p = new Program1();
            p.Test1();
            p.Test2();
            p.Test3();
            p.Test4();
            p.Test5();
            p.Test6();
            Console.ReadKey();

        }
    }
}
