using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldGroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            GroepInfo jaar2 = new GroepInfo();

            var jaar2Groepen = jaar2.GeefGroepen();

            foreach (var groep in jaar2Groepen)
            {
                Console.WriteLine("\n\nKey: {0}", groep.Key);
                foreach (Student student in groep)
                {
                    Console.WriteLine(student.Naam);
                }
            }

            Console.ReadKey();

        }
    }

 
}
