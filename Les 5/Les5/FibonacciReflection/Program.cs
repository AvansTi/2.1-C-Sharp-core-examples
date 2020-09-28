using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;

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
