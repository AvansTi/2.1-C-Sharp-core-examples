﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    

    class Program
    {
        delegate T Calculate<T>(T a, T b);

        static void Main(string[] args)
        {
            List<Calculate<double>> opsList = new List<Calculate<double>>();
          

            opsList.Add(new Calculate<double> (Add));
            opsList.Add(Divide);
            opsList.Add(Add);
            opsList.Add(Multiply);

            double result = 0.0;
            foreach (Calculate<double> op in opsList)
            {
                result = op(result, 3);
                Console.WriteLine("result = {0}", result);
            }

            Console.ReadKey();
        }

        static double Divide(double a, double b)
        {
            return a / b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }
    }
}
