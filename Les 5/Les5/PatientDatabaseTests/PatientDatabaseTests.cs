using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientDatabase;

namespace PatientDatabaseTests
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
            PatientDatabase.PatientDatabase db = new PatientDatabase.PatientDatabase(ps);

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
            PatientDatabase.PatientDatabase db = new PatientDatabase.PatientDatabase(ps);

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
            PatientDatabase.PatientDatabase db = new PatientDatabase.PatientDatabase(ps);
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
            PatientDatabase.PatientDatabase db = new PatientDatabase.PatientDatabase(psMock.Object);
            db.AddPatient(p1);
            db.AddPatient(p2);

            // act
            bool success = db.WritePatients();

            // assert
            Assert.IsFalse(success);
        }
    }
}
