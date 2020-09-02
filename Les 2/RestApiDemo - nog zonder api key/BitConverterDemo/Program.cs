using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * History of Endian-ness

Where does this term "endian" come from? 
Jonathan Swift was a satirist (he poked fun at society through his writings). 
His most famous book is "Gulliver's Travels", and he talks
about how certain people prefer to eat their hard boiled eggs 
from the little end first (thus, little endian), 
while others prefer to eat from the big end (thus, big endians) 
and how this lead to various wars.
Of course, the point was to say that it was a silly thing to debate over, and yet, people argue over such trivialities all the time (for example, should braces line in parallel or not? vi or emacs? UNIX or Windows).
 */
namespace BitConverterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define an array of integers.
            int[] values = { 0, 15, -15, 0x100000,  -0x100000, 1000000000,
                         -1000000000, int.MinValue, int.MaxValue };

            // Convert each integer to a byte array.
            Console.WriteLine("{0,16}{1,10}{2,17}", "Integer",
                              "Endian", "Byte Array");
            Console.WriteLine("{0,16}{1,10}{2,17}", "---", "------",
                              "----------");
            foreach (var value in values)
            {
                byte[] byteArray = BitConverter.GetBytes(value);
                Console.WriteLine("{0,16}{1,10}{2,17}",
                                  value,
                                  BitConverter.IsLittleEndian ? "Little" : " Big",
                                  BitConverter.ToString(byteArray));
            }

            Console.ReadKey();
        }
    }
}
