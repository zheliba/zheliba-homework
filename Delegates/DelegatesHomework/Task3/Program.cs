using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    delegate void MyDelegate(char c);
    class MyObject
    {
        public char character;
        public void SetC (char c)
        {
            character = c;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myObject1 = new MyObject();
            var myObject2 = new MyObject();
            var myObject3 = new MyObject();
            MyObject[] myObjects = { myObject1, myObject2, myObject3 };
            MyDelegate myDelegate = null;

            foreach (var myObject in myObjects)
            {
                myDelegate += myObject.SetC;
            }
            myDelegate('x');

            foreach (var myObject in myObjects)
            {
                Console.WriteLine(myObject.character);
            }
            Console.ReadKey();
        }
    }
}
