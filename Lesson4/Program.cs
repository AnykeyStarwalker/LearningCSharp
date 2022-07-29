using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PhoneBook;


namespace Lesson4
{
    class Program
    {
        /// <summary>
        /// Создает экземпляр класса PhoneBook и запускает цикл
        /// </summary>
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.mainLoop();
        }
    }
}
