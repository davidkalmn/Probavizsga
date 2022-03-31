using System;
using System.Collections.Generic;
using System.Text;

namespace autok
{
    class igenyek
    {
        public string azonosito { get; set; }
        public string indulas { get; set; }
        public string cel { get; set; }
        public int szemely { get; set; }

        public igenyek(string[] fajlnev)
        {
            azonosito = fajlnev[0];
            indulas = fajlnev[1];
            cel = fajlnev[2];
            szemely = int.Parse(fajlnev[3]);
        }
    }
}
