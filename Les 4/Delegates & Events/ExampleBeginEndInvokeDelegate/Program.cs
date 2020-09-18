using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ExampleBeginEndInvokeDelegate
{
    public delegate int SomeMethod(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main-Thread is " + Thread.CurrentThread.ManagedThreadId);

            SomeMethod a = new SomeMethod(Sum);
            Console.WriteLine("Aanroep asynchrone methode");

            // IAsyncResult asyncResult - dit representeert de status van de asynchrone operatie
            IAsyncResult asyncResult = a.BeginInvoke(5, 5, null, null);

            Thread.Sleep(200);

            // Tussendoor kan de status getest worden:
            Console.WriteLine("Moeilijke som uitgerekend? " + asyncResult.IsCompleted);

            Console.WriteLine("Het werk gaat door hier!! Tot de aanroep van EndInvoke...");

            // Nu gaan we wachten op het resultaat van de asynchrone aanroep:
            int result = a.EndInvoke(asyncResult);

            // Tussendoor kan de status getest worden:
            Console.WriteLine("Moeilijke som uitgerekend? " + asyncResult.IsCompleted);
 
            Console.WriteLine(result);
            Console.ReadKey();

        }

        public static int Sum(int x, int y)
        {
            Console.WriteLine("Sum-Thread is " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            return x + y;
        }
    }
}
