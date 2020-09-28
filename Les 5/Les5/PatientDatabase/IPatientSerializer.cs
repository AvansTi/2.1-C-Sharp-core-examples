using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDatabase
{
    public interface IPatientSerializer
    {
        bool StartSerialize();
        bool Serialize(Patient p);
        bool EndSerialize();
        bool StartDeserialize();
        bool Deserialize(out Patient p);
        bool EndDeserialize();
    }
}
