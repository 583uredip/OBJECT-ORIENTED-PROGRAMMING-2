using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceaAPP
{
    class Inheritance
    {
        static void Main(string[] args)
        {

            /* Dog d = new Dog();
             d.Eat();
             Dog d1 = new Dog();
             d1.Brak();
             d1.MakeSound();
             Cat c1 = new Cat();
             c1.MakeSound();
             Console.ReadKey();
             Tomy t = new Tomy();*/
            Person p = new Person("Redip", 22);
            Employee e = new Employee("Prottoy", 24);
            p.DisplayPersonInfo();
            e.DisplayPersonInfo();
            Console.ReadKey();
        }
    }
    /*class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating....");
        }
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a generic sound");
        }
    }
    class Dog:Animal
    {
        public void Brak()
        {
            Console.WriteLine("Braking......");
        }
        public override void MakeSound()
        {
            base.MakeSound();
            Console.WriteLine("Geu Geu");
        }
    }
    
    class Cat:Animal
    {
        public void Maiu()
        {
            Console.WriteLine("Cat is miauing");
        }
    }
    class Tomy:Dog
    {
        public void GoingNuts()
        {
            Console.WriteLine("Collie going Nuts.....");
        }
    }*/
   
}
