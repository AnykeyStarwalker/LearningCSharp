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
        static void Main(string[] args)
        {
            PhoneBook PB = new PhoneBook();
            Abonent newAbon = new Abonent();
            string key;
            List<Subscriber> subscribers = new List<Subscriber>();
            do
            {
                PB.UI_DrawHat();
                var rand = new Random();
                key = Console.ReadKey(true).KeyChar.ToString();
                if (key == "1")
                {
                    PB.helpInfo = $"|             1 - Добавить абонента. 2 - Поиск. 3 - Сделать звонок.             |{Environment.NewLine}" +
                                  $"| Введите телефонный номер, затем имя абонента или название организации.        |{Environment.NewLine}" +
                                  $"| Пример: 8(123)456-78-90 Пупкин Иван Петрович; 112 Спасатели.                  |";
                }
                if (key == "2")
                {
                    PB.helpInfo = $"|             1 - Добавить абонента. 2 - Поиск. 3 - Сделать звонок.             |{Environment.NewLine}" +
                                  $"| Начните вводить имя абонента или номер телефона...                            |";
                    newAbon.Read();
                    Subscriber sub = new Subscriber("Iiiiigor", "123456789");
                    Console.WriteLine(sub.Name);
                    Console.WriteLine(sub.PhoneNumber);
                }
                if (key == "3")
                {
                    PB.helpInfo = $"|             1 - Добавить абонента. 2 - Поиск. 3 - Сделать звонок.             |{Environment.NewLine}" +
                                  $"| Набираем случайный номер... Упс! Похоже на АТС замкнул коммутационный шкаф... |";
                
                    for(int i = 0; i < 100; i++)
                    {
                        
                        string randNum = rand.Next(000000000, 999999999).ToString();
                        subscribers.Add(new Subscriber("TeleBot", randNum));
                    }
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine();
                    Console.WriteLine(subscribers.Count);
                    foreach(Subscriber subscriber in subscribers)
                    {
                        Console.WriteLine($"{subscriber.Name} {subscriber.PhoneNumber}");
                    }
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

    }

    class Abonent
    {

        public int phoneNumber { get; set; }
        public string name { get; set; }
        public void Create(int newPhone, string newName)
        {
            this.phoneNumber = newPhone;
            this.name = newName;
            //записать в документ
        }
        public void Read()
        {
            //Console.WriteLine($"{(this.phoneNumber).ToString()} {this.name}");
            XmlDocument subList = new XmlDocument();
            subList.Load($"{Path.GetFullPath(Directory.GetCurrentDirectory() + "\\..\\..\\")}subscribers.xml");
            XmlElement xRoot = subList.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    Console.Write($"Имя: {attr.Value} ");

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "number")
                        {
                            Console.Write($"Номер: {childnode.InnerText}{Environment.NewLine}");
                        }
                    }
                }
            }

            var abonentsList = new Dictionary<int, string>();
        }
        public void Update()
        {
            Console.WriteLine($"{(this.phoneNumber).ToString()} {this.name}");
        }
        public void Delete()
        {
            Console.WriteLine($"{(this.phoneNumber).ToString()} {this.name}");
        }

    }
}
