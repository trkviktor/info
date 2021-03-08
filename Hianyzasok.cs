using System;
using System.IO;
using System.Collections.Generic;

namespace Hianyzasok
{
    class Program
    {
        struct sor
        {
            public string nev;
            public string hianyzasok;
            public int nap;
            public int honap;
        }

        public static string hetnapja(int honap, int nap)
        {
            string[] napnev = { "vasarnap", "hetfo", "kedd", "szerda", "csutortok", "pentek", "szombat" };
            int[] napszam = { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 335 };
            int napsorszam = (napszam[honap - 1] + nap) % 7;
            string hetnapja = napnev[napsorszam];
            return hetnapja;
        }

        static void Main(string[] args)
        {
            sor[] hianyzasok = new sor[600];
            StreamReader sr = new StreamReader("naplo.txt");
            int db = 0;
            while (!sr.EndOfStream)
            {
                string[] temp1 = sr.ReadLine().Split(' ');
                while (!sr.EndOfStream && sr.Peek() != '#')
                {
                    string[] temp2 = sr.ReadLine().Split(' ');
                    hianyzasok[db].honap = int.Parse(temp1[1]);
                    hianyzasok[db].nap = int.Parse(temp1[2]);
                    hianyzasok[db].nev = temp2[0] + " " + temp2[1];
                    hianyzasok[db].hianyzasok = temp2[2];
                    db++;
                }
            }
            sr.Close();

            Console.WriteLine("2. feladat\nA naplóban {0} bejegyzés van.",db);
            Console.WriteLine("3. feladat");
            int igazolt=0, igazolatlan=0;
            for (int i = 0; i < db; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (hianyzasok[i].hianyzasok[j] == 'X')
                    {
                        igazolt++;
                    }
                    if (hianyzasok[i].hianyzasok[j] == 'I')
                    {
                        igazolatlan++;
                    }
                }
                
            }
            Console.WriteLine("Az igazolt hiányzások száma {0}, az igazolatlanoké {1} óra.",igazolt, igazolatlan);
            Console.WriteLine("5.feladat");
            Console.Write("A hónap sorszáma=");
            int honapSorszam = int.Parse(Console.ReadLine());
            Console.Write("A nap sorszáma=");
            int napSorszam = int.Parse(Console.ReadLine());
            Console.WriteLine("Azon a napon {0} volt.",hetnapja(honapSorszam, napSorszam));
            Console.WriteLine("6.Feladat");
            Console.Write("A nap neve=");
            string napNev = Console.ReadLine();
            Console.Write("Az óra sorszáma=");
            int orasorSzam = int.Parse(Console.ReadLine());

            int napNevHianyzasok = 0;
            for (int i = 0; i < db; i++)
            {
                if (hetnapja(hianyzasok[i].honap, hianyzasok[i].nap) == napNev)
                {
                    
                        if (hianyzasok[i].hianyzasok[orasorSzam-1] == 'X')
                        {
                            napNevHianyzasok++;
                        }
                        if (hianyzasok[i].hianyzasok[orasorSzam-1] == 'I')
                        {
                            napNevHianyzasok++;
                        }

                }
            }
            Console.WriteLine("Ekkor összesen {0} óra hiányzás történt.", napNevHianyzasok);

            Console.WriteLine("7. feladat");
            Console.Write("A legtöbbet hiányzó tanulók: ");

            List<string> nevek = new List<string>();
            

            for (int i = 0; i < db; i++)
            {
                if (!nevek.Contains(hianyzasok[i].nev))
                {
                    nevek.Add(hianyzasok[i].nev);
                }
            }

            int[] hianyzasokTomb = new int[nevek.Count];

            for (int i = 0; i < db; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (hianyzasok[i].hianyzasok[j] == 'X' || hianyzasok[i].hianyzasok[j] == 'I')
                    {
                        hianyzasokTomb[nevek.IndexOf(hianyzasok[i].nev)]++;
                    }
                }
                
            }
            int maxindex = 0;
            for (int i = 1; i < hianyzasokTomb.Length; i++)
            {
                if (maxindex < hianyzasokTomb[i])
                {
                    maxindex = hianyzasokTomb[i];
                }
            }
            for (int i = 0; i < hianyzasokTomb.Length; i++)
            {
                if (maxindex == hianyzasokTomb[i])
                {
                    Console.Write(nevek[i] + " ");
                }
            }

        }
    }
}
