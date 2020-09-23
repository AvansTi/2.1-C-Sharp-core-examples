using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase.Tests
{
    [TestClass()]
    public class PatientTests
    {
        [TestMethod()]
        public void SetNameTest()
        {
            // arrange
            Patient p = new Patient();
            
            // act
            p.SetName("First", "Last");
            string name = p.GetName();

            // assert
            Assert.AreEqual(name, "First Last");
        }

        [TestMethod()]
        public void SetBSNTest_Valid()
        {
            // arrange
            Patient p = new Patient();

            // act
            p.BSN = 111222333UL;

            // assert
            Assert.AreEqual(p.BSN, 111222333UL);
        }

        [TestMethod()]
        public void SetBSNTest_InvalidBSN()
        {
            // arrange
            Patient p = new Patient();

            // act and assert
            Assert.ThrowsException<ArgumentException>(() => p.BSN = 123456789, "Should throw invalid BSN exception");
        }

        [TestMethod()]
        public void SetBSN_Null()
        {
            // arrange
            Patient p = new Patient();
            
            // act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                p.BSN = null;
            });
        }
    }
}