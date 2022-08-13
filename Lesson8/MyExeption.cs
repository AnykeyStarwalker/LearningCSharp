using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    class MyExeption : Exception
    {
        public MyExeption(string message): base(message) { }
    }
}
