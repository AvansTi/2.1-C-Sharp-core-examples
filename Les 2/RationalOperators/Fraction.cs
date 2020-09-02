using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionOperators
{
    class Fraction
    {

        int num, den;

        public Fraction(int num, int den) {
            this.num = num;
            this.den = den;
        }

        // overload operator +  
        // all operator overload definitions should be: public static  
        public static Fraction operator +(Fraction a, Fraction b) {
            return new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
        }

        // overload operator *
        public static Fraction operator *(Fraction a, Fraction b) {
            return new Fraction(a.num * b.num, a.den * b.den);
        }


        // user-defined conversion from Fraction to double
        //  In general, implicit conversion operators should:
        //	- never throw exceptions and 
        //	- never lose information
        public static implicit operator double (Fraction f) {
            return (double)f.num / f.den;
        }

        public override string ToString() {
            return string.Format($"({num} / {den})");
        }
    }
}
