using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient patient1 = new Patient();
            patient1.SetName("Per", "Ongeluk");
            patient1.BSN = 111222333;
            patient1.SetBirthDate("2002-09-01");
            Console.WriteLine($"Patient {patient1.GetName()} has BSN {patient1.BSN}");

            Patient patient2 = new Patient();
            patient2.SetName("Cory", "Fee");
            patient2.BSN = 123456782;
            patient2.SetBirthDate("1998-04-02");
            Console.WriteLine($"Patient {patient2.GetName()} has BSN {patient2.BSN}");

            PatientSerializer ps = new PatientSerializer("patientdatabase.json");
            PatientDatabase database = new PatientDatabase(ps);
            database.AddPatient(patient1);
            database.AddPatient(patient2);
            Console.WriteLine($"Database contains:\n{database}");

            Patient pat = database.FindPatient("Ongeluk");
            Console.WriteLine($"Patient with lastname \"Ongeluk\" is {pat}");

            Console.WriteLine($"Writing database to file...");
            bool successfulWrite = database.WritePatients();
            Console.WriteLine($"...done (success = {successfulWrite})");

            PatientDatabase database2 = new PatientDatabase(ps);
            Console.WriteLine($"Reading back from file into a new database...");
            bool successfulRead = database2.ReadPatients();
            Console.WriteLine($"...done (success = {successfulRead})");
            Console.WriteLine($"Database read from file:\n{database2}");

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
