using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    public class Animal : IAnimal
    {
        public void Eat(string korm)
        {
            Console.WriteLine($"Ням-ням... Йа покушало {korm}.");
        }
        public void Move(string napravlenie)
        {
            Console.WriteLine($"Йа подвигалось в сторону {napravlenie}.");
        }
    }
    public class BeastsClass : Animal, IBeast
    {

        public void Hunt(string huntObject) 
        {
            Console.WriteLine($"Йа ахочусь!... Охочусь на {huntObject}");
        }
    }
}
