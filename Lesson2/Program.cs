using System;
using System.Threading;


namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            Sounds.GameStartSound();
        Start_game:
                        
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Build and go!");
            Console.WriteLine(counter);
            
            

            KeyControls.KeyPress();
            ++counter;
                       
            goto Start_game;
        }
    }

    public class Sounds
    {
        public static void TickSound()
        {
            Console.Beep(5587, 100);
            //Thread.Sleep(150);
        }
        public static void DropSound()
        {
            Console.Beep(130, 100);
        }
        public static void GameStartSound()
        {
            Console.Beep(523, 200);
            Console.Beep(587, 200);
            Console.Beep(659, 200);
            Console.Beep(698, 500);
        }
    }
    public class KeyControls
    {

        public static string KeyPress()
        {
            string key = Console.ReadKey(true).Key.ToString();
            //Console.WriteLine(key);
            switch (key)
            {
                case ("LeftArrow"):
                    Console.WriteLine("A key is: LeftArrow     ");
                    Sounds.TickSound();
                    break;
                case ("RightArrow"):
                    Console.WriteLine("A key is: RightArrow    ");
                    Sounds.TickSound();
                    break;
                case ("UpArrow"):
                    Console.WriteLine("A key is: UpArrow       ");
                    Sounds.TickSound();
                    break;
                case ("DownArrow"):
                    Console.WriteLine("A key is: DownArrow     ");
                    Sounds.TickSound();
                    break;
                case ("Spacebar"):
                    Console.WriteLine("A key is: Spacebar      ");
                    Sounds.DropSound();
                    break;
                case ("Enter"):
                    Console.WriteLine("A key is: Enter         ");
                    Sounds.DropSound();
                    break;
            }
            return key;
        }
    }
}
