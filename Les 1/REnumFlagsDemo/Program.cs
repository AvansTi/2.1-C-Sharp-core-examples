using System;

namespace EnumFlagsDemo {
    // Add the attribute Flags or FlagsAttribute.
    [Flags]
    public enum CarOptions {
        // The flag for SunRoof is 0001.
        SunRoof = 0x01,
        // The flag for Rims is 0010.
        Rims = 0x02,
        // The flag for ParkAssistance is 0100.
        ParkAssistance = 0x04,
        // The flag for TintedWindows is 1000.
        TintedWindows = 0x08,
    }

    class FlagTest {
        static void Main() {
            // The bitwise OR of 0001 and 0100 is 0101.
            CarOptions options = CarOptions.Rims | CarOptions.ParkAssistance;

            // Because the Flags attribute is specified, Console.WriteLine displays 
            // the name of each enum element that corresponds to a flag that has 
            // the value 1 in variable options.
            Console.WriteLine(options);

            if ((options & CarOptions.SunRoof) != 0) {
                Console.WriteLine("The car has a SunRoof!");
            } else {
                Console.WriteLine("Never mind, it's raining anyway");
            }
            // The integer value of 0110 is 6.
            Console.WriteLine((int)options);
        }
    }
}
