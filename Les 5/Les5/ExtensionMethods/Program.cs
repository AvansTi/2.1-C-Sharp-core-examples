using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

using ExtensionMethods;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new {X=1, Y=2};
            //var b = new {X= 1, Y=2 };
            //Console.WriteLine(a.GetType() + "\n" + b.GetType());

            TestExensionAndBoxing();
            //TestExpressionTree();
            //TestSelect1();
            //TestSelect2();
            //TestSelect3();

            //TestFirstOrDefault();
            //TestDublicates1();
            //TestDublicates2();


            //TestNestedSelection();
            Console.ReadKey();
        }
        public static void TestExensionAndBoxing()
        {
            Console.WriteLine(MyUtil.UpperFirst1("piet"));

            Console.WriteLine("jan".UpperFirst2());

            string[] words = { "een", "twee", "drie" };

            Console.WriteLine(words.Regels());

            100.Times(() => Console.WriteLine("ik mag niet spieken"));

        }

        public static void TestExpressionTree()
        {
            Func<int, int> kwadraat = x => x * x;
            Console.WriteLine(kwadraat(7));

            Expression<Func<int, int>> kwadraatTree = x => x*x;
            Console.WriteLine(kwadraatTree);

        }
        public static void TestSelect1()
        {
            var result = from m in typeof(string).GetMethods()
                         select m.Name;
            Console.WriteLine(result.Regels());

        }
        public static void TestSelect2()
        {
            var nonStaticMethods = from m in typeof(string).GetMethods()
                                   where !m.IsStatic
                                   select m.Name;

            Console.WriteLine(nonStaticMethods.Regels());


        }
        public static void TestSelect3()
        {
            var methodeGroepen = from m in typeof(string).GetMethods()
                                 where !m.IsStatic
                                 group m by m.Name into g
                                 select new { Naam = g.Key, Aantal = g.Count(), Value = g };
            foreach (var g in methodeGroepen)
            {
                Console.WriteLine("{0} heeft {1} overloads.", g.Naam, g.Aantal);
                foreach (var xg in g.Value)
                {
                    Console.WriteLine("\t\t" + xg.Name);
                }
            }
        }
        public static void TestFirstOrDefault()
        {
            int[] getallen = { 3, 5, 7, 9 };
            string getal = (from g in getallen where g * g > 100 select g.ToString()).FirstOrDefault();
            Console.WriteLine(getal);
        }

 
        public static void TestNestedSelection()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs =
                from a in numbersA
                from b in numbersB
                where a < b
                select new { X = a, Y = b };

            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs)
            {
                Console.WriteLine("{0} is less than {1}", pair.X, pair.Y);
            }
        }

        public static void TestDublicates1()
        {
            /**
             *  Dubbele waarden weergeven:
             */
            var ret = new[]{            
                               new { SNR=1,Name="Keith",Result=4.5 },
                               new { SNR=1,Name="Keith",Result=5.0 },
                               new { SNR=1,Name="Keith",Result=6.7 },
                               new { SNR=2,Name="Roger",Result=5.1 },
                               new { SNR=2,Name="Roger",Result=7.2 },
                               new { SNR=3,Name="John",Result=8.1 },
                               new { SNR=4,Name="Pete",Result=3.5 },
                               new { SNR=4,Name="Pete",Result=5.0 },
                               new { SNR=4,Name="Pete",Result=5.5 } 
                           };

            var duplicates1
                = (from item in ret
                   group item by item.SNR into grp
                   let org = grp.First()
                   let dup = grp.Skip(1).Select(x => new { Name = org.Name, Org = org.Result, Dup = x.Result })
                   select dup).SelectMany(x => x).ToList();

            Console.WriteLine("\nResultaten van studenten die herkansingen hebben gedaan t.o.v. eerste poging.");
            duplicates1.ForEach(duplicate => { Console.WriteLine("Student {0} eerste kans: {1} herkansing: {2}", duplicate.Name, duplicate.Org, duplicate.Dup); });

        }

        public static void TestDublicates2()
        {
            /**
             *  Dubbele waarden weergeven:
             */
            var ret = new[]{            
                               new { SNR=1,Name="Keith",Result=4.5 },
                               new { SNR=1,Name="Keith",Result=5.0 },
                               new { SNR=1,Name="Keith",Result=6.7 },
                               new { SNR=2,Name="Roger",Result=5.1 },
                               new { SNR=2,Name="Roger",Result=7.2 },
                               new { SNR=3,Name="John",Result=8.1 },
                               new { SNR=4,Name="Pete",Result=3.5 },
                               new { SNR=4,Name="Pete",Result=5.0 },
                               new { SNR=4,Name="Pete",Result=5.5 } 
                           };

            var duplicates2
                = (from item in ret
                   group item by item.SNR into grp
                   let org = grp.First()
                   let dup = grp.Count() > 1
                           ? grp.Skip(1).Select(x => new { Name = org.Name, Org = org.Result, Dup = x.Result })
                           : grp.Select(x => new { Name = org.Name, Org = org.Result, Dup = double.NaN })
                   select dup).SelectMany(x => x).ToList();

            Console.WriteLine("\nResultaten t.o.v. eerste poging.");
            duplicates2.ForEach(duplicate => { Console.WriteLine("Student {0} eerste kans: {1} herkansing: {2}", duplicate.Name, duplicate.Org, duplicate.Dup); });

        }


    }
}
