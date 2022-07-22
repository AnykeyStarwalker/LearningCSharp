using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Lesson5
{
    internal class Program
    {
        private readonly static string filePath = Path.Combine(Assembly.GetExecutingAssembly().Location);
        public static void Main(string[] args)
        {
            var numbers = new[] {1, 2,3, 4,5,6,7,8,9 };
            for (int i = 0; i < numbers.Length; i++) {
                var a = numbers[i] + 1;
                Console.WriteLine(numbers[i]);
                Console.WriteLine(a);
            }
        }
    }
}
