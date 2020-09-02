using System;
using System.Collections.Generic;
using System.Text;

namespace Woning
{
    class Huis : Woning
    {
        public uint GrondOppervlakte { get; private set; }
        public HuisType Type { get; set; }

        public Huis(string adres, decimal? prijs, uint gOpp
                , HuisType type = HuisType.TussenWoning)

            : base(adres, prijs)
        {
            GrondOppervlakte = gOpp;
            Type = type;
        }

        public override string ToString(){ 
            return base.ToString() + " " + GrondOppervlakte + " " + Type; 
        }
    }

    enum HuisType{ 
        TussenWoning, 
        HoekHuis, 
        Vrijstaand, 
        TweeOnderKap
    }

}
