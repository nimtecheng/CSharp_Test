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
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();
            logger logger = new logger();
            Action<Product> log = new Action<Product>(logger.log);
            Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);
            Box box1 = wrapFactory.WrapProduct(func1,log);
            Box box2 = wrapFactory.WrapProduct(func2,log);
           
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
        public Box WrapProduct(Func<Product> getproduct,Action<Product> logCallback)
        {
            Box box = new Box();
            var product = getproduct.Invoke();
            if (product.Price >= 50)
                logCallback(product);
            box.Product = product;
            return box;
        }
    }
        class ProductFactory
        {
            public Product MakePizza()
            {
                Product product = new Product();
                product.Name = "Pizza";
                product.Price = 12;
                return product;
            }
            public Product MakeToyCar()
            {
                Product product = new Product();
                product.Name = "Toy Car";
                product.Price = 100;
                return product;
            }
        }
    class logger 
    {
        public void log(Product product)
        {
            Console.WriteLine($"Product {product.Name} created at{DateTime.UtcNow}.Price is {product.Price}");
        }
    }
}
