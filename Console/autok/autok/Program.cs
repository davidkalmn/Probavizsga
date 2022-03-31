using System;
using System.IO;
using System.Collections.Generic;

namespace autok
{
    class Program
    {
        static List<autok> autok = new List<autok>();
        static List<igenyek> igenyek = new List<igenyek>();
        static Dictionary<string, string> fuvarok = new Dictionary<string, string>();
        static Dictionary<string, string> uzenetek = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            Beolvas1();
            Beolvas2();

            Console.WriteLine("2.feladat: {0} autós hirdet fuvart", autok.Count);
            Console.WriteLine("3. feladat: Összesen {0} férőhelyet hirdettek az autósok Budapestről miskolcra", BudapestMiskolc());
            Console.WriteLine(Legtobbhely());

            Igenyek();
            foreach (var item in fuvarok)
            {
                Console.WriteLine("{0} => {1}", item.Key, item.Value);
            }
            Console.WriteLine("Ennyi fuvar van összesen: {0}", fuvarok.Count);

            UtasUzenetek();

            Console.WriteLine("\n");
        }
        static void Beolvas1()
        {
            StreamReader sr = new StreamReader("autok.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(";");
                autok auto = new autok(adatok);
                autok.Add(auto);
            }
            sr.Close();
        }
        static void Beolvas2()
        {
            StreamReader sr = new StreamReader("igenyek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(";");
                igenyek igeny = new igenyek(adatok);
                igenyek.Add(igeny);
            }
            sr.Close();
        }
        static int BudapestMiskolc()
        {
            int ossz = 0;
            foreach (var item in autok)
            {
                if (item.indulas == "Budapest" && item.cel == "Miskolc")
                {
                    ossz += item.ferohely;
                }
            }
            return ossz;
        }
        static string Legtobbhely()
        {
            string vissza = "A legtöbb férőhelyet (";
            int max = 0;
            string cel = "";
            string indulas = "";
            foreach (var item in autok)
            {
                if (item.ferohely > max)
                {
                    max = item.ferohely;
                    cel = item.cel;
                    indulas = item.indulas;
                }
            }
            vissza += max + "-et) a " + indulas + "-" + cel + " útvonalon ajánlották fel a hirdetők.";

            return vissza;
        }
        static void Igenyek()
        {
            foreach (var item in igenyek)
            {
                foreach (var itemm in autok)
                {
                    if (itemm.indulas == item.indulas && itemm.cel == item.cel && itemm.ferohely >= item.szemely)
                    {
                        if (!fuvarok.ContainsKey(item.azonosito))
                        {
                            fuvarok.Add(item.azonosito, itemm.rendszam);
                            string uzenet = "Rendszám: "+ itemm.rendszam +", Telefonszám: " + itemm.telefonszam;
                            uzenetek.Add(item.azonosito, uzenet);
                        }
                    }
                }
            }
        }
        static void UtasUzenetek()
        {
            StreamWriter sw = new StreamWriter("utasuzenetek.txt");

            foreach (var item in igenyek)
            {
                if (!fuvarok.ContainsKey(item.azonosito))
                {
                    uzenetek.Add(item.azonosito, "Nem sikerült fuvart társítani!");
                }
            }
            
            foreach (var item in uzenetek)
            {
                sw.WriteLine("{0}: {1}", item.Key, item.Value);
            }
            sw.WriteLine(uzenetek.Count);
            sw.Close();
        }
    }
}
