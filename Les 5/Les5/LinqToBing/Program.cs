﻿using System;
using System.Collections.Generic;

namespace LinqToBing
{
    class Program
    {
        //#error Get your own AppId at http://www.bing.com/developers/
        const string AppId = "YOUR APPID HERE";
        
        static void Main(string[] args)
        {
            Bing search = new Bing(AppId);

            string query = "Visual Studio 2015";

            IEnumerable<SearchResult> results = search.QueryWeb(query);

            foreach (SearchResult result in results)
            {
                Console.WriteLine("{0}" 
                    + Environment.NewLine + "\t{1}" 
                    + Environment.NewLine + "\t{2}"
                    + Environment.NewLine, 
                    result.Title, result.Url, result.Description);
            }

            Console.ReadKey();            
        }
    }
}
