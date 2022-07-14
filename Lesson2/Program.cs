using System;


namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
        Start_game:

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Build and go!");
            Console.WriteLine(counter);
            var keyPressed = Console.ReadKey(true).Key;
            Console.WriteLine(keyPressed + "                             ");
            //Console.ReadLine();
            ++counter;
            
            goto Start_game;
        }
    }
}
