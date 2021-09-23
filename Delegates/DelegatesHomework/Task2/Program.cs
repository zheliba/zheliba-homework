using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public delegate int MyDelegate(char character, string text);
    public class Program
    {
        public static int CountCharacters(char c, string text)
        {
            int counter = 0;
            foreach (char character in text)
            {
                if (character == c) counter++;
            }

            return counter;
        }

        public static int FindCharacter(char c, string text)
        {
            int charPosition = 0;
            foreach (char character in text)
            {
                charPosition++;
                if (character == c) break;
                if (charPosition == text.Length) charPosition = -1;
            }
            return charPosition;
        }
        static void Main(string[] args)
        {
            MyDelegate myDelegate = CountCharacters;
            Console.WriteLine(myDelegate('p', "pipka"));

            myDelegate = FindCharacter;
            Console.WriteLine(myDelegate('p', "skripka"));
            Console.ReadKey();
        }
    }
}
