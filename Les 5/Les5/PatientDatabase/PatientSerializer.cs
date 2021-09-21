using Newtonsoft.Json;
using System;
using System.IO;

namespace PatientDatabase
{
    public class PatientSerializer : IPatientSerializer
    {
        private string path;
        private StreamReader reader;
        private StreamWriter writer;

        public PatientSerializer(string path)
        {
            this.path = path;
        }

        public bool StartSerialize()
        {
            if (path == null) return false;
            try
            {
                if (File.Exists(path))
                {
                    Console.WriteLine($"Deleting existing file \"{path}\"");
                    File.Delete(path);
                }
                writer = new StreamWriter(path, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool EndSerialize()
        {
            writer.Flush();
            writer.Close();
            writer.Dispose();
            writer = null;
            return true;
        }

        public bool StartDeserialize()
        {
            if (path == null) return false;
            try
            {
                reader = new StreamReader(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool EndDeserialize()
        {
            reader.Close();
            reader.Dispose();
            reader = null;
            return true;
        }
        public bool Serialize(Patient p)
        {
            bool success = true;
            if (writer == null)
            {
                return false;
            }
            try
            {
                string json = JsonConvert.SerializeObject(p);
                writer.WriteLine(json);
                writer.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return success;
        }

        public bool Deserialize(out Patient p)
        {
            bool success = true;
            p = null;
            if (reader == null)
            {
                return false;
            }
            try
            {
                string json;
                if ((json = reader.ReadLine()) != null)
                {
                    dynamic pat = JsonConvert.DeserializeObject(json);
                    p = new Patient();
                    string fn = pat.FirstName;
                    string ln = pat.LastName;
                    p.SetName(fn, ln);
                    string bd = pat.BirthDate;
                    p.SetBirthDate(bd);
                    ulong bsn = pat.BSN;
                    p.BSN = bsn;
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return success;
        }
    }
}
