namespace FractionOperators
{
    public class Fraction
    {

        private int num, den;

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


        // Overloaod of true false
        public static bool operator true(Fraction f)
        {
            return f.den > 0 && f.num > 0;
        }

        public static bool operator false(Fraction f)
        {
            return f.den == 0 || f.num == 0;
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
