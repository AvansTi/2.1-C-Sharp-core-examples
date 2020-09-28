using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    //[Serializable]
    public class PatientDatabase
    {
        private List<Patient> patients;
        private IPatientSerializer serializer;

        public PatientDatabase(IPatientSerializer ser)
        {
            patients = new List<Patient>();
            serializer = ser;
        }

        public bool AddPatient(Patient p)
        {
            if (patients.Contains(p))
                return false;
            else
                patients.Add(p);
            return true;
        }

        public Patient FindPatient(string lastName)
        {
            Patient p = patients.Find((pat) => pat.LastName == lastName);
            return p;
        }

        public bool WritePatients()
        {
            bool success = true;
            if (serializer.StartSerialize())
            {
                foreach (Patient p in patients)
                {
                    success = success && serializer.Serialize(p);
                }
            }
            else
            {
                success = false;
            }

            serializer.EndSerialize();
            return success;
        }

        public bool ReadPatients()
        {
            bool success = true;
            if (serializer.StartDeserialize())
            {
                Patient p;
                while (serializer.Deserialize(out p))
                {
                    if (p != null)
                    {
                        patients.Add(p);
                    }
                }
            }
            else
            {
                success = false;
            }

            serializer.EndDeserialize();
            return success;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Patient p in patients)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }
    }
}
