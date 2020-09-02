using System;
using System.Reflection.Emit;

namespace Weerstation
{
    public class Temprature
    {
        public static decimal CelsiusToFahrenheit(decimal celsius)
        {
            return celsius * 9 / 5 + 32;
        }
    }
}

namespace LesVoorbeeld
{
    class Program
    {


        static void Add(out int sum, params int[] val)
        {
            sum = 0;
            foreach (int i in val)
                sum += i;

        }
        static void Main(string[] args)
        {


            int sum;
            Add(out sum, 1, 2, 3, 4, 5, 6);


            Console.WriteLine($"Value of sum: {sum}");

            //Console.WriteLine("{0} graden = {1} graden farenheit", 20, Weerstation.Temprature.CelsiusToFahrenheit(20));
        }
    }
}
