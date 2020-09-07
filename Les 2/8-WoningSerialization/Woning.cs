using System;
using System.Collections.Generic;
using System.Text;

namespace _8_WoningSerialization
{

    public enum HuisType
    {
        TussenWoning,
        HoekHuis,
        Vrijstaand,
        TweeOnderKap,
        Flat
    }

    [Serializable]
    public class Woning
    {
        public string Adres { get; }
        public decimal? Prijs { get; set; }

        public Woning(string adres) : this(adres, null)
        { }

        public Woning(string adres, decimal? prijs)
        { Adres = adres; Prijs = prijs; }

        public override string ToString()
        {
            return Adres + " "
              + (Prijs.HasValue ? Prijs.ToString() : "prijs op aanvraag");
        }

        public void WijzigPrijs(decimal nieuwePrijs)
        {
            Prijs = nieuwePrijs;
        }



    }
}
