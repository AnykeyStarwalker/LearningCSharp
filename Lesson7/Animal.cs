using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class Animal
    {
        private int legsCount;
        private int tailsCount;
        private int lifeLimit;
        private string animalVoice;
        private string animalName;

        public int animalsCount = 0;

        public Animal(int legsCount = 0, int tailsCount = 0, int lifeLimit = 0, string animalVoice = "Xpy-xpy", string animalName = "Noname")
        {
            this.legsCount = legsCount;
            this.tailsCount = tailsCount;
            this.lifeLimit = lifeLimit;
            this.animalVoice = animalVoice;
            this.animalName = animalName;
            animalsCount++;
        }
        public void Shout()
        {
            Console.WriteLine($"{this.animalName} say {this.animalVoice}");
        }
    }

    public abstract class Creature
    {
        public abstract string name
        {
            get; set;
        }
        public void Name(string newName)
        {
            this.name = newName;
        }
    }

    public class Ameba : Creature
    {
        public override string name 
        {
            get;set;
           // get => throw new NotImplementedException(); 
           // set => throw new NotImplementedException(); 
        }
        public void Name(string newName)
        {
            this.name = newName;
        }
        public string getName()
        {
            return this.name;
        }
    }
}
