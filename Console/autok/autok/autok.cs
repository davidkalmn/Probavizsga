using System;
using System.Collections.Generic;
using System.Text;

namespace autok
{
    class autok
    {
        public string indulas { get; set; }
        public string cel { get; set; }
        public string rendszam { get; set; }
        public string telefonszam { get; set; }
        public int ferohely { get; set; }

        public autok(string[] fajlnev)
        {
            indulas = fajlnev[0];
            cel = fajlnev[1];
            rendszam = fajlnev[2];
            telefonszam = fajlnev[3];
            ferohely = int.Parse(fajlnev[4]);

        }
    }
}
