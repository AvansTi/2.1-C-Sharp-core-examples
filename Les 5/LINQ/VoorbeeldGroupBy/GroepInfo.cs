using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoorbeeldGroupBy
{
    class GroepInfo
    {
        private List<Student> studenten = new List<Student>();
        
        public List<Student> Studenten
        {
            get { return studenten; }
        }
        
        public GroepInfo ()
        {
            studenten.Add(new Student("Jairo", "Van B naar Cultuur", 1));
            studenten.Add(new Student("Cas", "Discover Breda On-Point", 6));
            studenten.Add(new Student("Menno", "Van B naar Cultuur", 1));
            studenten.Add(new Student("Jan-Willem", "Breda On-Point", 2));
            studenten.Add(new Student("Hugo", "Op pad in Breda On-Point", 5));
            studenten.Add(new Student("Nick", "GO!", 4));
            studenten.Add(new Student("Rick", "Breda On-Point", 2));
            studenten.Add(new Student("Bilel", "GO!", 4));
            studenten.Add(new Student("Justin", "Route on Point", 3));
            studenten.Add(new Student("Joey", "Breda On-Point", 2));
            studenten.Add(new Student("Martijn", "Discover Breda On-Point", 6));
            studenten.Add(new Student("Rico", "Route on Point", 3));
            studenten.Add(new Student("Floris Bob", "GO!", 4));
            studenten.Add(new Student("Harmen", "Van B naar Cultuur", 1));
            studenten.Add(new Student("Nick", "GO!", 4));
            studenten.Add(new Student("Timon", "Op pad in Breda On-Point", 5));
            studenten.Add(new Student("Max", "Breda On-Point", 2));
            studenten.Add(new Student("Melany", "Op pad in Breda On-Point", 5));
            studenten.Add(new Student("Bart", "Van B naar Cultuur", 1));
            studenten.Add(new Student("Jacob", "GO!", 4));
            studenten.Add(new Student("Kevin", "Route on Point", 3));
            studenten.Add(new Student("Cas", "Breda On-Point", 2));
            studenten.Add(new Student("Kadir", "Op pad in Breda On-Point", 5));
            studenten.Add(new Student("Michael", "Discover Breda On-Point", 6));

            studenten.Add(new Student("Camiel", "Route on Point", 3));
            studenten.Add(new Student("Christiaan", "Van B naar Cultuur", 1));
            studenten.Add(new Student("Duc", "GO!", 4));
            studenten.Add(new Student("Joshua", "Discover Breda On-Point", 6));
            studenten.Add(new Student("Sascha", "Breda On-Point", 2));
            studenten.Add(new Student("Berend", "Op pad in Breda On-Point", 5));

            studenten.Add(new Student("Stefan", "Route on Point", 3));
            studenten.Add(new Student("Cézan", "Discover Breda On-Point", 6));
            studenten.Add(new Student("Nard", "Van B naar Cultuur", 1));
            studenten.Add(new Student("Thijs", "Op pad in Breda On-Point", 5));
            studenten.Add(new Student("Gijs", "Route on Point", 3));
            studenten.Add(new Student("Sander", "Discover Breda On-Point", 6));

        }

        public IOrderedEnumerable<IGrouping<int, Student>> GeefGroepen()
        {
            var groepen = from student in studenten
                          group student by student.GroepNr into grp
                          orderby grp.Key select grp;

            return groepen;
        }

        
    }

    class Student
    {
        public string Naam { get; set; }
        public string Groep { get; set; }
        public int GroepNr { get; set; }

        public Student(string naam, string groep,int groepNr)
        {
            this.Naam = naam;
            this.Groep = groep;
            this.GroepNr = groepNr;
        }
    }
}
