using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Action();
            customer.PayBill();
 

        }
    }
    public delegate void OrderEventHandler(Customer customer, OrderEventArg e);
    public class OrderEventArg
    {
        public string Dishname { get; set; }
        public string Size { get; set; }
    }
   public class Customer
    {
        /*完整格式
        private OrderEventHandler orderEventHandler;

        public event OrderEventHandler Order
        {
            add
            {
                this.orderEventHandler += value;
            }
            remove
            {
                this.orderEventHandler -= value;
            }
        }
        */

        /*简略格式*/
        public event OrderEventHandler Order;
        public double Bill { get; set; }
        public void PayBill()
        {
            Console.WriteLine($"I will pay the {Bill} RMB");
        }

        public void Walkin()
        {
            Console.WriteLine("I have Arrived!");
        }
        public void Sitdown()
        {
            Console.WriteLine("Sit Down");
        }

        public void Think()
        {
            for (int i=0;i<5;i++)
            {
                Console.WriteLine("I am thinking.....");
                Thread.Sleep(1000);
            }
            /*完整声明
            if(this.orderEventHandler!=null)
            {
                OrderEventArg e = new OrderEventArg();
                e.Dishname = "SuanCaiYU";
                e.Size = "small";
                this.orderEventHandler.Invoke(this, e);
            }
            */

            /*简略声明*/
 
                OrderEventArg e = new OrderEventArg();
                e.Dishname = "SuanCaiYU";
                e.Size = "small";
                this.Order.Invoke(this, e);
           // if (this.Order != null)
           // { }
        }
        public void Action()
        {
            Console.ReadLine();
            this.Walkin();
            this.Sitdown();
            this.Think();
        }

    }


    public class Waiter
    {
        public void Action(Customer customer, OrderEventArg e)
        {
            Console.WriteLine($"I Will serve you the dish {e.Dishname}");
            double price = 10;
            switch (e.Size)
            {
                case "small":
                        price = price * 0.6;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;

        }

          
    }
}
