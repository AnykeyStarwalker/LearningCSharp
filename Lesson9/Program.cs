using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    delegate void Message();
    internal class Program
    {

        static void Main(string[] args)
        {
            Message mes;
            mes = Hello;
            mes += Godbye;
            mes += WaitInput;
            mes.Invoke();

            void Hello() => Console.WriteLine("ПРивет, дмашняя папкаю");
            void Godbye() => Console.WriteLine("Пока, делегат");
            void WaitInput() => Console.ReadKey();
        }
    }
}
