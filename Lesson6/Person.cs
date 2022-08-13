using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    internal class Person
    {
        public string name;
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }
        public void PrintName()
        {
            Console.WriteLine(this.Name);
        }
    }
}
