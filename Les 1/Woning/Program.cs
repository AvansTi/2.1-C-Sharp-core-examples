using System;

namespace Woning
{
    class Program
    {
        static void Main(string[] args)
        {
            // Een voorbeeld van meerdere resultaten in een methode.
            // We kunnen hier 'out' parameters gebruiken ipv 'ref' parameters
            // omdat de argumenten van de aanroep altijd een waarde krijgen in de 
            // methode zoekPrijsBereik.

            decimal goedkoopste;
            decimal duurste;

            WoningMarkt wm = new WoningMarkt();
            wm.AddWoning(new Woning("Huislaan 10", 200000));
            wm.AddWoning(new Woning("Teduur straat 10", 250000));

            wm.zoekPrijsBereik(out goedkoopste, out duurste);

            Console.WriteLine("De goedkoopste woning is {0} euro en de duurste woning is {1} euro."
			  , goedkoopste, duurste);

            Console.WriteLine("Wil je nog verder gaan?");
        }

    }
}

