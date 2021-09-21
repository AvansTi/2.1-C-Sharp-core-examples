using System;

namespace PatientDatabase
{
    [Serializable]
    public class Patient
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }

        private ulong? bsn; // Dutch "Burger Service Nummer"
        public ulong? BSN
        {
            get { return bsn; }
            set
            {
                if (value.HasValue && IsValidBSN(value.Value)) bsn = value;
                else throw new ArgumentException("Invalid BSN value");
            }
        }

        public Patient()
        {
        }

        public Patient(string fn, string ln, string bd, ulong bsn)
        {
            FirstName = fn;
            LastName = ln;
            SetBirthDate(bd);
            BSN = bsn;
        }

        public void SetName(string newFirstName, string newLastName)
        {
            FirstName = newFirstName;
            LastName = newLastName;
        }

        public string GetName()
        {
            return $"{FirstName} {LastName}";
        }

        public void SetBirthDate(string birthDate)
        {
            DateTime date;
            if (!DateTime.TryParse(birthDate, out date)) 
                throw new ArgumentException("Invalid birth date");
            BirthDate = date;
        }

        public override string ToString()
        {
            return $"[{FirstName} {LastName} - {BSN} - {(BirthDate.HasValue ? BirthDate.Value.ToShortDateString() : "no birthdate")}]";
        }

        private static bool IsValidBSN(ulong potentialBSN)
        {
            // Perform validity check on BSN
            // Source: https://nl.wikipedia.org/wiki/Burgerservicenummer#11-proef
            if (potentialBSN < 100000000 || potentialBSN > 999999999) // Check that length of potentialBSN is 9 digits
                return false;
            // Perform "elfproef" on the potential BSN
            long calc = 0;
            for (uint p = 1; p <= 9; p += 1)
            {
                uint digit = (uint)(potentialBSN % 10);
                if (p == 1)
                    calc -= digit;
                else
                    calc += digit * p;
                potentialBSN /=  10;
            }
            return calc % 11 == 0;
        }
    }
};
