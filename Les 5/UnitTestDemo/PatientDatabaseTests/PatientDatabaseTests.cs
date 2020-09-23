using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase.Tests
{
    [TestClass()]
    public class PatientDatabaseTests
    {
        [TestMethod()]
        public void AddPatientTest_ValidPatient()
        {
            // arrange
            Patient p = new Patient("Aaa", "Bbb", "1-2-2003", 111222333);
            PatientSerializer ps = new PatientSerializer("AddPatientTest.json");
            PatientDatabase db = new PatientDatabase(ps);

            // act
            bool success = db.AddPatient(p);

            // assert
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void AddPatientTest_DuplicatePatient()
        {
            // arrange
            Patient p = new Patient("A", "B", "3-2-2001", 111222333);
            PatientSerializer ps = new PatientSerializer("AddPatientTest.json");
            PatientDatabase db = new PatientDatabase(ps);

            // act
            db.AddPatient(p);
            bool success = db.AddPatient(p); // Duplicate patient added, should return false

            // assert
            Assert.IsFalse(success);
        }

        [TestMethod()]
        public void WritePatientsTest()
        {
            // arrange
            Patient p1 = new Patient("A", "B", "3-2-2001", 111222333);
            Patient p2 = new Patient("C", "D", "4-5-2006", 123456782);
            PatientSerializer ps = new PatientSerializer("WritePatientsTest.json");
            PatientDatabase db = new PatientDatabase(ps);
            db.AddPatient(p1);
            db.AddPatient(p2);

            // act
            bool success = db.WritePatients();

            // assert
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void WritePatientsTest_MockedSerializer()
        {
            // arrange
            Patient p1 = new Patient("A", "B", "3-2-2001", 111222333);
            Patient p2 = new Patient("C", "D", "4-5-2006", 123456782);
            Mock<IPatientSerializer> psMock = new Mock<IPatientSerializer>();
            psMock.Setup(ps => ps.StartSerialize()).Returns(true);
            psMock.Setup(ps => ps.Serialize(It.IsAny<Patient>())).Returns(false);
            psMock.Setup(ps => ps.EndSerialize()).Returns(true);
            PatientDatabase db = new PatientDatabase(psMock.Object);
            db.AddPatient(p1);
            db.AddPatient(p2);

            // act
            bool success = db.WritePatients();

            // assert
            Assert.IsFalse(success);
        }
    }
}