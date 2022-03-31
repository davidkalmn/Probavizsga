using System;
using System.Collections.Generic;
using System.Text;

namespace kutyák
{
    class kutyanevek
    {
        public int azonosito { get; set; }
        public string kutyanev { get; set; }

        public kutyanevek(string[] fajlnev)
        {
            azonosito = int.Parse(fajlnev[0]);
            kutyanev = fajlnev[1];
        }

    }
}
