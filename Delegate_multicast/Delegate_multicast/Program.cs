using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate_multicast
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
            Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green};
            Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };
            Action action1 = new Action(stu1.DoHomeWork);
            Action action2 = new Action(stu2.DoHomeWork);
            Action action3 = new Action(stu3.DoHomeWork);
            //   action1 += action2;
            //  action1 += action3;
            /*  
               action1.BeginInvoke(null,null);
               action2.BeginInvoke(null, null);
            action3.BeginInvoke(null, null);
            */
            /*
            Thread thread1 = new Thread(new ThreadStart(stu1.DoHomeWork));
            Thread thread2 = new Thread(new ThreadStart(stu2.DoHomeWork));
            Thread thread3 = new Thread(new ThreadStart(stu3.DoHomeWork));  
            thread1.Start();
            thread2.Start();
            thread3.Start();
            */
            Task task1 = new Task(new Action(stu1.DoHomeWork));
            Task task2 = new Task(new Action(stu2.DoHomeWork));
            Task task3 = new Task(new Action(stu3.DoHomeWork));
            
            task1.Start();
            task2.Start();
            task3.Start();

            //action1.Invoke();
            // action2.Invoke();
            // action3.Invoke();
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Mainthread {i}, thread ID is {Thread.CurrentThread.ManagedThreadId}");
            }

        }
    }
    class Student
    {
        public int ID { get; set; }
        public ConsoleColor PenColor { get; set; }
        public void DoHomeWork()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine($"Student{ID} doing homework{i} hour(s),ID:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000); 
            }
        }
    }
}
