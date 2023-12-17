using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testAsyncThreads
{

    class Program
    {
        static Stopwatch sw = new Stopwatch();

        static void log(string message)
        {
            Console.WriteLine($"{sw.ElapsedMilliseconds}:{message} by Thread:{Thread.CurrentThread.ManagedThreadId}");
        }

        static void Main1(string[] args)
        {
            sw.Start();
            log("Main() Started!");
            Console.WriteLine("Synchronization context is {0}set",
                   SynchronizationContext.Current == null ? "not " : "");
            var t = getResult().Result;
            log($"got result:{t}");
            log("Main() is Ended!");
            Console.ReadKey();

        }
        static async Task Main(string[] args)
        {
            sw.Start();
            log("Main() Started!");
            Console.WriteLine("Synchronization context is {0}set",
                   SynchronizationContext.Current == null ? "not " : "");
            await DoWork1();
            //await Task.Run(() => { Thread.Sleep(100); log("in awaiting...."); });
            log("Main() is Ended!");
            Console.ReadKey();

        }

        public static async Task<int> getResult()
        {
            await Task.Delay(1000);
            log("get result is about to return");
            return 10;
        }
        public static async Task DoWork1()
        {
            log("DoWork1() is started！");
            Thread.Sleep(1000);
            //await Task.Run(() =>
            //{
            //    log("This work is Done in DoWork1()");
            //    Thread.Sleep(1000);
            //});
            await DoWork2();
            Thread.Sleep(100);
            log("DoWork1() is ended！");
        }

        public static async Task  DoWork2()
        {
            //Thread.Sleep(1000);
            Task.Run(() =>
             {
                 log("DoWork2() is Started!!");
                 Thread.Sleep(1000);
             });
            await Task.Yield();
            log("DoWork2() is ended！");
        }


    }
}
