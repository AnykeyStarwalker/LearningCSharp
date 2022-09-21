using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    class Subscriber
    {
        public Dictionary<string, string> SubData = new Dictionary<string, string>();

        public void Add(string name, string number) 
        {
            this.SubData.Add("name", name);
            this.SubData.Add("number", number);
        }
        public string ShowName()
        {
            return this.SubData["name"];
        }
        public string ShowNumber()
        {
            return this.SubData["number"];
        }
    }
    class MassiveDynamic
    {
        Elem<string>[] elem;

        public MassiveDynamic(Elem<string>[] newElem) => elem = newElem;
        ///- Добавление элемента в список.
        public void AddElem() 
        {
            //Elem<string> newElem = new Elem<string>("eeewww");

           /* var anything = new MassiveDynamic(new[]
            {
                new Elem<object>(new[] { "sss" }), new Elem<object>(new[] { "aaa" }), new Elem<object>(123)
            });

            Console.WriteLine(anything[0]);*/
        }
		///- Удаление элемента по индексу.
        public void DelByIndex()
        {

        }
		///- Удаление элемента, если он есть в списке.
        public void DelBySearch()
        {

        }
		///- Получение количества элементов.
        public int CountElem()
        {
            return 0;
        }
        
        public Elem<string> this[int index]
        {
            get => elem[index];
            set => elem[index] = value;
        }
        
    }
}
