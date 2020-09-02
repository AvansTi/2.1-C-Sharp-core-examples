using System;
using System.Collections.Generic;
using System.Text;

namespace Woning
{
    class WoningMarkt
    {

        // ArrayList is geen generieke collectie in tegenstelling tot List<T>
        private List<Woning> woningen;


        public WoningMarkt()
        {
            this.woningen = new List<Woning>();
        }

        public void AddWoning(Woning woning)
        {
            this.woningen.Add(woning);
        }


        public void zoekPrijsBereik(out decimal goedkoopste, out decimal duurste)
        {
            goedkoopste = decimal.MaxValue;
            duurste = decimal.MinValue;

            foreach (var woning in woningen)
            {
                if (!woning.Prijs.HasValue) { continue; }

                decimal woningPrijs = (decimal)woning.Prijs;
                if (woningPrijs < goedkoopste) { goedkoopste = woningPrijs; }
                if (woningPrijs > duurste) { duurste = woningPrijs; }
            }
        }
    }
}
