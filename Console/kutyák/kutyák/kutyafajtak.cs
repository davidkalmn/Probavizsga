using System;
using System.Collections.Generic;
using System.Text;

namespace kutyák
{
    class kutyafajtak
    {
        public int id { get; set; }
        public string nev { get; set; }
        public string eredetinev { get; set; }

        public kutyafajtak(string[] fajlnev)
        {
            id = int.Parse(fajlnev[0]);
            nev = fajlnev[1];
            eredetinev = fajlnev[2];
        }
    }
}
