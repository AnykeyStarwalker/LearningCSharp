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
            Console.WriteLine($"\tKPeCTuKu - HOJIuKu by AnykeyStarwalker{Environment.NewLine}{Environment.NewLine}" +
                              $"yIIpaBJIeHue: BbI6op KJIetKu - cTpeJIKu, cdeJIaTb xod - IIpo6eJI, BBod - Ha4aTb 3aHoBo.{Environment.NewLine}");

            GameArea.DrawArea();
            //Console.WriteLine(counter);
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
    public class GameArea
    {
        public static string DrawArea()
        {
            string area = "";

            string[,] drawArea = new string[5, 5] { 
                {"+","-","-","-","+"},
                {"|"," "," "," ","|"},
                {"|"," "," "," ","|"},
                {"|"," "," "," ","|"},
                {"+","-","-","-","+"} 
            };

            string s_1, s_2, s_3, s_4, s_5;

            int[,] arrArea = new int[3, 3] { { 0, 1, 1 },{ 2, 0, 2 },{ 1, 2, 0 } };
            for (int i = 0; i < arrArea.GetLength(0); i++)
            {
                s_1 = "\t";
                s_2 = "\t";
                s_3 = "\t";
                s_4 = "\t";
                s_5 = "\t";

                for (int j = 0; j < arrArea.GetLength(1); j++)
                {
                    if(arrArea[i, j] == 0)
                    {
                        drawArea[2, 2] = " ";
                        s_1 += $"{drawArea[0, 0]}{drawArea[0, 1]}{drawArea[0, 2]}{drawArea[0, 3]}{drawArea[0, 4]}";
                        s_2 += $"{drawArea[1, 0]}{drawArea[1, 1]}{drawArea[1, 2]}{drawArea[1, 3]}{drawArea[1, 4]}";
                        s_3 += $"{drawArea[2, 0]}{drawArea[2, 1]}{drawArea[2, 2]}{drawArea[2, 3]}{drawArea[2, 4]}";
                        s_4 += $"{drawArea[3, 0]}{drawArea[3, 1]}{drawArea[3, 2]}{drawArea[3, 3]}{drawArea[3, 4]}";
                        s_5 += $"{drawArea[4, 0]}{drawArea[4, 1]}{drawArea[4, 2]}{drawArea[4, 3]}{drawArea[4, 4]}";
                    }
                    else if(arrArea[i, j] == 1)
                    {
                        drawArea[2, 2] = "X";
                        s_1 += $"{drawArea[0, 0]}{drawArea[0, 1]}{drawArea[0, 2]}{drawArea[0, 3]}{drawArea[0, 4]}";
                        s_2 += $"{drawArea[1, 0]}{drawArea[1, 1]}{drawArea[1, 2]}{drawArea[1, 3]}{drawArea[1, 4]}";
                        s_3 += $"{drawArea[2, 0]}{drawArea[2, 1]}{drawArea[2, 2]}{drawArea[2, 3]}{drawArea[2, 4]}";
                        s_4 += $"{drawArea[3, 0]}{drawArea[3, 1]}{drawArea[3, 2]}{drawArea[3, 3]}{drawArea[3, 4]}";
                        s_5 += $"{drawArea[4, 0]}{drawArea[4, 1]}{drawArea[4, 2]}{drawArea[4, 3]}{drawArea[4, 4]}";

                    }
                    else if (arrArea[i, j] == 2)
                    {
                        drawArea[2, 2] = "O";
                        s_1 += $"{drawArea[0, 0]}{drawArea[0, 1]}{drawArea[0, 2]}{drawArea[0, 3]}{drawArea[0, 4]}";
                        s_2 += $"{drawArea[1, 0]}{drawArea[1, 1]}{drawArea[1, 2]}{drawArea[1, 3]}{drawArea[1, 4]}";
                        s_3 += $"{drawArea[2, 0]}{drawArea[2, 1]}{drawArea[2, 2]}{drawArea[2, 3]}{drawArea[2, 4]}";
                        s_4 += $"{drawArea[3, 0]}{drawArea[3, 1]}{drawArea[3, 2]}{drawArea[3, 3]}{drawArea[3, 4]}";
                        s_5 += $"{drawArea[4, 0]}{drawArea[4, 1]}{drawArea[4, 2]}{drawArea[4, 3]}{drawArea[4, 4]}";

                    }

                    
                }

                Console.Write($"{s_1}{Environment.NewLine}");
                Console.Write($"{s_2}{Environment.NewLine}");
                Console.Write($"{s_3}{Environment.NewLine}");
                Console.Write($"{s_4}{Environment.NewLine}");
                Console.Write($"{s_5}{Environment.NewLine}");


            }


            return area;
        }
    }
}
