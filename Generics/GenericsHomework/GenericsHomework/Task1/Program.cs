using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Cov
{
    class Program
    {
        public abstract class Person { }
        public class Student : Person { }

        public interface IUnik< out T>
        {
            T Somebody { get; }
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
                get { return somebody; }
            }
        }
        static void Main(string[] args)
        {
            Student student = new Student();
            IUnik<Person> unik = new Unik<Student>(student);

        }
    }
}
