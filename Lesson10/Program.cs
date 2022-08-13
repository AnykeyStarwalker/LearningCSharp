using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Animal Svinja = new Animal();
            Console.WriteLine("Прикажи животному двигать на ");
            Svinja.Move(Console.ReadLine().ToString());
            Console.WriteLine("Животное пошло туда и сожрала что?");
            Svinja.Eat(Console.ReadLine().ToString());

            Console.WriteLine("Появился кабан.\n");
            BeastsClass Kaban = new BeastsClass();
            Kaban.Hunt("жолудь");


            Console.ReadKey();
        }
        
    }
}
