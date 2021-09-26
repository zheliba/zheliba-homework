using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswersPractice
{
    delegate R MyDelegate<T, R>(T t);
    class GenericClass<T, K>
    {
        public T Field { get; set; }
        void ReturnType(K k)
        {
            Console.WriteLine(k.GetType());
        }

        public string WriteLetter (string name)
        {
            return $"Hello, {name}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericClass<int, string> instance1 = new GenericClass<int,string>();
            MyDelegate<string, string> myDelegate = new MyDelegate<string, string>(instance1.WriteLetter);
            Console.WriteLine(myDelegate("Peter"));
        }
    }
}
