using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Console_probavizsga
{
    class tura
    {
        public string kiindulopont { get; set; }
        public string vegpont { get; set; }
        public double hossz { get; set; }
        public double emelkedes { get; set; }
        public double lejtes { get; set; }
        public string pecset { get; set; }
        public bool HianyosNev { get; set; }

        public tura(string[] fajlnev)
        {
            kiindulopont = fajlnev[0];
            vegpont = fajlnev[1];
            hossz = double.Parse(fajlnev[2]);
            emelkedes = double.Parse(fajlnev[3]);
            lejtes = double.Parse(fajlnev[4]);
            pecset = fajlnev[5];

            if (pecset == "i")
            {
                if (vegpont.Contains("pecsetelohely"))
                {
                    HianyosNev = false;
                }
                else
                {
                    HianyosNev = true;
                }
            }
        }


    }
}
