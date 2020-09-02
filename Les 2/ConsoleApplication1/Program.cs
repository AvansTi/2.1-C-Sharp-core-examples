using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les2
{
    class Program
    {
        static void Main(string[] args)
        {
            // In Environment kun je allerlei systeem informatie opvragen, zoals standaard folder paden:
            Console.WriteLine("MyPictures folder is:");
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));

            Console.WriteLine("\nFolder van waaruit de applicatie wordt gestart is:");
            string currentPath = Directory.GetCurrentDirectory();
            Console.WriteLine(currentPath + Environment.NewLine);
            string configFile = Path.Combine(currentPath, "ConsoleApplication1.dll.config");

            // In een form applicatie kun je ook gebruiken:
            string applicationPath = System.Windows.Forms.Application.StartupPath;
            //string configFile2 = applicationPath + "/ConsoleApplication1.exe.config";
            //Console.WriteLine(applicationPath);

            // exception:
            //Console.WriteLine(File.ReadAllText("onbekend"));
            string allText = File.ReadAllText(configFile);
            //alle tekst lezen als één string:
            Console.WriteLine(allText);

            //Alle regels afzonderlijk lezen:
            var lines = File.ReadLines(configFile);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            

            // System.Environment.NewLine: "\r\n"
            string joinedLines = string.Join(System.Environment.NewLine, lines);
            Console.WriteLine(joinedLines.Length);
            Console.Read();
            Trace.Assert(allText.Equals(joinedLines));
        }
    }
}
