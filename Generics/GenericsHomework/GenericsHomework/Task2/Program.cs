using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Contr
{
    class Program
    {
        public abstract class Person { }
        public class Student : Person { }

        public interface IUnik<in T>
        {
            T Somebody { set; }
        }

        public class Unik<T> : IUnik<T>
        {
            private T somebody;
            public Unik(T somebody)
            {
                this.somebody = somebody;
            }
            public T Somebody
            {
                set { somebody = value; }
            }
        }
        static void Main(string[] args)
        {
            Person person = new Student();
            IUnik<Student> unik = new Unik<Person>(person);

        }
    }
}
