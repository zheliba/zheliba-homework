using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public delegate int MyDelegate(string number);
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate myDelegate = (number) =>
            {
                int result = 0;
                if (int.TryParse(number, out int tempResult))
                {
                    int hundreads = tempResult / 100;
                    int tens = (tempResult - hundreads * 100) / 10;
                    int units = tempResult % 10;
                    result = tens * 100 + units * 10 + hundreads;
                }

                return result;
            };

            Console.WriteLine(myDelegate(Console.ReadLine()));
            Console.ReadKey();
        }
    }
}
