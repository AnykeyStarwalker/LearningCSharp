using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class Subscriber
    {

        private string phoneNumber;
        private string name;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { this.phoneNumber = value; }
        }
        public string Name 
        { 
            get { return name; } 
        }
        public Subscriber(string name = null, string phoneNumber = null)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

    }
}