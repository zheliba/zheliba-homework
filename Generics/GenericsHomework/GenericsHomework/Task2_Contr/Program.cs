using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Contr
{
    class Product { }
    class Laptop : Product { }
    class Program
    {
        delegate void MyDelegate<in T>(T being);

        public static void UseLaptop(Product product)
        {
            Console.WriteLine(product.GetType().Name);
        }

        static void Main(string[] args)
        {
            MyDelegate<Product> delegateProduct = new MyDelegate<Product>(UseLaptop);
            MyDelegate<Laptop> delegateLaptop = delegateProduct;

            delegateProduct(new Product());
            delegateLaptop(new Laptop());
            Console.ReadKey();
        }
    }
}
