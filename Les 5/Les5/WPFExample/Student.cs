using System;

namespace WPFExample
{

    // Source: https://www.c-sharpcorner.com/UploadFile/raj1979/simple-mvvm-pattern-in-wpf/
    public class Student : ObservableObject
    {
        
        public int StudentNumber { get; set; }

        public string FirstName{ get; set; }
        public string LastName { get; set; }


        public string FullName
        {
            get { return String.Format($"{FirstName} {LastName}"); }
        }

        public string City { get; set; }
        public string Country { get; set; }

    }
}
