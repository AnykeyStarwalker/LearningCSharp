using System;
using System.Threading;


namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
        New_game:
            //inicialise
            int[] playerCoord = { 1, 1 };
            int[,] arrArea = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            int counter = 0;
            Sounds.GameStartSound();
        Start_game: 

            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"\tKPeCTuKu - HOJIuKu by AnykeyStarwalker{Environment.NewLine}{Environment.NewLine}" +
                              $"yIIpaBJIeHue: BbI6op KJIetKu - cTpeJIKu, cdeJIaTb xod - IIpo6eJI, BBod - Ha4aTb 3aHoBo.{Environment.NewLine}");

            GameArea.DrawArea(arrArea, playerCoord);
            ++counter;
            switch (KeyControls.KeyPress())
            {
                case ("New_game"):
                {
                goto New_game;
                }
                case ("Spacebar"):
                    {
                        arrArea[playerCoord[0], playerCoord[1]] = 1;
                        break;
                    }
                case ("Left"):
                    {
                        if (playerCoord[1] > 0)
                        {
                            playerCoord[1] -= 1;
                            Sounds.TickSound();
                            break;
                        }
                        else
                        {
                            Sounds.Error();
                            break;
                        }

                    }
                case ("Right"):
                    {
                        if (playerCoord[1] < 2)
                        {
                            playerCoord[1] += 1;
                            Sounds.TickSound();
                            break;
                        }
                        else
                        {
                            Sounds.Error();
                            break;
                        }
                    }
                case ("Up"):
                    {
                        if (playerCoord[0] > 0)
                        {
                            playerCoord[0] -= 1;
                            Sounds.TickSound();
                            break;
                        }
                        else
                        {
                            Sounds.Error();
                            break;
                        }
                    }
                case ("Down"):
                    {
                        if (playerCoord[0] < 2)
                        {
                            playerCoord[0] += 1;
                            Sounds.TickSound();
                            break;
                        }
                        else
                        {
                            Sounds.Error();
                            break;
                        }
                    }

            }
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
            Console.Beep(261, 50);
            Console.Beep(392, 100);
        }
        public static void GameStartSound()
        {
            Console.Beep(523, 200);
            Console.Beep(587, 200);
            Console.Beep(659, 200);
            Console.Beep(698, 500);
        }
        public static void Error()
        {
            Console.Beep(132, 150);
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
                    return "Left";
                case ("RightArrow"):
                    Console.WriteLine("A key is: RightArrow    ");
                    return "Right";
                case ("UpArrow"):
                    Console.WriteLine("A key is: UpArrow       ");
                    return "Up";
                case ("DownArrow"):
                    Console.WriteLine("A key is: DownArrow     ");
                    return "Down";
                case ("Spacebar"):
                    Console.WriteLine("A key is: Spacebar      ");
                    Sounds.DropSound();
                    return "Spacebar";
                case ("Enter"):
                    Console.WriteLine("A key is: Enter         ");
                    Sounds.DropSound();
                    return "New_game";
            }
            return key;
        }
    }
    public class GameArea
    {
        public static string DrawArea(int[,] arrArea, int[] playerCoord)
        {
            string area = "";
            string s_1, s_2, s_3, s_4, s_5;

            
            for (int i = 0; i < arrArea.GetLength(0); i++)
            {
                s_1 = "\t";
                s_2 = "\t";
                s_3 = "\t";
                s_4 = "\t";
                s_5 = "\t";

                for (int j = 0; j < arrArea.GetLength(1); j++)
                {
                    if(arrArea[i, j] == 0 && playerCoord[0] == i && playerCoord[1] == j)
                    {
                        
                        s_1 += "¤ ¤ ¤ ¤ ¤";
                        s_2 += "¤       ¤";
                        s_3 += "¤       ¤";
                        s_4 += "¤       ¤";
                        s_5 += "¤ ¤ ¤ ¤ ¤";
                        
                    }
                    else if(arrArea[i, j] == 0)
                    {
                        s_1 += "· · · · ·";
                        s_2 += "·       ·";
                        s_3 += "·       ·";
                        s_4 += "·       ·";
                        s_5 += "· · · · ·";
                    }
                    else if (arrArea[i, j] == 1 && playerCoord[0] == i && playerCoord[1] == j)
                    {
                        s_1 += "¤ ¤ ¤ ¤ ¤";
                        s_2 += "¤ x   x ¤";
                        s_3 += "¤   x   ¤";
                        s_4 += "¤ x   x ¤";
                        s_5 += "¤ ¤ ¤ ¤ ¤";
                    }
                    else if(arrArea[i, j] == 1)
                    {

                        s_1 += "· · · · ·";
                        s_2 += "· x   x ·";
                        s_3 += "·   x   ·";
                        s_4 += "· x   x ·";
                        s_5 += "· · · · ·";

                    }
                    else if (arrArea[i, j] == 2)
                    {

                        s_1 += "· · · · ·";
                        s_2 += "·  o0o ·";
                        s_3 += "· 0   0 ·";
                        s_4 += "·  o0o  ·";
                        s_5 += "· · · · ·";

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
    public class Player_1
    {
        public static int PlayerCoord(int x = 1, int y = 1)
        {
            return x;
        }
    }
}
