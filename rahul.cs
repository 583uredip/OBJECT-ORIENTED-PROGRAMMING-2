using  System;
namespace Sum
{
    class Rahul
    {
        static void Main(string[] args)
        {
            int age=20;
            Console.WriteLine("My age is: " + age);
            double height=5.9;
            int myheight=(int)height;
            Console.WriteLine("My height is: " + myheight);
            Console.WriteLine(Convert.ToString("My Age is: " + age));
            Console.WriteLine("Enter your age:");
            string name=Console.ReadLine();
            Console.WriteLine("Your Name is:"+name);
            Console.WriteLine("Enter your height:");
            string height1=Console.ReadLine();
            Console.WriteLine("Your Height is:"+height1);
            Console.WriteLine("Enter your university name:");
            string university=Console.ReadLine();
            Console.WriteLine("Your University is:"+university);
            int x=10,y=20;
            if(x>y)
            {
                Console.WriteLine("X is greater than Y");
            }
            else
            {
                Console.WriteLine("Y is greater than X");
            }
            x++;
            y--;
            Console.WriteLine("X after increment: " + x);
            Console.WriteLine("Y after decrement: " + y);
            for(int i=1;i<=5;i++)
            {
                Console.WriteLine("Iteration: " + i);
            }
            if(age>=18 && age<=25)
            {
                Console.WriteLine("You are eligible for the program.");
            }
            else
            {
                Console.WriteLine("You are not eligible for the program.");
            }
    }
}
}