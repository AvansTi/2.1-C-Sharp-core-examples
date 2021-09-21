using Fibonacci;
using System;

namespace FibonacciReflection
{
    class Program
    {
        static void Main(string[] args)
        {

            Type type = typeof(Calculate);

            Console.WriteLine("Attributes");
            foreach (var field in type.GetFields())
            {
                Console.WriteLine(field);
            }

            Console.WriteLine("Methods: ");
            foreach (var method in type.GetMethods()) {
                Console.WriteLine(method);
            }

            Console.ReadLine();
        }
    }
}
