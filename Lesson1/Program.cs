using System;

public sealed class MyProgram
{
    public static void Main()
    {
        string mes_1 = "Hello, world!";
        string mes_2 = "Git changes";
        string mes_petc = "Press Enter to close...";

        Console.WriteLine($"{mes_1}");
        Console.WriteLine($"{mes_2}");
        Console.WriteLine($"{mes_petc}\a");
        Console.ReadLine();

    }
}
