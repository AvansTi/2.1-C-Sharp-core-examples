using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Input;
using WPFExample.Utils;

namespace WPFExample
{
    public class StudentViewModel : ObservableObject
    {
        private ObservableCollection<Student> mStudents;
        private Student mSelectedStudent = null;

        public StudentViewModel()
        {
            mStudents = new ObservableCollection<Student>
            {
                new Student{StudentNumber = 1,FirstName="Jan",LastName="Jansen",City="Breda",Country="Nederland"},
                new Student{StudentNumber=2,FirstName="Piet",LastName="Pietersen",City="Oosterhout", Country="Nederland"},
                new Student{StudentNumber=3,FirstName="Sjaak",LastName="Bonestaak",City="Antwerpen", Country="Belgie"}
            };
        }

        public ObservableCollection<Student> Students
        {
            get { return mStudents; }
            set { 

                mStudents = value;
                NotifyPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get { return mSelectedStudent; }
            set
            {
                if (mSelectedStudent != value)
                {
                    if (mSelectedStudent == null)
                    {
                        mSelectedStudent = new Student();
                    }
                    mSelectedStudent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ICommand mSaveDataCommand;
        public ICommand SaveDataCommand
        {
            get
            {
                if (mSaveDataCommand == null)
                {
                    mSaveDataCommand = new RelayCommand(
                        (dialogType) => {
                            var dialogTypes = dialogType as Type;
                            IFileDialogWindow dlgObj;
                            if (dialogTypes != null)
                                dlgObj = Activator.CreateInstance(dialogType as Type) as IFileDialogWindow;
                            else
                                dlgObj = dialogType as IFileDialogWindow;
                            var fileNames = dlgObj?.ExecuteFileDialog(null, "JSON|*.json");
                            if (fileNames.Count > 0)
                            {
                                SaveData(fileNames[0]);
                            }
                        },
                    param => (Students.Count > 0));
                }
                return mSaveDataCommand;
            }
        }

        private ICommand mAddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (mAddCommand == null)
                {
                    mAddCommand = new RelayCommand(
                        param => AddUser(),
                        param => (true));
                }
                return mAddCommand;
            }
        }


        private ICommand mLoadDataCommand;
        public ICommand LoadDataCommand
        {
            get
            {
                if (mLoadDataCommand == null)
                {
                    mLoadDataCommand = new RelayCommand(
                        (dialogType) => {
                            var dlgObj = Activator.CreateInstance(dialogType as Type) as IFileDialogWindow;
                            var fileNames = dlgObj?.ExecuteFileDialog(null, "JSON|*.json");
                            if (fileNames.Count > 0)
                            {
                                LoadData(fileNames[0]);
                            }
                        },
                        (param) => (true)
                        );
                }
                return mLoadDataCommand;
            }
        }

        private ICommand mDeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (mDeleteCommand == null)
                {
                    mDeleteCommand = new RelayCommand(
                        param => DeleteUser(),
                        param => (SelectedStudent != null));
                }
                return mDeleteCommand;
            }
        }

        private void DeleteUser()
        {
            if (SelectedStudent == null)
                return;

            Students.Remove(SelectedStudent);
            SelectedStudent = null;
            Debug.WriteLine($"Amount of students in List: {mStudents.Count}");
        }

        private void AddUser()
        {
            SelectedStudent = new Student();
            Students.Add(SelectedStudent);
        }

        private void SaveData(string fileName)
        {
            string jsonSave = JsonConvert.SerializeObject(Students);
            File.WriteAllText(fileName, jsonSave);
        }


        private void LoadData(string fileName)
        {
            string jsonInput = File.ReadAllText(fileName);
            Students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(jsonInput);
        }


    }
}
