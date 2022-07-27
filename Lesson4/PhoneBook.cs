using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson4
{
    class PhoneBook
    {
        private string filePath = Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\subscribers.xml";
        public void mainLoop()
        {
            string key;
            UIText uiText = new UIText();
            Subscriber sub = new Subscriber();
            List<Subscriber> subscribers = new List<Subscriber>();
            UI_Draw(uiText.MenuInfo);
            do
            {
                var rand = new Random();
                subscribers.Clear();
                key = Console.ReadKey(true).KeyChar.ToString();
                if (key == "1")
                {
                    UI_Draw(uiText.MenuInfo, uiText.Read);
                    ReadFile();
                }
                if (key == "2")
                {
                    UI_Draw(uiText.MenuInfo, uiText.Add);
                    AddSubscriber();
                }
                if (key == "3")
                {
                   /* for (int i = 0; i < 10; i++)
                    {
                        string randNum = rand.Next(100000000, 999999999).ToString();
                        subscribers.Add(new Subscriber("TeleBot", randNum));
                    }*/
                    UI_Draw(uiText.MenuInfo, uiText.Change, subscribers);
                    ChangeNumberOwner();
                }
                if (key == "4")
                {
                    UI_Draw(uiText.MenuInfo, uiText.Delete);
                    DeleteRecord();
                }
            }
            while (key != "Escape");
            mainLoop();
        }
        public void UI_Draw(string helpInfo, string textInfo = null, IEnumerable<Subscriber> subList = null)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write(helpInfo);
            Console.WriteLine("┌                                                                                   ┐");
            if (textInfo != null) 
            { 
                Console.Write(textInfo); 
            }
            if (subList != null)
            {
                foreach (Subscriber subscriber in subList)
                {
                    Console.WriteLine($"{subscriber.Name} {subscriber.PhoneNumber}");
                }
            }
            Console.WriteLine($"└                                                                                   ┘{Environment.NewLine}");
        }
        public void ReadFile()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл существует. Вывести содержимое.");
            }
            Console.WriteLine("ReadFile");
        }
        public void AddSubscriber()
        {
            Console.WriteLine("AddSubscriber");
        }
        public void ChangeNumberOwner()
        {
            Console.WriteLine("ChangeNumberOwner");
        }
        public void DeleteRecord()
        {
            Console.WriteLine("DeleteRecord");
        }
    }
}
