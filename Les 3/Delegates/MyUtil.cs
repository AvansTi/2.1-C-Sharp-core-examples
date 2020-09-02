using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    static class MyUtil  {
        public static string EersteLetterNaarHoofdletter(this string s) {
            char eerste = s[0];
            return eerste.ToString().ToUpper() + s.Substring(1);
        }
    }
}
