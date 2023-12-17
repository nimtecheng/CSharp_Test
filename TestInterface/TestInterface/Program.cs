using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaFactory = new PizzaFactory();
            var toycarFactory = new ToyCarFactory();
            WrapFactory wrapFactory = new WrapFactory();
            logger logger = new logger();
            Action<Product> log = new Action<Product>(logger.log);
          
            Box box1 = wrapFactory.WrapProduct(pizzaFactory, log);
            Box box2 = wrapFactory.WrapProduct(toycarFactory, log);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);


        }
    }
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }

    }

    class WrapFactory
    {
        public Box WrapProduct(IProductorFactory productorFactory,Action<Product> logCallback)
        {
            Box box = new Box();
            var product = productorFactory.Make();
            if (product.Price >= 50)
                logCallback(product);
            box.Product = product;
            return box;
        }
    }

    class logger
    {
        public void log(Product product)
        {
            Console.WriteLine($"Product {product.Name} created at{DateTime.UtcNow}.Price is {product.Price}");
        }
    }
    interface IProductorFactory
    {
        Product Make();
    }
    class PizzaFactory : IProductorFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Pizza";
            product.Price = 12;
            return product;
        }
    }
    class ToyCarFactory : IProductorFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product;
        }
    }
}
