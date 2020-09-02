using System;

namespace TestFind
{
    class Program
    {
        static void Main(string[] args)  {
            int[] a = { 0, 2, 4, 6, 8, 10, 11, 12, 14, 16 };
            Predicate<int> groterDan100 = x => x * x > 100;

            int[] kwadraatGroterDan100 = Array.FindAll(a, n => n*n > 100);
            int[] allen = Array.FindAll(a, groterDan100);

            Console.WriteLine($"Eerste waarde die voldoet: {kwadraatGroterDan100[0]}");

            Console.WriteLine("\nAlle waarden die voldoen:");
            foreach (int x in allen) {
                Console.WriteLine(x);
            }

            Console.ReadLine();
        }


    }
}
