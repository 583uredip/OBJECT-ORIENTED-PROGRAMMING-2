using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherSimulator
{
    class Weather
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter The Of Days To Simulate");
            int days = int.Parse(Console.ReadLine());
            int[] tem = new int[days];
            string[] conditions = { "Suny", "Rainy", "Cloudy", "Snowy" };
            string[] weatherConditions = new string[days];

            Random ramdom = new Random();
            for (int i = 0; i < days; i++)
            {
                tem[i] = ramdom.Next(-10, 40);
                weatherConditions[i] = conditions[ramdom.Next(conditions.Length)];

            }
            Console.WriteLine($"Average Temperature is:{ CalculateAverage(tem)}");
            Console.WriteLine($"The max temp was:{tem.Max()}");
            Console.WriteLine($"The min temp was:{tem.Min()}");
            Console.ReadKey();
        }
            static double CalculateAverage(int[] te)
            {
                double sum = 0;
                for(int i=0;i<te.Length;i++)
                {
                    sum += te[i];
                }

                double avg = sum / te.Length;
                return avg;

           
        }

        static int MinTemperature(int [] temp)
        {
            int min = temp[0];
            foreach(int tem in temp)
            {
                if(tem<min)
                {
                    min = tem;
                }
            }
            return min;
        }



           

        
    }
}
