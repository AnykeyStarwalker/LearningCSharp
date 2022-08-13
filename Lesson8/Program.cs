using System;
using System.Collections.Generic;

namespace Lesson8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start:
            string userInput = string.Empty;
            Console.WriteLine($"Введите фразу{Environment.NewLine}");
            try
            {
                userInput = Console.ReadLine();
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine($"Какая-то ошибка... {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
            goto Start;
        }
    }
}
