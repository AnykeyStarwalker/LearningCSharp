using System;
using System.Threading;
using System.Collections.Generic;

namespace RefactoringXO
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLoop.GameStart();
        }
    }

    public class GameLoop
    {
        public static void GameStart()
        {
            int i = 0;
            string key = "";
            do
            {
                GameMode();
            }
            while (key != "Escape");
            GameStart();
        }
        public static void GameMode()
        {
            string key = "";
            int mode = 1;
            Console.Clear();
            Console.WriteLine($"Выбор режима игры: ← →, Enter.");
            Console.WriteLine($"ИГРОК ПРОТИВ: КОМПЬЮКТЕРА\t\t");
            do
            {
                key = Console.ReadKey(true).Key.ToString();
                if (key == "LeftArrow")
                {
                    mode = 1;
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine($"ИГРОК ПРОТИВ: КОМПЬЮКТЕРА\t\t");
                    Sounds.TickSound();
                }
                if (key == "RightArrow")
                {
                    mode = 2;
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine($"ИГРОК ПРОТИВ: ИГРОКА\t\t");
                    Sounds.TickSound();
                }
            } while (key != "Enter" && mode == 1 || key != "Enter" && mode == 2);

            if (mode == 1)
            {
                Console.Write(
                   $"¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤\n" +
                    "¤          M O D E          ¤\n" +
                    "¤     PLAYER VS COMPUCTOR   ¤\n" +
                    "¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤");
                Sounds.DropSound();
                Thread.Sleep(1000);
                GameLoop.PlayerVsCpu();
            }
            if (mode == 2)
            {
                Console.WriteLine("¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤");
                Console.WriteLine("¤          M O D E          ¤");
                Console.WriteLine("¤      PLAYER VS PLAYER     ¤");
                Console.WriteLine("¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤ ¤");
                Sounds.DropSound();
                Thread.Sleep(1000);
                GameLoop.PlayerVsPlayer();
            }

        }
        public static void PlayerVsCpu()
        {
            string[,] mainArea = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
            int[] curPos = new int[2] { 0, 0 };
            string key = "";
            string symb = "x";
            string gameMode = "PVC";
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("ИГРОК ПРОТИВ КОМПУКТЕРА");
            Console.WriteLine("Let's start!");
            GameArea.DrawArea(mainArea, curPos);
            Sounds.GameStartSound();
            do
            {
                GameArea.DrawArea(mainArea, curPos);
                key = Console.ReadKey(true).Key.ToString();
                if (key == "Enter") { PlayerVsCpu(); }
                switch (key)
                {
                    case ("LeftArrow"): { Console.Beep(880, 50); if (curPos[0] > 0) { --curPos[0]; } break; }
                    case ("RightArrow"): { Console.Beep(880, 50); if (curPos[0] < 2) { ++curPos[0]; } break; }
                    case ("UpArrow"): { Console.Beep(880, 50); if (curPos[1] > 0) { --curPos[1]; } break; }
                    case ("DownArrow"): { Console.Beep(880, 50); if (curPos[1] < 2) { ++curPos[1]; } break; }

                }
                if (key == "Spacebar")
                {
                    Console.Beep(349, 50);
                    GameArea.DrawArea(NextStep(mainArea, curPos, symb), curPos);
                    CheckWin(mainArea, symb);
                    if (symb == "x")
                    {
                        symb = "o";
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Ход игрока \" {symb} \" \t");
                    }
                    else
                    {
                        symb = "x";
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Ход игрока \" {symb} \" \t");
                    }
                    Console.SetCursorPosition(0, 0);
                    GameArea.DrawArea(CpuSI.SimpleRandStep(mainArea), curPos);
                    CheckWin(mainArea, symb);
                    if (symb == "x")
                    {
                        symb = "o";
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Ход игрока \" {symb} \" \t");
                    }
                    else
                    {
                        symb = "x";
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine($"Ход игрока \" {symb} \" \t");
                    }
                }
            } while (key != "Escape");
            GameStart();
            Thread.Sleep(2000);
        }
        public static void PlayerVsPlayer()
        {
            string[,] mainArea = new string[3, 3] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };
            int[] curPos = new int[2] { 0, 0 };
            string key = "";
            string symb = "x";
            string gameMode = "PVP";
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("ИГРОК ПРОТИВ ИГРОКА");
            Console.WriteLine("Начинают \" х \"");
            GameArea.DrawArea(mainArea, curPos);
            Sounds.GameStartSound();
            do
            {
                GameArea.DrawArea(mainArea, curPos);
                key = Console.ReadKey(true).Key.ToString();
                if (key == "Enter") { PlayerVsPlayer(); }
                switch (key)
                {
                    case ("LeftArrow"): { Console.Beep(880, 50); if (curPos[0] > 0) { --curPos[0]; } break; }
                    case ("RightArrow"): { Console.Beep(880, 50); if (curPos[0] < 2) { ++curPos[0]; } break; }
                    case ("UpArrow"): { Console.Beep(880, 50); if (curPos[1] > 0) { --curPos[1]; } break; }
                    case ("DownArrow"): { Console.Beep(880, 50); if (curPos[1] < 2) { ++curPos[1]; } break; }
                    case ("Spacebar"):
                        {
                            Console.Beep(349, 50);
                            GameArea.DrawArea(NextStep(mainArea, curPos, symb), curPos);
                            CheckWin(mainArea, symb);
                            if (symb == "x")
                            {
                                symb = "o";
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine($"Ход игрока \" {symb} \" \t");
                            }
                            else
                            {
                                symb = "x";
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine($"Ход игрока \" {symb} \" \t");
                            }
                            break;
                        }

                }
            } while (key != "Escape");
            GameStart();
        }
        public static void CheckWin(string[,] mainArea, string symb)
        {
            short horz = 0;
            short vert = 0;
            short diag = 0;
            short diag_2 = 0;
            short count = 0;
            int i = 0;

            for (int row = mainArea.GetLength(1) - 1; row >= 0; row--)
            {
                if (mainArea[i, row] == symb) { ++diag_2; } else { diag_2 = 0; }
                i++;
            }
            if (diag_2 == 3) Console.WriteLine($"{Environment.NewLine}Победили {symb} по-диагонали снизу-вверх{Environment.NewLine}\"Enter\" - ирать еще раз. \"Escape\" - сброс.");

            for (int row = 0; row < mainArea.GetLength(0); row++)
            {
                for (int col = 0; col < mainArea.GetLength(1); col++)
                {
                    if (mainArea[row, col] == symb) { ++horz; } else { horz = 0; }
                    if (mainArea[col, row] == symb) { ++vert; } else { vert = 0; }
                }
                if (mainArea[row, row] == symb) { ++diag; } else { diag = 0; }
                if (horz == 3) Console.WriteLine($"{Environment.NewLine}Победили {symb} по-горизонтали{Environment.NewLine}\"Enter\" - ирать еще раз. \"Escape\" - сброс.");
                if (vert == 3) Console.WriteLine($"{Environment.NewLine}Победили {symb} по-вертикали{Environment.NewLine}\"Enter\" - ирать еще раз. \"Escape\" - сброс.");
                if (diag == 3) Console.WriteLine($"{Environment.NewLine}Победили {symb} по-диагонали сверху-вниз{Environment.NewLine}\"Enter\" - ирать еще раз. \"Escape\" - сброс.");
            }
            for (int row = 0; row < mainArea.GetLength(0); row++)
            {
                for (int col = 0; col < mainArea.GetLength(1); col++)
                {
                    if (mainArea[row, col] == " ") ++count;
                }
            }
            if (count == 0 & horz != 3 & vert != 3 & diag != 3 & diag_2 != 3) Console.WriteLine($"{Environment.NewLine}Ничья - не осталось ходов.{Environment.NewLine}\"Enter\" - ирать еще раз. \"Escape\" - сброс.");
        }
        public static string[,] NextStep(string[,] mainArea, int[] curPos, string symb)
        {
            if (mainArea[curPos[1], curPos[0]] == " ") mainArea[curPos[1], curPos[0]] = symb;
            return mainArea;
        }

    }
    public class GameArea
    {

        public static void DrawArea(string[,] mainArea, int[] curPos)
        {
            string area = "";
            string s_1, s_2, s_3, s_4, s_5;
            //Console.SetCursorPosition(8, 3);
            Console.SetCursorPosition(0, 3);
            for (int row = 0; row < mainArea.GetLength(0); row++)
            {

                s_1 = "\t";
                s_2 = "\t";
                s_3 = "\t";
                s_4 = "\t";
                s_5 = "\t";
                //
                for (int col = 0; col < mainArea.GetLength(1); col++)
                {

                    if (mainArea[row, col] == "x")
                    {
                        if (curPos[0] == col && curPos[1] == row)
                        {
                            s_1 += "¤ ¤ ¤ ¤ ¤";
                            s_2 += "¤ X   X ¤";
                            s_3 += "¤   X   ¤";
                            s_4 += "¤ X   X ¤";
                            s_5 += "¤ ¤ ¤ ¤ ¤";
                            //Console.Write("{X}"); 
                        }
                        else
                        {
                            s_1 += "· · · · ·";
                            s_2 += "· X   X ·";
                            s_3 += "·   X   ·";
                            s_4 += "· X   X ·";
                            s_5 += "· · · · ·";
                            //Console.Write("[X]"); 
                        }
                    }
                    else if (mainArea[row, col] == "o")
                    {
                        if (curPos[0] == col && curPos[1] == row)
                        {
                            s_1 += "¤ ¤ ¤ ¤ ¤";
                            s_2 += "¤  o0o  ¤";
                            s_3 += "¤ 0   0 ¤";
                            s_4 += "¤  o0o  ¤";
                            s_5 += "¤ ¤ ¤ ¤ ¤";
                            //Console.Write("{O}"); 
                        }
                        else
                        {
                            s_1 += "· · · · ·";
                            s_2 += "·  o0o  ·";
                            s_3 += "· 0   0 ·";
                            s_4 += "·  o0o  ·";
                            s_5 += "· · · · ·";
                            //Console.Write("[O]"); 
                        }
                    }
                    else
                    {
                        if (curPos[0] == col && curPos[1] == row)
                        {
                            s_1 += "¤ ¤ ¤ ¤ ¤";
                            s_2 += "¤       ¤";
                            s_3 += "¤       ¤";
                            s_4 += "¤       ¤";
                            s_5 += "¤ ¤ ¤ ¤ ¤";
                            //Console.Write("{ }"); 
                        }
                        else
                        {
                            s_1 += "· · · · ·";
                            s_2 += "·       ·";
                            s_3 += "·       ·";
                            s_4 += "·       ·";
                            s_5 += "· · · · ·";
                            //Console.Write("[ ]"); 
                        }
                    }


                }
                Console.Write($"{s_1}{Environment.NewLine}");
                Console.Write($"{s_2}{Environment.NewLine}");
                Console.Write($"{s_3}{Environment.NewLine}");
                Console.Write($"{s_4}{Environment.NewLine}");
                Console.Write($"{s_5}{Environment.NewLine}");
            }
        }
    }

    public class CpuSI
    {
        public static string[,] SimpleRandStep(string[,] mainArea)
        {
            int x = 1;
            List<int> area_x = new List<int>();
            List<int> area_y = new List<int>();
            for (int i = 0; i < mainArea.GetLength(0); i++)
            {
                for (int j = 0; j < mainArea.GetLength(1); j++)
                {
                    if (mainArea[i, j] == " ")
                    {
                        area_x.Add(i);
                        area_y.Add(j);
                    }
                }
            }
            var rand = new Random();
            if (area_x.Count > 0)
            {
                x = rand.Next(area_x.Count);
                mainArea[area_x[x], area_y[x]] = "o";
            }


            return mainArea;
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
}