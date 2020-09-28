using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFExample;

namespace WpfExampleTests
{
    [TestClass]
    public class StudentViewTest
    {
        private StudentViewModel studentViewModel;

        [TestInitialize]
        public void InitializeTest()
        {
            this.studentViewModel = new StudentViewModel();
        }



        [TestMethod]
        public void TestButtonEnabledNoStudents()
        {
            this.studentViewModel.Students.Clear();
            Assert.IsFalse(this.studentViewModel.SaveDataCommand.CanExecute(null));
        }

        [TestMethod]
        public void TestButtonEnabledWithStudents()
        {
            //this.studentViewModel.Students.Clear();
            Assert.IsTrue(this.studentViewModel.SaveDataCommand.CanExecute(null));
        }
    }
}
