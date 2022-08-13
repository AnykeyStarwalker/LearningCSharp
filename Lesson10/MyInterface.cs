using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10
{
    public interface IAnimal
    {
        void Eat(string korm);
        void Move(string napravlenie);
    }

    public interface IPet : IAnimal
    {
        void Name();
    }

    public interface IBeast : IAnimal
    {
        void Hunt(string huntObject);
    }

}
