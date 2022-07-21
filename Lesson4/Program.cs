using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PhoneBook;


namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {            
            PhoneBook PB = new PhoneBook();
            string key;
            do
            {
                PB.UI_DrawHat();
                key = Console.ReadKey(true).KeyChar.ToString();
                if (key == "1")
                {
                    PB.helpInfo = $"|             1 - Добавить абонента. 2 - Поиск. 3 - Сделать звонок.             |{Environment.NewLine}" +
                                  $"| Введите телефонный номер, затем ФИО абонента или название организации.        |{Environment.NewLine}" +
                                  $"| Пример: 8(123)456-78-90 Пупкин Иван Петрович; 112 Спасатели.                  |";
                }
                if (key == "2")
                {
                    PB.helpInfo = $"|             1 - Добавить абонента. 2 - Поиск. 3 - Сделать звонок.             |{Environment.NewLine}" +
                                  $"| Начните вводить имя абонента или номер телефона...                            |";
                }
                if (key == "3")
                {
                    PB.helpInfo = $"|             1 - Добавить абонента. 2 - Поиск. 3 - Сделать звонок.             |{Environment.NewLine}" +
                                  $"| Набираем случайный номер... Упс! Похоже на АТС замкнул коммутационный шкаф... |";
                }
            }
            while (key != "Escape");
            



        }
    }

    class PhoneBook
    {
        const string bookName    = "Т Е Л Е Ф О Н Н Ы Й   С П Р А В О Ч Н И К";
        const string horzBorder  = "¤ - - - - - - - - - ¤ - - - - - - - - - ¤ - - - - - - - - - ¤ - - - - - - - - - ¤";
        public string helpInfo   = "|             1 - Добавить абонента. 2 - Поиск. 3 - Сделать звонок.             |";
        string n = Environment.NewLine;
        string spaces;
        public void UI_DrawHat()
        {
            string horB = $"";
            spaces = "";
            for(int i = 0; i < ((horzBorder.Length - bookName.Length) / 2) - 1; ++i) { spaces += " "; }
            Console.SetCursorPosition(0, 0);
            Console.Write(
                $"{horzBorder}{n}" +
                $"|{spaces}{bookName}{spaces}|{n}" +
                $"{helpInfo}{n}" +
                $"{horzBorder}{n}" +
                $"|                                                                               |{n}" +
                $"{horzBorder}{n}"
                );

        }
        public void AddAbonent(int newPhone, string newName, string newSurname = null, string newSecondname = null)
        {
            string name;
            string surname;
            string secondname;
            int phoneNumber;
        }
    }
}
