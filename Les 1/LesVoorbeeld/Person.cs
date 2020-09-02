using System;
using System.Collections.Generic;
using System.Text;

namespace LesVoorbeeld
{
    class Person
    {
        public string Name { get; set; }
        public DateTime Birthday { get; private set; }

        public Person(string name, DateTime birthDay)
        {
            this.Name = name;
            this.Birthday = birthDay;
        }

        public String BirthdayString
        {
            set
            {
                this.Birthday = DateTime.Parse(value);
            }
            get
            {
                return this.Birthday.ToShortDateString();
            }
        }
    }
}
