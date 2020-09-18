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
        private static bool done = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Main-Thread is " + Thread.CurrentThread.ManagedThreadId);

            SomeMethod a = new SomeMethod(Sum);
            Console.WriteLine("Aanroep asynchrone methode");

            // IAsyncResult asyncResult - dit representeert de status van de asynchrone operatie
            IAsyncResult asyncResult = a.BeginInvoke(5, 5, new AsyncCallback(Done), null);

            Thread.Sleep(200);

            // Tussendoor kan de status getest worden:
            Console.WriteLine("Moeilijke som uitgerekend? " + asyncResult.IsCompleted);

            while (!done)
            {
                Console.WriteLine("Het werk gaat door hier!! Tot de aanroep van EndInvoke...");
                Thread.Sleep(200);
            }

            // Nu gaan we wachten op het resultaat van de asynchrone aanroep:
            int result = a.EndInvoke(asyncResult);

            // Tussendoor kan de status getest worden:
            Console.WriteLine("Moeilijke som uitgerekend? " + asyncResult.IsCompleted);

            Console.WriteLine("Resultaat asynchrone methode na EndInvoke: {0}", result);
            Console.ReadKey();
        }


        public static int Sum(int x, int y)
        {
            Console.WriteLine("Sum-Thread is " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            return x + y;
        }

        public static void Done(IAsyncResult result)
        {
            done = true;
         }
    }
}
