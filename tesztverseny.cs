using System;
using System.IO;
using System.Collections.Generic;

namespace tesztverseny
{
    class Program
    {

        struct sor
        {
            public string azonosito;
            public string valaszok;
            public int pontok;
        }
        static void Main(string[] args)
        {
            //1. feladat
            sor[] eredmenyek = new sor[500];
            StreamReader sr = new StreamReader("valaszok.txt");
            string jovalaszok = sr.ReadLine();
            int db = 0;
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(' ');
                eredmenyek[db].azonosito = temp[0];
                eredmenyek[db].valaszok = temp[1];
                db++;
            }
            sr.Close();

            Console.WriteLine("1. feladat: Az adatok beolvasása\n");
            //2.feladat
            Console.WriteLine("2. feladat: A vetélkedőn {0} versenyző indult\n",db);
            //3.feladat
            Console.Write("3. feladat: A versenyző azonosítója = ");
            string azonosito_ = Console.ReadLine();
            int azonositoindex = 0;
            for (int i = 0; i < db; i++)
            {
                if (azonosito_ == eredmenyek[i].azonosito)
                {
                    Console.WriteLine(eredmenyek[i].valaszok + "\t(a versenyző válasza)\n");
                    azonositoindex = i;
                    break;
                }
            }
            //4. feladat
            Console.WriteLine("\n4. feladat:\n{0}",jovalaszok);
            for (int i = 0; i < eredmenyek[azonositoindex].valaszok.Length; i++)
            {
                if (eredmenyek[azonositoindex].valaszok[i] == jovalaszok[i])
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            //5. feladat
            Console.Write("\n\n5. feladat: A feladat sorszáma = ");
            string sorszam = Console.ReadLine();
            int sorszam_ = int.Parse(sorszam);
            int jovalaszok_ = 0;
            for (int i = 0; i < db; i++)
            {
                    if (eredmenyek[i].valaszok[sorszam_-1] == jovalaszok[sorszam_-1])
                    {
                        jovalaszok_++;
                    }
            }
            double jovalaszSzazalek = (double) jovalaszok_/db * 100;
            Console.WriteLine("A feladatra {0} fő, a versenyzők {1}%-a adott helyes választ.",jovalaszok_,Math.Round(jovalaszSzazalek,2));
            //6. feladat
            StreamWriter sw = new StreamWriter("E:/infoemelt/programozas/tesztverseny/pontok.txt");
            for (int i = 0; i < db; i++)
            {
                for (int j = 0; j < eredmenyek[i].valaszok.Length; j++)
                {
                    if (eredmenyek[i].valaszok[j] == jovalaszok[j] && j < 5)
                    {
                        eredmenyek[i].pontok += 3;
                    }
                    if (eredmenyek[i].valaszok[j] == jovalaszok[j] && j > 4 && j < 10)
                    {
                        eredmenyek[i].pontok += 4;
                    }
                    if (eredmenyek[i].valaszok[j] == jovalaszok[j] && j > 9 && j < 13)
                    {
                        eredmenyek[i].pontok += 5;
                    }
                    if (eredmenyek[i].valaszok[j] == jovalaszok[j] && j == 13)
                    {
                        eredmenyek[i].pontok += 6;
                    }

                }
                sw.Write(eredmenyek[i].azonosito + " " + eredmenyek[i].pontok+"\n");
            }
            sw.Close();

            Console.WriteLine("\n6. feladat: A versenyzők pontszámának meghatározása");
            //7. feladat
            Console.WriteLine("7. feladat: A verseny legjobbjai:");
            

            List<int> helyezesek = new List<int>();
            List<int> helyezesek_ = new List<int>();


            int x = 0;
            while (x < db)
            {
                if (!helyezesek.Contains(eredmenyek[x].pontok))
                {
                    helyezesek.Add(eredmenyek[x].pontok);
                    helyezesek_.Add(0);
                }

                x++;
            }
            

            helyezesek.Sort();
            helyezesek.Reverse();

            int z = 0;
            for (int i = 0; i < db; i++)
            {
                if (helyezesek.Contains(eredmenyek[i].pontok))
                {
                    z = helyezesek.IndexOf(eredmenyek[i].pontok);
                    helyezesek_[z] += 1;


                }
            }

           

        }
    }
}
