using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Delegates  {
    class Program {
        delegate T Calculate<T>(T a, T b);

        static void Main(string[] args) {

            #region Test Delegates 
            List<Calculate<double>> opsList = new List<Calculate<double>>();

            // uitgebreide notatie (oudere syntax):
            Calculate<double> myCal = Multiply;
            Console.WriteLine($"Toepassen van delegate myCal(3, 4): {myCal(3, 4)}");

            // verkorte notatie:
            Calculate<double> myCal2 = Add;
            Console.WriteLine($"Toepassen van delegate myCal(3, 4): {myCal2(3, 4)}");

            //oudere syntax: opsList.Add(new Calculate<double> (Add));
            opsList.Add(Add);
            opsList.Add(Divide);
            opsList.Add(Add);
            opsList.Add(Multiply);

            double result = 0.0;
            foreach (Calculate<double> op in opsList) {
                result = op(result, 3);
                Console.WriteLine($"result = {result}");
            }

            Console.ReadKey();
        }

        static double Divide(double a, double b) {
            return a / b;
        }

        static double Multiply(double a, double b) {
            return a * b;
        }

        static double Add(double a, double b) {
            return a + b;
        }
        #endregion
    }


}
