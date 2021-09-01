using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WellKnownDirectories
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Environment.SpecialFolder folder in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                var path = Environment.GetFolderPath(folder);
                Console.WriteLine($"{folder}\t==>\t{path}");
            }
            Console.ReadKey();
        }
    }
}
