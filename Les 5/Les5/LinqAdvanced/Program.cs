using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleAny();
            ExampleAll();
            ExampleGroupBy();
            ExampleSum();
            ExampleLetKeyword();
            ExampleNestedSelection();
            ExampleFirst();
            ExampleNestedSelection();
            ExampleFirst();
            ExampleFirstOrDefault();
            ExampleSelectMany();
            ExampleRemoveDuplicatesAnonymous();
        }


        public static void ExampleAny()
        {
            string[] words = { "believe", "relief", "receipt", "field" };
            bool containsEI = words.Any(w => w.Contains("ei"));

            Console.WriteLine("There is a word in the list that contains 'ei': {0}", containsEI);
        }

        public static void ExampleAll()
        {
            int[]
                numbers = { 1, 11, 3, 19, 41, 65, 19 };
            bool onlyOdd = numbers.All(n => n % 2 == 1);

            Console.WriteLine("The list contains only odd numbers: {0}", onlyOdd);
        }

        public static void ExampleGroupBy()
        {

            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var wordGroups = from w in words
                             group w by w[0] into g
                             select new { FirstLetter = g.Key, Words = g };

            foreach (var g in wordGroups)
            {
                Console.WriteLine("Words that start with the letter '{0}':", g.FirstLetter);
                foreach (var w in g.Words)
                {
                    Console.WriteLine(w);
                }
            }
        }


        public static void ExampleSum()
        {
            string[] words = { "cherry", "apple", "blueberry" };
            double totalChars = words.Sum(w => w.Length);

            Console.WriteLine("There are a total of {0} characters in these words.", totalChars);
        }

        public static void ExampleLetKeyword()
        {
            string[] strings = { "A penny saved is a penny earned."
                      , "The early bird catches the worm."
                      , "The pen is mightier than the sword." };

            // Split the sentence into an array of words
            // and select those whose first letter is a vowel.
            var earlyBirdQuery = from sentence in strings
                                 let words = sentence.Split(' ')
                                 from word in words
                                 let w = word.ToLower()
                                 where w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u'
                                 select word;

            // Execute the query.
            earlyBirdQuery.ToList().ForEach(v => { Console.WriteLine($"{v} starts with a vowel"); });

        }

        public static void ExampleNestedSelection()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { X = a, Y = b };

            Console.WriteLine("Pairs where a < b:");
            pairs.ToList().ForEach(pair => { Console.WriteLine($"{pair.X} is less than {pair.Y}"); });
        }

        public static void ExampleFirst()
        {
            Console.WriteLine("Example with First: ");
            int[] getallen = { 3, 5, 7, 9, 11, 13 };

            // Het eerste getal willen we alleen hebben, daarom .First()
            int getal = (from g in getallen
                         where g * g > 100
                         select g).First();
            Console.WriteLine($"First output {getal}");

        }

        public static void ExampleFirstOrDefault()
        {
            Console.WriteLine("Example with FirstOrDefault: ");
            int[] getallen = { 3, 5, 7, 9, 11, 13 };

            // Soms hebben we niet een resultaat, maar willen we standaard waarde hebben
            int getal = (from g in getallen
                         where g * g > 100
                         select g).FirstOrDefault();
            Console.WriteLine($"First output {getal}");

        }

        public static void ExampleSelectMany()
        {
            Console.WriteLine("Example with Select Many: ");
            var sentences = new List<string> { "Bob is quite excited.", "Jim is very upset." };
            var words = sentences.SelectMany(w => w.TrimEnd('.').Split(' ')).ToList();

            words.ForEach(w => { Console.WriteLine($"Word: {w}"); });

        }

        public static void ExampleRemoveDuplicatesAnonymous()
        {

            Console.WriteLine("Example with Anonymous Duplicates: ");
            var ret = new[] {  new { SNR=1,Name="Keith",Result=4.5 },
                    new { SNR=1,Name="Keith",Result=5.0 },
                    new { SNR=1,Name="Keith",Result=6.7 },
                    new { SNR=2,Name="Roger",Result=5.1 },
                    new { SNR=2,Name="Roger",Result=7.2 },
                    new { SNR=3,Name="John",Result=8.1 },
                    new { SNR=4,Name="Pete",Result=3.5 },
                    new { SNR=4,Name="Pete",Result=5.0 },
                    new { SNR=4,Name="Pete",Result=5.5 }
                      };

            var duplicates1 = (from item in ret
                               group item by item.SNR into grp
                               let org = grp.First()
                               let dup = grp.Skip(1).Select(x => new { Name = org.Name, Org = org.Result, Dup = x.Result })
                               select dup).SelectMany(x => x).ToList();

            Console.WriteLine("Resultaten van studenten die herkansingen hebben gedaan t.o.v. eerste poging.");
            duplicates1.ForEach(duplicate =>
            {
                Console.WriteLine($"Student {duplicate.Name} eerste kans: {duplicate.Org} herkansing: {duplicate.Dup}");
            });



        }


    }
}
