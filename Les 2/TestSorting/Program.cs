using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSorting
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Student : IComparable<Student> {
        public int JaarInschrijving { get; set; }
        public string Naam { get; set; }

        public int CompareTo(Student other) {
            return this.Naam.CompareTo(other.Naam);
        }


        public override string ToString() {
            return $"{Naam,-8} - {JaarInschrijving}";
        }

    }

    class JaarCompararer : Comparer<Student> {
        public override int Compare(Student x, Student y) {
            // Bij gelijk jaar vergelijken we de naam:
            if (x.JaarInschrijving == y.JaarInschrijving) {
                return x.Naam.CompareTo(y.Naam);
            }
            // en anders vergelijken we jaar van inschrijving:
            return x.JaarInschrijving.CompareTo(y.JaarInschrijving);
        }
    }

    class Program
    {
        static void Main() {
            List<Student> list = new List<Student>();
            list.Add(new Student() { Naam = "Steven", JaarInschrijving = 2010 });
            list.Add(new Student() { Naam = "Jacky", JaarInschrijving = 2010 });
            list.Add(new Student() { Naam = "Kees", JaarInschrijving = 2014 });
            list.Add(new Student() { Naam = "Boris", JaarInschrijving = 2011 });
            list.Add(new Student() { Naam = "Louis", JaarInschrijving = 2012 });

            Console.WriteLine("Sorteer natuurlijk op naam:");
            // Uses IComparable.CompareTo()
            list.Sort();

            // Uses Employee.ToString
            foreach (var element in list) {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nSorteer m.b.v. JaarComparer:");
            list.Sort(new JaarCompararer());
            foreach (var element in list) {
                Console.WriteLine(element);
            }

            Console.Read();
        }
    }
}
