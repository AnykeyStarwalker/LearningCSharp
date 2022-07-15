using System;
using System.Threading;
using System.Collections.Generic;


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
            
            Sounds.GameStartSound();
        Start_game:

            int counter = 0;
            for (int i = 0; i < arrArea.GetLength(0); i++) {
                for (int j = 0; j < arrArea.GetLength(1); j++)
                {
                    if (arrArea[i, j] == 0) {
                        ++counter;
                    }
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"\tKPeCTuKu - HOJIuKu by AnykeyStarwalker{Environment.NewLine}{Environment.NewLine}" +
                              $"yIIpaBJIeHue: BbI6op KJIetKu - cTpeJIKu, cdeJIaTb xod - IIpo6eJI, BBod - Ha4aTb 3aHoBo.{Environment.NewLine}" +
                              $"ocTaJlocb XodoB: {counter}");
            if(counter == 0)
            {
                Console.Clear();
                Console.WriteLine("He ocTaJlocb xodoB. Ha}|{MuTe AnyKey...");
                Console.ReadKey(true);
                goto New_game;
            }

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
                        
                        if(arrArea[playerCoord[0], playerCoord[1]] == 0)
                        {
                            arrArea[playerCoord[0], playerCoord[1]] = 1;
                            Sounds.DropSound();
                            //возврат строки для завершения игры
                            Console.WriteLine(CpuPlayer.WinWon(arrArea));
                            CpuPlayer.StepAnalise(arrArea);
                            Console.WriteLine(CpuPlayer.WinWon(arrArea));
                        }
                        else
                        {
                            Sounds.Error();
                        }
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
            Console.Beep(587, 50);
            Console.Beep(587, 150);
        }
        public static void WinSound()
        {
            Console.Beep(523, 100);
            Console.Beep(587, 100);
            Console.Beep(659, 100);
            Console.Beep(698, 100);
            Console.Beep(659, 100);
            Console.Beep(698, 500);
        }
        public static void GamoverSound()
        {
            Console.Beep(698, 100);
            Console.Beep(659, 100);
            Console.Beep(698, 100);
            Console.Beep(659, 100);
            Console.Beep(587, 500);
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
                        s_2 += "¤ X   X ¤";
                        s_3 += "¤   X   ¤";
                        s_4 += "¤ X   X ¤";
                        s_5 += "¤ ¤ ¤ ¤ ¤";
                    }
                    else if(arrArea[i, j] == 1)
                    {

                        s_1 += "· · · · ·";
                        s_2 += "· X   X ·";
                        s_3 += "·   X   ·";
                        s_4 += "· X   X ·";
                        s_5 += "· · · · ·";

                    }
                    else if (arrArea[i, j] == 2 && playerCoord[0] == i && playerCoord[1] == j)
                    {
                        s_1 += "¤ ¤ ¤ ¤ ¤";
                        s_2 += "¤  o0o  ¤";
                        s_3 += "¤ 0   0 ¤";
                        s_4 += "¤  o0o  ¤";
                        s_5 += "¤ ¤ ¤ ¤ ¤";
                    }
                    else if (arrArea[i, j] == 2)
                    {

                        s_1 += "· · · · ·";
                        s_2 += "·  o0o  ·";
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
    public class CpuPlayer
    {
        public static int[,] StepAnalise(int[,] arrArea)
        {
            int x = 1;
            List<int> area_x = new List<int>();
            List<int> area_y = new List<int>();
            for (int i = 0; i < arrArea.GetLength(0); i++)
            {
                for (int j = 0; j < arrArea.GetLength(1); j++)
                {
                    if (arrArea[i, j] == 0)
                    {
                        area_x.Add(i);
                        area_y.Add(j);
                    }
                }
            }
            var rand = new Random();
            if(area_x.Count > 0)
            {
                x = rand.Next(area_x.Count);
                arrArea[area_x[x], area_y[x]] = 2;
            }


            return arrArea;
        }
        public static string WinWon(int[,] arrArea)
        {
            string msg = "Next step...";
            if(arrArea[0,0] == 1 && arrArea[0, 1] == 1 && arrArea[0, 2] == 1)
            {
                msg = "Player_1 Win!!!";
                Sounds.WinSound();
                KeyControls.KeyPress();
            }
            else if(arrArea[1, 0] == 1 && arrArea[1, 1] == 1 && arrArea[1, 2] == 1)
            {
                msg = "Player_1 Win!!!";
                Sounds.WinSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[2, 0] == 1 && arrArea[2, 1] == 1 && arrArea[2, 2] == 1)
            {
                msg = "Player_1 Win!!!";
                Sounds.WinSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[2, 0] == 1 && arrArea[2, 1] == 1 && arrArea[2, 2] == 1)
            {
                msg = "Player_1 Win!!!";
                Sounds.WinSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 0] == 1 && arrArea[1, 1] == 1 && arrArea[2, 2] == 1)
            {
                msg = "Player_1 Win!!!";
                Sounds.WinSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 2] == 1 && arrArea[1, 1] == 1 && arrArea[2, 0] == 1)
            {
                msg = "Player_1 Win!!!";
                Sounds.WinSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 0] == 1 && arrArea[1, 0] == 1 && arrArea[2, 0] == 1)
            {
                msg = "Player_1 Win!!!";
                Sounds.WinSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 1] == 1 && arrArea[1, 1] == 1 && arrArea[2, 1] == 1)
            {
                msg = "Player_1 Win!!!";
                Sounds.WinSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 2] == 1 && arrArea[1, 2] == 1 && arrArea[2, 2] == 1)
            {
                msg = "Player_1 Win!!!";
                //Player1 finish
            }
            if (arrArea[0, 0] == 2 && arrArea[0, 1] == 2 && arrArea[0, 2] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[1, 0] == 2 && arrArea[1, 1] == 2 && arrArea[1, 2] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[2, 0] == 2 && arrArea[2, 1] == 2 && arrArea[2, 2] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[2, 0] == 2 && arrArea[2, 1] == 2 && arrArea[2, 2] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 0] == 2 && arrArea[1, 1] == 2 && arrArea[2, 2] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 2] == 2 && arrArea[1, 1] == 2 && arrArea[2, 0] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 0] == 2 && arrArea[1, 0] == 2 && arrArea[2, 0] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 1] == 2 && arrArea[1, 1] == 2 && arrArea[2, 1] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
            }
            else if (arrArea[0, 2] == 2 && arrArea[1, 2] == 2 && arrArea[2, 2] == 2)
            {
                msg = "Compukter Win!!! Press Enter to play again";
                Sounds.GamoverSound();
                KeyControls.KeyPress();
                //звук, пресаникей, нажмите ввод
            }

            return msg;
        }
    }
}
