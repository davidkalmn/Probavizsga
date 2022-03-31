using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kutyák
{
    class Program
    {
        static List<kutyanevek> kutyaneveks = new List<kutyanevek>();
        static List<kutyafajtak> kutyafajtaks = new List<kutyafajtak>();
        static List<kutyak> kutyak = new List<kutyak>();
        static Dictionary<int, int> hanyfajta = new Dictionary<int, int>();
        static Dictionary<string, int> hanyfajtavege = new Dictionary<string, int>();
        static Dictionary<string, int> rendelo = new Dictionary<string, int>();
        static Dictionary<string, int> fajlbanevek = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            BeolvasKutyanevek();
            BeolvasKutyafajtak();
            BeolvasKutyak();
            Rendelo();

            Console.WriteLine("3. feladat: {0} kutyanév található a rendszerben.", kutyanevekcount());
            Console.WriteLine("6. feladat: A kutyák átlagéletkora: {0}", kutyaatlageletkor());
            Console.WriteLine("7. feladat: {0}", Legidosebb());
            Console.WriteLine("8. feladat: Január 10-én vizsgált kutyák:");
            foreach (var item in hanyfajtavege)
            {
                Console.WriteLine("\t{0}: {1} kutya", item.Key, item.Value);
            }
            Console.WriteLine("9.feladat: Legjobban terhelt nap: {0}", Terheles());
            Console.WriteLine("10. feladat: Névstatisztika.txt");

            Kiiras();


            Console.WriteLine('\n');
        }
        public static void BeolvasKutyanevek()
        {
            StreamReader sr = new StreamReader("KutyaNevek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                kutyanevek kutyanev = new kutyanevek(adatok);
                kutyaneveks.Add(kutyanev);
            }
            sr.Close();
        }
        public static void BeolvasKutyafajtak()
        {
            StreamReader sr = new StreamReader("KutyaFajtak.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                kutyafajtak kutyafajta = new kutyafajtak(adatok);
                kutyafajtaks.Add(kutyafajta);
            }
            sr.Close();
        }
        public static void BeolvasKutyak()
        {
            StreamReader sr = new StreamReader("Kutyak.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                kutyak kutya = new kutyak(adatok);
                kutyak.Add(kutya);
            }
            sr.Close();
        }
        public static int kutyanevekcount()
        {
            return kutyaneveks.Count;
        }
        public static double kutyaatlageletkor()
        {
            double ossz = 0;
            foreach (var item in kutyak)
            {
                ossz += item.kutyaeletkor;
            }
            double atlag = ossz / kutyak.Count;
            return atlag;
        }
        public static string Legidosebb()
        {
            string vissza = "";
            double maxeletkor = 0;
            int kutyanev = 0;
            int kutyafajta = 0;
            foreach (var item in kutyak)
            {
                if (item.kutyaeletkor > maxeletkor)
                {
                    maxeletkor = item.kutyaeletkor;
                    kutyanev = item.kutyanevAzon;
                    kutyafajta = item.kutyafajtaAzon;
                }
            }
            foreach (var item in kutyaneveks)
            {
                if (item.azonosito == kutyanev)
                {
                    vissza += item.kutyanev;
                }
            }
            vissza += ", ";
            foreach (var item in kutyafajtaks)
            {
                if (item.id == kutyafajta)
                {
                    vissza += item.nev;
                }
            }
            
            return vissza;
        }
        public static void Rendelo() {
            foreach (var item in kutyak)
            {
                if (item.orvosivizsgalatIdo == "2018.01.10")
                {
                    if (!hanyfajta.ContainsKey(item.kutyafajtaAzon))
                    {
                        hanyfajta.Add(item.kutyafajtaAzon, 1);
                    }
                    else
                    {
                        hanyfajta[item.kutyafajtaAzon]++;
                    }
                }
            }
            foreach (var item in kutyafajtaks)
            {
                foreach (var itemm in hanyfajta)
                {
                    if (itemm.Key == item.id)
                    {
                        hanyfajtavege.Add(item.nev, itemm.Value);
                    }
                }
            }
        }
        public static string Terheles()
        {
            string vissza = "";
            foreach (var item in kutyak)
            {
                if (!rendelo.ContainsKey(item.orvosivizsgalatIdo))
                {
                    rendelo.Add(item.orvosivizsgalatIdo, 1);
                }
                else
                {
                    rendelo[item.orvosivizsgalatIdo]++;
                }
            }
            int max = 0;
            string idopont = "";
            foreach (var item in rendelo)
            {
                if (max < item.Value)
                {
                    idopont = item.Key;
                    max = item.Value;
                }
            }
            vissza += idopont;
            vissza += ".: ";
            vissza += max;
            vissza += " kutya";
            return vissza;
        }
        public static void Kiiras()
        {
            foreach (var item in kutyak)
            {
                foreach (var itemm in kutyaneveks)
                {
                    if (item.kutyanevAzon == itemm.azonosito)
                    {
                        if (!fajlbanevek.ContainsKey(itemm.kutyanev))
                        {
                            fajlbanevek.Add(itemm.kutyanev, 1);
                        }
                        else
                        {
                            fajlbanevek[itemm.kutyanev]++;
                        }
                    }
                }
            }
            StreamWriter sw = new StreamWriter("Névstatisztika.txt");
            foreach (KeyValuePair<string, int> author in fajlbanevek.OrderByDescending(key => key.Value))
            {
                sw.WriteLine("{0};{1}", author.Key, author.Value);
            }


            sw.Close();
        }
    }
}
