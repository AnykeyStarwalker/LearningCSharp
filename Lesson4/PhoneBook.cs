using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Lesson4
{
    class PhoneBook
    {
        public FileInfo bookFile = new FileInfo(Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\subscribers.xml");
        public void mainLoop()
        {
            string key;
            UIText uiText = new UIText();
            
            UI_Draw(uiText.MenuInfo, null, ReadFile());
            do
            {
                var rand = new Random();
                key = Console.ReadKey(true).KeyChar.ToString();
                if (key == "1")
                {
                    UI_Draw(uiText.MenuInfo, uiText.Add);
                    AddSubscriber();
                }
                if (key == "2")
                {
                    UI_Draw(uiText.MenuInfo, null, ReadFile());
                }
                if (key == "3")
                {
                    UI_Draw(uiText.MenuInfo, uiText.Change, ReadFile());
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
            //Console.WriteLine("┌                                                                                   ┐");

            if (subList != null)
            {
                Console.WriteLine("\tId:\tИмя:\t\t\tНомер:");
                foreach (Subscriber subscriber in subList)
                {
                    if (subscriber.Name != "" || subscriber.PhoneNumber != "") { 
                    Console.WriteLine($"\t{subscriber.ID}\t{subscriber.Name}\t\t{subscriber.PhoneNumber}");
                    }
                }
            }
            //Console.WriteLine($"└                                                                                   ┘{Environment.NewLine}");
        }
        public IEnumerable<Subscriber> ReadFile()
        {            
            if (!bookFile.Exists)
            {                
                bookFile.Create();
                return null;
            }
            else
            {
                List<Subscriber> subscribers = new List<Subscriber>();
                XmlDocument subList = new XmlDocument();
                subList.Load(Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\subscribers.xml");
                XmlElement xRoot = subList.DocumentElement;
                if (xRoot != null)
                {
                    string id;
                    string name = "";
                    ref string xName = ref name;
                    string phoneNumber = "";
                    ref string xPhoneNumber = ref phoneNumber;
                    foreach (XmlElement xnode in xRoot)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("ID");
                        id = attr.Value;
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "name") xName = childnode.InnerText;
                            if (childnode.Name == "number") xPhoneNumber = childnode.InnerText;
                        }
                        subscribers.Add(new Subscriber(id, name, phoneNumber));
                    }
                }
                return subscribers;
            }
        }
        public void AddSubscriber()
        {
            string id;
            string name; 
            string phoneNumber;
            Console.WriteLine("Введите имя абонента...");
            name = Console.ReadLine();
            Console.WriteLine("Введите номер...");
            phoneNumber = Console.ReadLine();
            XmlDocument subList = new XmlDocument();
            subList.Load(Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\subscribers.xml");
            XmlElement xRoot = subList.DocumentElement;
            XmlNodeList elemList = xRoot.GetElementsByTagName("subscriber");
            id = (elemList.Count + 1).ToString();
            CreateXMLElement(id, name, phoneNumber);
            Console.WriteLine($"Абонент {name} успешно добавлен в телефонную книгу"); 
        }
        private void ChangeNumberOwner()
        {
            bool n = false;
            Console.WriteLine("Введите Id записи, которую хотите изменить...");
            
            List<Subscriber> subscribers = new List<Subscriber>();
            XmlDocument subList = new XmlDocument();
            subList.Load(Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\subscribers.xml");
            XmlElement xRoot = subList.DocumentElement;
            string xId = Console.ReadLine().ToString();
            foreach (XmlElement xnode in xRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("ID");
                if (attr.Value == xId)
                {                    
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name")
                        {
                            Console.WriteLine("Введите имя абонента...");
                            childnode.InnerText = Console.ReadLine().ToString();
                        }
                        if (childnode.Name == "number")
                        {
                            Console.WriteLine("Введите номер...");
                            childnode.InnerText = Console.ReadLine().ToString();
                        }
                    }
                    n = true;
                }
            }
            if (n)
            {
                subList.Save("subscribers.xml");
                Console.WriteLine("Запись изменена.");
            }
            else
            {
                Console.WriteLine("Запись по данному Id не найдена.");
            }
        }
        public void DeleteRecord()
        {
            string id;
            bool i = false;
            Console.WriteLine("Введите Id записи, которую хотите удалить...");
            id = Console.ReadLine().ToString();
            List<Subscriber> subscribers = new List<Subscriber>();
            XmlDocument subList = new XmlDocument();
            subList.Load(Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\subscribers.xml");
            XmlElement xRoot = subList.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("ID");
                if(attr.Value == id)
                {
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name") childnode.InnerText = "";
                        if (childnode.Name == "number") childnode.InnerText = "";
                    }
                    i = true;
                }
            }
            if (i) 
            {
                subList.Save("subscribers.xml");
                Console.WriteLine("Запись удалена."); 
            }
            else 
            { 
                Console.WriteLine("Запись по данному Id не найдена."); 
            }
        }
        public void CreateXMLElement(string id, string name, string phoneNumber)
        {
            XmlDocument subList = new XmlDocument();
            subList.Load(Path.GetFullPath(Directory.GetCurrentDirectory()) + "\\subscribers.xml");
            XmlElement xRoot = subList.DocumentElement;

            XmlElement personElem = subList.CreateElement("subscriber");
            XmlAttribute idAttr = subList.CreateAttribute("ID");
                XmlElement nameElem = subList.CreateElement("name");
                XmlElement numberElem = subList.CreateElement("number");

            XmlText idText = subList.CreateTextNode(id);
            XmlText nameText = subList.CreateTextNode(name);
            XmlText numberText = subList.CreateTextNode(phoneNumber);

            idAttr.AppendChild(idText);
                nameElem.AppendChild(nameText);
                numberElem.AppendChild(numberText);

            personElem.Attributes.Append(idAttr);
                personElem.AppendChild(nameElem);
                personElem.AppendChild(numberElem);

            xRoot?.AppendChild(personElem);
            subList.Save("subscribers.xml");
        }

    }
}