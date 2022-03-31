using System;
using System.IO;
using System.Collections.Generic;

namespace Console_probavizsga
{
    class Program
    {
        static public string tengerszint = "";
        static public List<tura> turak = new List<tura>();
        static void Main(string[] args)
        {

            Beolvas("kektura.csv");

            Console.WriteLine("Összes adat: {0}", turak.Count);

            Teljeshossz();
            Legkisebb();
            Hianyos();
            Legmagasabb();
            Kiir();

            Console.WriteLine("\n");
        }
        static public void Beolvas(string fajl)
        {
            StreamReader sr = new StreamReader(fajl);
            tengerszint = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adatok = sor.Split(";");
                tura tura = new tura(adatok);
                turak.Add(tura);
            }
            sr.Close();

        }
        static public void Teljeshossz()
        {
            double teljeshossz = 0;
            foreach (var item in turak)
            {
                teljeshossz += item.hossz;
            }
            Console.Write("A túra teljes hossza: {0:f} km\n", teljeshossz);
        }
        static public void Legkisebb()
        {
            double minHossz = double.MaxValue;
            foreach (var item in turak)
            {
                if (item.hossz < minHossz)
                {
                    minHossz = item.hossz;
                }
            }
            foreach (var item in turak)
            {
                if (minHossz == item.hossz)
                {
                    Console.WriteLine("A túra legrövidebb szakasza:");
                    Console.WriteLine("{0} - {1} - {2}", item.kiindulopont, item.vegpont, item.hossz);
                }
            }
            

        }
        static public void Hianyos()
        {
            bool asd = true;
            foreach (var item in turak)
            {
                if (item.HianyosNev == true)
                {
                    Console.Write(" {0},", item.vegpont);
                    asd = false;
                }
            }
            if (asd == true)
            {
                Console.WriteLine("Nincs hiányos állomásnév!");
            }
            Console.WriteLine("\n");
        }
        static public void Legmagasabb()
        {
            double legmagasabb = 0;
            foreach (var item in turak)
            {
                double magaspont = item.emelkedes - item.lejtes;
                if (magaspont > legmagasabb)
                {
                    legmagasabb = magaspont;
                }
            }
            double emelkedes = double.Parse(tengerszint);
            foreach (var item in turak)
            {
                emelkedes += (item.emelkedes - item.lejtes);
            }
            Console.WriteLine(emelkedes);
        }
        static public void Kiir()
        {
            StreamWriter sw = new StreamWriter("kektura2.csv");
            sw.WriteLine(tengerszint);

            foreach (var item in turak)
            {
                if (item.HianyosNev == true)
                {
                    sw.WriteLine("{0};{1};{2} pecsetelohely;{3};{4};{5}",
                    item.kiindulopont, item.vegpont, item.hossz, item.emelkedes, item.lejtes, item.pecset);
                }
                else
                {
                    sw.WriteLine("{0};{1};{2};{3};{4};{5}",
                    item.kiindulopont, item.vegpont, item.hossz, item.emelkedes, item.lejtes, item.pecset);
                }
                
            }

            sw.Close();

        }

    }
}
