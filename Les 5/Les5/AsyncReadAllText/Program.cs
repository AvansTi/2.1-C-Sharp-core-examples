using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncReadAllText
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            string workingDir = Environment.CurrentDirectory;
            // synchroon afhandelen:
            //CountWords(Path.Combine(workingDir, "tekst1.txt")).Wait();
            //CountWords(Path.Combine(workingDir, "tekst2.txt")).Wait();
            //CountWords(Path.Combine(workingDir, "tekst3.txt")).Wait();

            // gebruik WhenAll om IO bounded operaties asynchroon te laten werken:
            Task t1 = CountWords(Path.Combine(workingDir, "tekst1.txt"));
            Task t2 = CountWords(Path.Combine(workingDir, "tekst2.txt"));
            Task t3 = CountWords(Path.Combine(workingDir, "tekst3.txt"));
            Task.WhenAll(t1, t2, t3);

            stopwatch.Stop();
            Console.WriteLine($"Finished in: {stopwatch.ElapsedMilliseconds} milliseconds.");

            Console.ReadLine();
        }

        static async Task CountWords(string fileName)
        {
            String result;
            using (StreamReader reader = File.OpenText(fileName))
            {
                Console.WriteLine("Opened file.");
                result = await reader.ReadToEndAsync();
                Console.WriteLine($"{fileName} contains: {result.Split().Length} words.");
            }
        }
    }
}
