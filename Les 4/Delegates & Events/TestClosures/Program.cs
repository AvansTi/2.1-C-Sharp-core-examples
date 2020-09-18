using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClosures
{
    class Program
    {
        public static readonly IList<string> Words 
            = new List<string>
            { "the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog" }.AsReadOnly();

        static void Main()
        {
            //Test1();
            //Test2();
            Test3();
            Console.ReadKey();
        }


        public static void Test1()
        {
            // First build a list of actions:
            List<Action> actions = new List<Action>();
            for (int counter = 0; counter < 10; counter++)
            {
                actions.Add(() => Console.WriteLine(counter));
            }

            // Then execute them
            foreach (Action action in actions)
            {
                action();
            }

        }

        public static void Test2()
        {
            // First build a list of actions
            List<Action> actions = new List<Action>();
            for (int counter = 0; counter < 10; counter++)
            {
                int copy = counter;
                actions.Add(() => Console.WriteLine(copy));
            }

            // Then execute them
            foreach (Action action in actions)
            {
                action();
            }
        }


        public static void Test3()
        {
            Console.Write("Maximum length of the words? ");
            int maxLength = int.Parse(Console.ReadLine());

            Predicate<string> predicate = item => item.Length <= maxLength;
            IList<string> shortWords = Util.MyFilter(Words, predicate);
            Console.WriteLine($"\nAll words with length upto {maxLength}:");
            Util.Dump(shortWords);

            Console.WriteLine($"\nAll words starting with t:");
            IList<string> startsWithT = Util.MyFilter(Words, w => w[0] == 't');
            Util.Dump(startsWithT);


            // Use first overloaded definition of Dump:
            Console.WriteLine("\nAll words starting with q:");
            Util.Dump (Words.MyFilter(w => w[0] == 'q'));

            // Use second overloaded definition of Dump:
            Console.WriteLine("\nAll words with length > 4:");
            Util.Dump(Words, w => w.Length > 4);

            Console.WriteLine();
            //Console.WriteLine("mijn zin".StartZin());

            int n = 9;
            Console.WriteLine(Util.Kwadraat(n));
            Console.WriteLine(n.Kwadraat());
            Console.WriteLine(42.Kwadraat());
        }
    }

    // In Util.cs
    static class Util
    {

        public static int Kwadraat(this int number) => number * number;


        public static string StartZin(this string zin)
        {
            return zin[0].ToString().ToUpper() + zin.Substring(1);
        }

        public static IList<T> MyFilter<T>
            (this IList<T> source, Predicate<T> predicate)
        {
            List<T> ret = new List<T>();
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    ret.Add(item);
                }
            }
            return ret;
        }

        // Prints the contents of the list to the console.
        public static void Dump<T>(IList<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }

        // Prints a selection of the list to the console.
        public static void Dump<T>(IList<T> list, Predicate<T> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
