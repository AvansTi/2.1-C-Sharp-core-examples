using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class MyUtil
    {
        public static String UpperFirst1(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static String UpperFirst2(this string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string Regels(this IEnumerable<string> strings)
        {
            String result = "";

            foreach (string  s in strings)
            {
                result += s + "\n";
            }

            return result; // result.Substring(0, result.Length - separator.Length);
        }

        static public void Times(this Int32 n, Action proc)
	    {
		    for (int i = 1; i <= n; i++)
			    proc();
	    }



    }
}
