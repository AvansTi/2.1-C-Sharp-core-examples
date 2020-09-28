using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCountAsync
{
    class Program
    {
        static void Main(string[] args) {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Started counting primes...");

            PrimeCount primeCount = new PrimeCount();
  
            int taskResult = 0;

            Task.Run(async () => {
                    taskResult = await primeCount.GetPrimeCountAsync(2, 1000000);
                }).Wait();

            Console.WriteLine("Result of the tasks:" + taskResult);

            stopwatch.Stop();
            Console.WriteLine($"Finished in: {stopwatch.ElapsedMilliseconds} milliseconds.");

            Console.ReadLine();

        }

    }


    class PrimeCount
    {
        public async Task<int> GetPrimeCountAsync(int min, int count)
        {
            return await Task.Run<int>(() =>
            {
                return ParallelEnumerable.Range(min, count).Count
                    (n =>
                        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All
                            (i => n % i > 0)
                    );
            });
        }

    }
}
