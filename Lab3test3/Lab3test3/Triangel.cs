using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3test3
{
    class Triangel
    {
        int x, y, z;
        public Triangel(int x,int y,int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Side X:{x}\n Slide Y:{y}\n Slide Z:{z}");
        }

        public void TestTriangle()
        {
            if(x==y && y==z)
            {
                Console.WriteLine("Triangle is Equilateral");
            }
            else if(x==y || y==z|| x==z)
            {
                Console.WriteLine("Triangle is Isosceles");
            }
            else
            {
                Console.WriteLine("Triangle is Scalene");
            }
            Console.WriteLine();
        }
        
    }
}
