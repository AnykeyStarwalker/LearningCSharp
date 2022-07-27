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
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.mainLoop();
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
            var subscribersList = new Dictionary<string, string>();
            XmlDocument subList = new XmlDocument();
            subList.Load($"{Path.GetFullPath(Directory.GetCurrentDirectory() + "\\..\\..\\")}subscribers.xml");
            XmlElement xRoot = subList.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    string name = "";
                    string number = "";
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    name = attr.Value;

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "number"){ number = childnode.InnerText; }
                    }

                    subscribersList.Add(name, number);
                }
            }
            foreach (var person in subscribersList)
            {
                Console.WriteLine($"key: {person.Key}  value: {person.Value}");
            }

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
