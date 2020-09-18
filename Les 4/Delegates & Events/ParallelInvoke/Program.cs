using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(doeDit, doeDat);
            Console.ReadKey();
        }

        private static void doeDat()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Thread: {0} task: {1} waarde: {2}",Thread.CurrentThread.ManagedThreadId,Task.CurrentId,i);
                Task.Delay(100);
               
            }
        }

        private static void doeDit()
        {
            foreach (var item in "abcdefghijklmnopqrstuvwxyz")
            {
                Console.WriteLine("Thread: {0} task: {1} waarde: {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, item);
                Task.Delay(50);
                
            }
        }
    }
}
