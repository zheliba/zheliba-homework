using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Cov
{
    class Product { }
    class Laptop : Product { }

    class Program
    {
        delegate T MyDelegate<out T>();

        public static Laptop LaptopCreator()
        {
            return new Laptop();
        }
        static void Main(string[] args)
        {
            MyDelegate<Laptop> delegateLaptop = new MyDelegate<Laptop>(LaptopCreator);
            MyDelegate<Product> delegateProduct = delegateLaptop;

            Product product = delegateProduct();
        }
    }
}
