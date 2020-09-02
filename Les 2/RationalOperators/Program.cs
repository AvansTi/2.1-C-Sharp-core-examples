#define debug

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionOperators
{
    class Program
    {

        static void Main(string[] args)
        {

            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(3, 7);
            Fraction c = new Fraction(2, 3);
            Fraction d = new Fraction(3, 2);

            Console.WriteLine($"De breuk ({d}) + ({a} * {b} + {c})) heeft als resultaat:");
            Console.WriteLine($"{(d + (a * b + c))}");
            Console.WriteLine("Expliciete cast naar double: {0}",(double)(d + (a * b + c)));

            // onderstaande werkt bij een impliciete cast definitie:
            Console.WriteLine("Implicitiete cast naar double: {0}", 0.0 + d + (a * b + c));

            string s = null;
            PrintMessage(s);
            PrintMessage("Hello World");


            Console.ReadLine();
        }


        public static void PrintMessage(string m)
        {
            Console.WriteLine(m ?? "ongedefinieerd");
            Console.WriteLine("In hoofdletters: " + m?.ToUpper());
        }



    }


}
