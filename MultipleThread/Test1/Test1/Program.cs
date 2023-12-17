using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {

      static  void Main(string[] args)
        {

            Console.WriteLine($"{DateTime.Now.ToString()} Main method on {Thread.CurrentThread.ManagedThreadId} Started!");
            //Task.Run(() =>
            //{
            //    //Thread.Sleep(2000);
            //    Console.WriteLine($"{DateTime.Now.ToString()} anysc main method on {Thread.CurrentThread.ManagedThreadId} and executed over!");

            //});

            var task = asyncMethod1();
            task.Wait();
            commonMethod1();       
        }
    
    
    
     public static async Task asyncMethod1()
        {
            Console.WriteLine($"{DateTime.Now.ToString()} Method1 is a async method on {Thread.CurrentThread.ManagedThreadId} Started!");

            Thread.Sleep(2000);
            await commonMethod2();
            Console.WriteLine($"{DateTime.Now.ToString()} Method1 is a async method on {Thread.CurrentThread.ManagedThreadId} and executed over!");


        }

        static void  commonMethod1()
        {


            Console.WriteLine($"{DateTime.Now.ToString()} Common Method is a Common Method1 on {Thread.CurrentThread.ManagedThreadId} and executed over!");
        }

        static Task commonMethod2()
        {

            var task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"{DateTime.Now.ToString()} Common Method is a Common Method2 on {Thread.CurrentThread.ManagedThreadId} and executed over!");

            });
            
            return task;
            
        }
    }
}
