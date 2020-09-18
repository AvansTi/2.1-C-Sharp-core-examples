using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<String> names = new List<String>() { "Harry Potter", "Ron Weasley", "Hermione Jean Granger" };

        // Manier 0: gebruik een foreach lus:
        Console.WriteLine("\nmanier 0: met foreach loop:\n");
        foreach (string name in names)
        {
            //Console.WriteLine("naam: {0} lengte naam: {1}", name, name.Length);
            Console.WriteLine($"naam: {name} lengte naam: {name.Length}");
        }

        // Manier 1: gebruik een externe methode als argument voor ForEach
        Console.WriteLine("\nmanier 1: met methode print:\n");
        names.ForEach(Print);

        // Manier 2: gebruik een anonieme delegate methode als argument voor ForEach
        Console.WriteLine("\nmanier 2: met anonieme delegate:\n");
        names.ForEach(delegate(String name)
        {
            //Console.WriteLine("naam: {0} lengte naam: {1}", name, name.Length);
            Console.WriteLine($"naam: {name} lengte naam: {name.Length}");
        });

        // Manier 3: Lambda expressie als argument voor ForEach
        Console.WriteLine("\nmanier 3: met een lambda expressie:\n");
        names.ForEach(
            (String name) 
                => Console.WriteLine($"naam: {name} lengte naam: {name.Length}")
            );

        
        Console.ReadKey();
    }

    private static void Print(string name)
    {
         Console.WriteLine("naam: {0} lengte naam: {1}", name, name.Length);
    }
}