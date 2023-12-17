using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testlambda
{
    class Program
    {
        static void Main(string[] args)
        {
            var fun = new Func<int, int, int>((int a, int b) => { return a + b; });
            Console.WriteLine(fun(100,200));
            add s = (int a, int b) => { return a + b; };
            Console.WriteLine(s(200,300));
        }
     
    }
    public delegate int add(int a, int b);
}
