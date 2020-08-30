using System;

namespace TestPersoon {
    [Serializable]
    class Persoon {

        public string Naam { get; set; }

        //  private DateTime geboortedag;
        public DateTime Geboortedag {
            get;// { return geboortedag; }
            set;// { geboortedag = value; }
        }

        public Persoon(string naam, DateTime geboortedag) {
            Naam = naam;
            Geboortedag = geboortedag;
        }


        public int Leeftijd {
            get { return GetLeeftijd(); }
        }



        private int GetLeeftijd() {
            DateTime now = DateTime.Today;
            int leeftijd = now.Year - Geboortedag.Year;
            if (Geboortedag > now.AddYears(-leeftijd))
                leeftijd--;
            
            return leeftijd;
        }

        public override string ToString() {
            return Naam + " " + Leeftijd + " jaar";
        }

    }
}
