using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelLoopResult result =
                Parallel.For(0, 20, async i =>
                {
                    //Console.WriteLine("{0}, task:{1}, thread: {2} Is from threadpool? {3}", i,
                    //Task.CurrentId, Thread.CurrentThread.ManagedThreadId,Thread.CurrentThread.IsThreadPoolThread);
                    //Thread.Sleep(10);
                    await Task.Delay(100);
                    Console.WriteLine("{0}, task:{1}, thread: {2} Is from threadpool? {3}", i,
                    Task.CurrentId, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
                });
            Console.WriteLine("Is completed: {0}", result.IsCompleted);
            //Task.WaitAll();
            // Thread.sleep() is hier nodig omdat Task.WaitAll() niet wacht op background workers
            Thread.Sleep(200);
            Console.WriteLine("task:{0}, thread: {1} Is from threadpool? {2}",
                    Task.CurrentId, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
            Console.ReadKey();
        }
    }
}
