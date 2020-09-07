using System;
using System.Collections.Generic;
using System.Text;

namespace _8_WoningSerialization
{
    [Serializable]
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

        public override string ToString()
        {
            return base.ToString() + " " + GrondOppervlakte + " " + Type;
        }
    }


}
