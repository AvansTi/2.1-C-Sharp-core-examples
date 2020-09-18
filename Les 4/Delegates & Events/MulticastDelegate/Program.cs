using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulticastDelegate
{
    class Program
    {
        delegate void FormatNumber(double number);

        static void Main(string[] args)
        {
            FormatNumber format = FormatNumberAsCurrency;
            format += FormatNumberWithCommas;
            format += FormatNumberWith3Places;

            format += (n => Console.WriteLine("afgerond: " + Math.Round(n)));
            format -= FormatNumberWithCommas;

            format(12345.6789);


            testSortDelegate();
            Console.ReadKey();
     
        }
/*
        static void afronden(double number)
        {
            Console.WriteLine("afgerond: " + Math.Round(number));
        }
        */

        static void FormatNumberAsCurrency(double number)
            => Console.WriteLine($"A Currency: {number:C}");

        static void FormatNumberWithCommas(double number)
            => Console.WriteLine($"With Commas: {number:N}");

        static void FormatNumberWith3Places(double number)
            => Console.WriteLine($"With 3 places: {number:.###}" );


        public static void testSortDelegate()
        {
            // Some words. 
            List<string> Words = new List<string> { "amazingly", "my", "badger", "exploded" };

            // Sort them by word length. 
            Words.Sort((a, b) => { return a.Length.CompareTo(b.Length); });

            // Show results. 
            foreach (string Word in Words) Console.Write(Word + " ");
        }
    }
}