using System;

namespace TestDynamics
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Car
    {
        public Car(string carType, int year, int miles)
        {
            CarType = carType;
            Year = year;
            Mileage = miles;
        }

        public string CarType { get; protected set; }
        public int Year { get; set; }
        public int Mileage { get; set; }

        public void drive(int miles) => Mileage += miles;
        public int milesPerYear() => Mileage / (DateTime.Now.Year - Year);
        public void prepareForSale() => Mileage /= 2;
        public void printCar() => Console.WriteLine
                        ($"{CarType} is from {Year}");
    }

}
