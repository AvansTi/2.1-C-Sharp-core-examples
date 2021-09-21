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
