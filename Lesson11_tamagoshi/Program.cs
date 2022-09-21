using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11_tamagoshi
{
    class Program
    {
        static void Main(string[] args)
        {
            static string Draw(string p = "▒▒")
            {
                string screen = string.Empty;
                for (int v = 0; v < 28; v++)
                {
                    for (int h = 0; h < 58; h++) 
                    {
                        screen += p;
                    }

                    screen += $"{Environment.NewLine}";
                }

                return screen;
            }
            // ░░ ▒▒ ▓▓ ██- пиксели

            Console.WriteLine(Draw());
            Console.ReadKey();
        }
    }
}
                         