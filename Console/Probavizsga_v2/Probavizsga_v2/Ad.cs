using System;
using System.Collections.Generic;
using System.Text;

namespace Probavizsga_v2
{
    class Ad
    {
        public int Area { get; set; }
        public string Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public string Seller { get; set; }

        public Ad(string[] adatok)
        {
            Rooms = int.Parse(adatok[0]);
            LatLong = adatok[1];
            Floors = int.Parse(adatok[2]);
            Area = int.Parse(adatok[3]);
            Description = adatok[4];
            if (adatok[5] == "0")
            {
                FreeOfCharge = false;
            }
            else
            {
                FreeOfCharge = true;
            }
            ImageUrl = adatok[6];
            Seller = adatok[7];
            Category = adatok[9];
            CreateAt = DateTime.Parse(adatok[10]);
        }
        public double DistanceTo(double x, double y)
        {
            double dx = Convert.ToDouble(this.LatLong.Split(",")[0].Replace(".", ",")) - x;
            double dy = Convert.ToDouble(this.LatLong.Split(",")[0].Replace(".", ",")) - y;

            double dc = Math.Sqrt(dx * dx + dy * dy);
            return dc;
        }
    }
}
