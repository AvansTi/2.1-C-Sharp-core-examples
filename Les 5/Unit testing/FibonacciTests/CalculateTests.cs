using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fibonacci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.Tests
{
    [TestClass()]
    public class CalculateTests
    {

        [TestMethod()]
        public void FibonacciTestValid()
        {
            Calculate calculate = new Calculate();
            Assert.AreEqual(0, calculate.Fibonacci(0));
            Assert.AreEqual(1, calculate.Fibonacci(1));
            Assert.AreEqual(1, calculate.Fibonacci(2));
            Assert.AreEqual(233, calculate.Fibonacci(13));
            Assert.AreEqual(1836311903, calculate.Fibonacci(46));
        }

        [TestMethod()]
        public void FibonacciTestOverflow()
        {
            Calculate calculate = new Calculate();
            Assert.ThrowsException<OverflowException>(() => calculate.Fibonacci(47));
        }

        [TestMethod()]
        public void FibonacciTestNegativeN()
        {
            Calculate calculate = new Calculate();
            Assert.ThrowsException<ArgumentException>(() => calculate.Fibonacci(-1));
        }




    }
}