using System;
using System.Diagnostics;
using System.Linq;

namespace PLinkDemoCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            //easy way to generate a range of integers
            var data = Enumerable.Range(1, 100000);

            int numFound = 0;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            var query = from val in data where (ComplexCriteria(val) == true) select val;
            foreach (var q in query)
            {
                ++numFound;
            }

            timer.Stop();
            Console.WriteLine("LINQ: Found {0} results in {1}", numFound, timer.Elapsed);


            // Reset for parallel
            timer.Reset();
            numFound = 0;

            // Start Parallel Link
            timer.Start();

            query = from val in data.AsParallel().AsOrdered() where (ComplexCriteria(val) == true) select val;
            foreach (var q in query)
            {
                ++numFound;
            }
            timer.Stop();
            Console.WriteLine("PLINQ: Found {0} results in {1}", numFound, timer.Elapsed);

            Console.ReadKey();
        }

        private static bool ComplexCriteria(int val)
        {
            //just some evaluation function that takes a while to run
            //to make the parallelism more obvious
            Int64 sum = 0;
            for (int i = 0; i < val; ++i)
            {
                sum += val;
            }
            return sum % 2 == 0;
        }
    }
}
