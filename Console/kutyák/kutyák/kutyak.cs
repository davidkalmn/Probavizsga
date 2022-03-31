using System;
using System.Collections.Generic;
using System.Text;

namespace kutyák
{
    class kutyak
    {
        public int vizsgaAzon { get; set; }
        public int kutyafajtaAzon { get; set; }
        public int kutyanevAzon { get; set; }
        public double kutyaeletkor { get; set; }
        public string orvosivizsgalatIdo { get; set; }

        public kutyak(string[] fajlnev)
        {
            vizsgaAzon = int.Parse(fajlnev[0]);
            kutyafajtaAzon = int.Parse(fajlnev[1]);
            kutyanevAzon = int.Parse(fajlnev[2]);
            kutyaeletkor = double.Parse(fajlnev[3]);
            orvosivizsgalatIdo = fajlnev[4];
        }
    }
}
