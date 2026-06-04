using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
       /* public static void Swap( ref int x, ref int y)
        {
               int temp = x;
                x = y;
                y = temp;
                Console.WriteLine("Inside the method x ={0} and y={1}", x, y);
            
        }*/

        static void Calculation(int x,int y,out int sum,out int sub,out int mul,out int div)
        {
            sum = x + y;
            sub = x - y;
            mul = x * y;
            div = x / y;
        }

        static void Print(int x,int y,params object [] num)//for use all data type...
        {
            Console.WriteLine("There are {0} number of elements", num.Length);
            for(int i=0;i<num.Length;i++)
            {
                Console.Write(num[i] + " , ");
                
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
           // int a = 20, b = 100,sum,sub,mul,div;
            /*Console.WriteLine("befor calling method a={0} and b={1}", a,b); 
            Swap( ref a, ref b);
            Console.WriteLine("After calling method a={0} and b={1}", a, b);
            Calculation(a, b,out sum,out sub,out mul,out div);
            Console.WriteLine(sum);
            Console.WriteLine(sub);
            Console.WriteLine(mul);
            Console.WriteLine(div);*/
            Print(50, 60);
            Print(100, 60, 89);
           // Print();
            Print(50, 100, 60,62,134);
            Print(1000, 9778, 6948);
            //Print("Redip", 2.098, "Rahul", 2.698D);
            Console.ReadKey();
        }
    }
}
