using System;
using System.Globalization;
using Weerstation;


public class Example {
    public static void Main() {
        Temperature temp1, temp2, temp3, temp4;

        // Aanroep statische methode:
        Console.WriteLine("{0} graden celsius is gelijk aan {1} graden fahrenheit.", 20, Temperature.CelsiusToFahrenheit(20));

        // Use composite formatting with format string in the format item.
        temp1 = new Temperature(0);
        Console.WriteLine("Toegang m.b.v. de verschillende properties:\n1. Celsius:\t{0}\n2. Farenheit:\t{1}\n3. Kelvin:\t{2}\n\n", temp1.Celsius, temp1.Fahrenheit, temp1.Kelvin);

        Console.WriteLine("{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)\n", temp1);

        // Use composite formatting with a format provider.
        temp2 = new Temperature(-40);
        Console.WriteLine(String.Format(CultureInfo.CurrentCulture, "{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)", temp2));
        Console.WriteLine(String.Format(new CultureInfo("en-UK"), "{0:C} (Celsius) = {0:K} (Kelvin) = {0:F} (Fahrenheit)\n", temp2));

        // Call ToString method with format string.
        temp3 = new Temperature(32);
        Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)\n",
                          temp3.ToString("C"), temp3.ToString("K"), temp3.ToString("F"));

        // Call ToString with format string and format provider
        temp4 = new Temperature(100);
        NumberFormatInfo current = NumberFormatInfo.CurrentInfo;
        CultureInfo nl = new CultureInfo("nl-NL");
        Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)",
                          temp4.ToString("C", current), temp4.ToString("K", current), temp4.ToString("F", current));
        Console.WriteLine("{0} (Celsius) = {1} (Kelvin) = {2} (Fahrenheit)",
                          temp4.ToString("C", nl), temp4.ToString("K", nl), temp4.ToString("F", nl));



        Temperature[] temps = new Temperature[] { temp3, temp1, temp4, temp2 };
        Array.Sort(temps);
        Console.WriteLine("Temperaturen op volgorde: " + string.Join(",", (object[])temps));

        Console.ReadKey();
    }
}
