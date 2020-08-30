using System;
using System.Globalization;

namespace Weerstation
{
    public class Temperature : IComparable<Temperature>
                             , IFormattable
    {
        private decimal temp;

        public Temperature(decimal temperature) {
            if (temperature < -273.15m)
                throw new ArgumentOutOfRangeException
                            (String.Format("{0} is less than absolute zero.", temperature));
            this.temp = temperature;
        }

        public decimal Celsius {
            get { return temp; }
        }

        public decimal Fahrenheit {
            get { return temp * 9 / 5 + 32; }
        }

        public decimal Kelvin {
            get { return temp + 273.15m; }
        }

        public override string ToString() {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format) {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public static decimal CelsiusToFahrenheit(decimal celsius)  {
            return  celsius * 9 / 5 + 32; 
        }

        public string ToString(string format, IFormatProvider provider) {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant()) {
                case "G":
                case "C":
                    return Celsius.ToString("F2", provider) + " °C";
                case "F":
                    return Fahrenheit.ToString("F2", provider) + " °F";
                case "K":
                    return Kelvin.ToString("F2", provider) + " K";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }


        public int CompareTo(Temperature other) {
            // If other is not a valid object reference, this instance is greater. 
            if (other == null) return 1;

            // The temperature comparison depends on the comparison of  
            // the underlying Decimal/Double values.  
            return temp.CompareTo(other.temp);
        }

        //// override CompareTo method (which implements IComparer<T> interface)
        //public override int Compare(Temperature x, Temperature y)
        //{
        //    return x.CompareTo(y);
        //}
    }

}
