using System;

namespace TestPersoon {
    class Program {
        static void Main(string[] args) {
            Persoon p = new Persoon("Job", new DateTime(2000,1,28));
            Console.WriteLine(p.Naam + " is " + p.Leeftijd + " jaar.");
            Console.WriteLine("{0} is {1} jaar", p.Naam, p.Leeftijd);
            Console.WriteLine($"{p.Naam} is {p.Leeftijd} jaar");
            Console.ReadLine();
        }
    }

}