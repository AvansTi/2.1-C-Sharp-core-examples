#define DEBUG

using System;
using System.Diagnostics;


namespace LesVoorbeeld
{
    class Program
    {


        [Conditional("DEBUG")]
        public static void DebugLog(string message)
        {
            Console.WriteLine($"Debug: {message}");
        }
        static void Main(string[] args)
        {
            DebugLog("Hello World!");
        }
    }
}
