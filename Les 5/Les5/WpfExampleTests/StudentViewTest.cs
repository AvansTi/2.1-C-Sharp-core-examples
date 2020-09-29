using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using WPFExample;
using WPFExample.Utils;

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
            Assert.IsTrue(this.studentViewModel.LoadDataCommand.CanExecute(null));
            Assert.IsFalse(this.studentViewModel.DeleteCommand.CanExecute(null));
            Assert.IsTrue(this.studentViewModel.AddCommand.CanExecute(null));
        }

        [TestMethod]
        public void TestButtonEnabledWithStudents()
        {
            //this.studentViewModel.Students.Clear();
            Assert.IsTrue(this.studentViewModel.SaveDataCommand.CanExecute(null));
            Assert.IsTrue(this.studentViewModel.LoadDataCommand.CanExecute(null));
            Assert.IsFalse(this.studentViewModel.DeleteCommand.CanExecute(null));
            Assert.IsTrue(this.studentViewModel.AddCommand.CanExecute(null));
        }

        [TestMethod]
        public void TestButtonEnabledWithStudentsAndSelected()
        {
            //this.studentViewModel.Students.Clear();
            this.studentViewModel.SelectedStudent = this.studentViewModel.Students[0];
            Assert.IsTrue(this.studentViewModel.SaveDataCommand.CanExecute(null));
            Assert.IsTrue(this.studentViewModel.LoadDataCommand.CanExecute(null));
            Assert.IsTrue(this.studentViewModel.DeleteCommand.CanExecute(null));
            Assert.IsTrue(this.studentViewModel.AddCommand.CanExecute(null));
        }


        [TestMethod]
        public void TestSaveButton()
        {
            Mock<IFileDialogWindow> psMockFileIo = new Mock<IFileDialogWindow>();
 
            psMockFileIo.Setup(ps => ps.ExecuteFileDialog(null, "JSON|*.json")).Returns(new List<string>() { @"G:\test.json" });

            this.studentViewModel.SaveDataCommand.Execute(psMockFileIo.Object);

        }
    }
}
