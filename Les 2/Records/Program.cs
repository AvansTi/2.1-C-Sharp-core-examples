using System;
using System.Collections.Generic;
using System.Linq;

namespace Records
{
    class Program
    {

        public record Temprature(double HighTemp, double LowTemp)
        {
            public double Mean => (HighTemp + LowTemp) / 2.0;
        }

        public record DailyTemperature(double HighTemp, double LowTemp) : Temprature(HighTemp, LowTemp)
        {

        }


        public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords);

        public sealed record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
            : DegreeDays(BaseTemperature, TempRecords)
        {
            public double DegreeDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);
        }

        public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature> TempRecords)
            : DegreeDays(BaseTemperature, TempRecords)
        {
            public double DegreeDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);
        }


        private static DailyTemperature[] data = new DailyTemperature[]
        {
            new DailyTemperature(HighTemp: 57, LowTemp: 30),
            new DailyTemperature(60, 35),
            new DailyTemperature(63, 33),
            new DailyTemperature(68, 29),
            new DailyTemperature(72, 47),
            new DailyTemperature(75, 55),
            new DailyTemperature(77, 55),
            new DailyTemperature(72, 58),
            new DailyTemperature(70, 47),
            new DailyTemperature(77, 59),
            new DailyTemperature(85, 65),
            new DailyTemperature(87, 65),
            new DailyTemperature(85, 72),
            new DailyTemperature(83, 68),
            new DailyTemperature(77, 65),
            new DailyTemperature(72, 58),
            new DailyTemperature(77, 55),
            new DailyTemperature(76, 53),
            new DailyTemperature(80, 60),
            new DailyTemperature(85, 66)
        };


        static void Main(string[] args)
        {

            Temprature todayTemprature = new Temprature(20.5, 18.5);

            Console.WriteLine($"Min temp: {todayTemprature.LowTemp} oC, Max temp: {todayTemprature.HighTemp} oC, Average temp: {todayTemprature.Mean}");
            Console.WriteLine(todayTemprature);

            Temprature[] tempratures = new Temprature[]
            {
                new(11.0, 10.6),
                new(-9.5, -8.5),
                new(22, 16.5),
            };



            var heatingDegreeDays = new HeatingDegreeDays(65, data);
            Console.WriteLine(heatingDegreeDays);

            var coolingDegreeDays = new CoolingDegreeDays(65, data);
            Console.WriteLine(coolingDegreeDays);

            //todayTemprature.Average = 10; Werkt niet. setter staat op init bij record

        }
    }
}
