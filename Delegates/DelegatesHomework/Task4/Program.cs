using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public delegate int MyDelegate(int i);
    class Program
    {
        static int[] Method(int[] argArray, MyDelegate myDelegate)
        {
            int[] resultArray = new int[argArray.Length];
            for (int i = 0; i < argArray.Length; i++)
            {
                resultArray[i] = myDelegate(argArray[i]);               
            }
            return resultArray;
        }

        static int MethodArg(int i)
        {
            return i;
        }

        static void Main(string[] args)
        {
            int[] argArray = { 1, 2, 3 };
            MyDelegate myDelegate = MethodArg;
            int[] resultArray = Method(argArray, myDelegate);
            for (int i = 0; i < resultArray.Length; i++)
            {
                Console.WriteLine(resultArray[i]);
            }
            Console.ReadKey();
        }
    }
}
