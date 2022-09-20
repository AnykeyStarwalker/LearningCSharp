using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 4.	Абстрактный класс. 
///     Создать абстрактный класс Animal с методами и полями/свойствами свойственными животным.
///		    - Создать несколько реализаций настоящих животных.
/// </summary>

namespace Lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainLoop myProgram = new MainLoop();
            myProgram.Run();
        }
    }
    public class MainLoop
    {
       
        public void Run()
        {
            string key = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Hello, this is program about <T> class. Please, press any key...\n");
                key = Console.ReadKey(true).Key.ToString();

                var anything = new MassiveDynamic(new[]{
                    new Elem<object>(new[] { "sss" }), new Elem<object>(new[] { "aaa" }), new Elem<object>(123)
                });

                Console.WriteLine(anything[0]);

            }
            while (key != "Escape");
            this.Run();

        }

    }

    class AnimalList
    {

    }

}
