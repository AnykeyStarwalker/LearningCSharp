using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class Subscriber
    {
        /// <summary>
        /// Имя абонента
        /// </summary>
        private string name;
        public string Name { get { return name; } }
        /// <summary>
        /// Номер абонента
        /// </summary>
        private string phoneNumber;
        public string PhoneNumber 
        { 
            get { return phoneNumber; }  
            set { this.phoneNumber = value; }
        }

        public Subscriber(string name, string phoneNumber)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }   
    }
}
