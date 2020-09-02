using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIComprable
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        class Person : IComparable, IComparable<Person>
        {
            public int geboortejaar { get; set; }
            public string naam { get; set; }



            public int CompareTo(Person other)
            {
                throw new NotImplementedException();
            }

            public int CompareTo(object obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
