using System;
using System.Collections.Generic;
using System.Text;

namespace Woning
{
    class Woning
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
