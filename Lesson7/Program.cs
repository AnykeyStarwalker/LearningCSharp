using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal Pork = new Animal(4, 1, 3, "Xpuy-xrouy", "Svinja");
            Pork.Shout();
            Pork.Shout();
            Pork.Shout();
            Animal Dog = new Animal(4, 1, 10, "Gau-Gau!!!", "Sobaka_1");
            Animal CheloDog = new Animal(2, 2, 10, "Abyr-abyr! Abybvalk!", "Poligraf Poligrafovich");

            Dog.Shout();
            CheloDog.Shout();
            CheloDog.Shout();
            Pork.Shout();
            Dog.Shout();
            CheloDog.Shout();

            Ameba Ameba_1 = new Ameba();
            Ameba_1.Name("rioeh09");
            Console.WriteLine(Ameba_1.getName());
            



            Console.ReadKey();
        }
    }
}
