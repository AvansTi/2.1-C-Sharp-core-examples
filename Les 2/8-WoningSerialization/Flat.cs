using System;
using System.Collections.Generic;
using System.Text;

namespace _8_WoningSerialization
{
    [Serializable]
    public class Flat : Woning
    {

        private float BijdrageVVE { get; set; }

        public Flat(string adres, decimal prijs, float bijdrageVVE)

            : base(adres, prijs)
        {
            BijdrageVVE = bijdrageVVE;
        }
    }
}
