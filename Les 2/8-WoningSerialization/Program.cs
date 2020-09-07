using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace _8_WoningSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Huizen register");
            Console.WriteLine("Command:\tActie");
            Console.WriteLine("l\tLaden van bestand");


            List<Woning> woningen = new List<Woning>();
            woningen.Add(new Woning("Huislaan 10", 200000));
            woningen.Add(new Woning("Teduur straat 10", 250000));
            woningen.Add(new Flat("Gezelligheid 1", 200000, 100));

            var jsonString = JsonSerializer.Serialize(woningen);
            File.WriteAllText("G:\\tmp\\woning.json", jsonString);






        }
    }

}
