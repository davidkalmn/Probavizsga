using System;
using System.IO;
using System.Collections.Generic;

namespace Probavizsga_v2
{
    class Program
    {
        static public List<Ad> ads = new List<Ad>();
        static public List<Seller> sellers = new List<Seller>();
        static public List<Category> categories = new List<Category>();
        static void Main(string[] args)
        {
            LoadFromCsv("realestates.csv");
            FoldszintiIngatlanokAtlaga();

            double mintavolsag = double.MaxValue;
            string name = "asd";
            foreach (var item in ads)
            {
                if (item.FreeOfCharge == true)
                {
                    if (item.DistanceTo(47.4164220114023, 19.066342425796986) < mintavolsag)
                    {
                        mintavolsag = item.DistanceTo(47.4164220114023, 19.066342425796986);
                        name = item.LatLong;
                    }
                }
            }
            foreach (var item in ads)
            {
                if (name == item.LatLong)
                {
                    Console.WriteLine("Alapterület: {0}", item.Area);
                }
            }

            Console.ReadKey();
        }

        static void LoadFromCsv(string fajlnev)
        {
            StreamReader sr = new StreamReader(fajlnev);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                Ad ad = new Ad(adatok);
                Seller seller = new Seller(adatok[7], adatok[8]);
                Category category = new Category(adatok[9]);

                ads.Add(ad);
                sellers.Add(seller);
                categories.Add(category);
            }
            sr.Close();
        }
        static void FoldszintiIngatlanokAtlaga()
        {
            double terulet = 0;
            int db = 0;
            foreach (var item in ads)
            {
                if (item.Floors == 0)
                {
                    terulet += item.Area;
                    db++;
                }
            }
            Console.WriteLine("A földszinti ingatlanok alapterületének átlaga: {0:f2} m2", terulet / db);
        }
    }
}
