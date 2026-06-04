using System;
using System.Linq;

namespace Switch_Case
{
    class All
    {
        static void Main(string[] args)
        {
            //Switch Case
            /* Console.Write("Enter Your Age:");
             int age = int.Parse(Console.ReadLine());
             switch(age)
             {
                 case int n when (n >= 1 && n <= 18):
                     Console.WriteLine("You Not Go To University");
                     break;
                 case int n when (n >18 && n<=25):
                     Console.WriteLine("You Go University");
                     break;
                 case int n when (n >= 26 && n <= 40):

                         Console.WriteLine("You Can Get Marid");
                     break;

                     case int n when ( n>=50 && n<=60):

                     Console.WriteLine("Rest For Job");

                     break;

                 case int n when (n >= 70 && n <= 100):
                     Console.WriteLine("Look towards God");
                     break;
                 default:
                     Console.WriteLine("Invalied Input");
                     break;


             }

             Console.ReadLine();*/

            //while loop
            /*int i = 1;
            while(i<10)
            {
                Console.WriteLine(i);
                i++;
            }
            Console.ReadLine();*/

            //Arrays
            /*string[] movie = { "Tufan", "Mr Been", "Tandob", "Paglu" };
            Console.WriteLine("Your Movie Names Are:");

            foreach (string name in movie)
            {
                Console.WriteLine("- " + name);
            }
            Console.WriteLine(movie[0]);
            movie[0] = "Jumanji";//change the array 
            Console.WriteLine(movie[0]);
            Console.WriteLine(movie.Length);
            Console.ReadLine();*/
            //Other Ways to Create an Array
            /*string[] university = new string[4] { "AIUB", "NSU", "Brac", "DU" };
            Console.WriteLine("------The Privave University Are-----");
            foreach (string name in university)
            {
                Console.WriteLine(name);
            }
            string[] game = new string[] { "Criket", "Footbal", "Batminton", "Ludo" };
            foreach (string name in game)
            {
                Console.WriteLine(name);
            }

            int[] num = { 1, 2, 3, 4, 5 };
            for(int i=0;i<num.Length;i++)
            {
                Console.WriteLine(num[i]);
            }
            //for each
            double[] cgpa = { 3.20, 3.45, 4.00, 3.95 };
            foreach(double name in cgpa)
            {
                Console.WriteLine(name);
            }*/

            /*int[] age = new int[] { 18, 69, 80, 21, 45 };
            foreach (int i in age)
            {
                Console.WriteLine("The Citigen Age:" + i);
            }

            //Sort Arrays
            int[] num = { 10, 8, 93, 45 };
            Array.Sort(num);
            foreach(int i in num)
            {
                Console.WriteLine(i);
            }
            string[] name = { "Rahul", "Basonti", "Redip", "Rabati", "Tirtho" };
            Array.Sort(name);
            foreach(string n in name)
            {
                Console.WriteLine(n);
            }    */

            /* int[] num = { 79, 10, 13, 343, 4555, 323 };

                 Console.WriteLine(num.Max());
                 Console.WriteLine(num.Min());
                 Console.WriteLine(num.Sum());*/

            //2D Array

            int[,] num = { { 1, 2, 35, 53, 32 },
                { 10, 89, 47, 46 ,89} };
            for(int i=0;i<num.GetLength(0);i++)
            {
                for(int j=0;j<num.GetLength(1);j++)
                {
                    Console.Write(num[i, j] + "\t");
                    
                }
                Console.WriteLine();
            }

            


            Console.ReadKey();
        }

    }
}
