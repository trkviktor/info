using System;
using System.IO;
using System.Collections.Generic;

namespace Viktor_footgolf
{
    struct sor
    {
        public string nev;
        public string kategoria;
        public string egyesulet;
        public int[] pontok;
    }
    class footgolf
    {
        static int Osszpontszam(int[] pontok)
        {
            
            Array.Sort(pontok);
            Array.Reverse(pontok);

            int osszpontszam_ = 0;
            for (int i = 0; i < pontok.Length-2; i++)
            {
                osszpontszam_ += pontok[i];
            }
            if (pontok[6] != 0)
            {
                osszpontszam_ += 10;
            }
            if (pontok[7] != 0)
            {
                osszpontszam_ += 10;
            }

            return osszpontszam_;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("fob2016.txt");
            int db = 0;
            sor[] eredmenyek = new sor[500];
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(';');
                eredmenyek[db].nev = temp[0];
                eredmenyek[db].kategoria = temp[1];
                eredmenyek[db].egyesulet = temp[2];
                eredmenyek[db].pontok = new int[8];
                for (int i = 0; i < eredmenyek[db].pontok.Length; i++)
                {
                    eredmenyek[db].pontok[i] = int.Parse(temp[i+3]);
                }
                db++;

            }
            sr.Close();

            //3. feladat
            Console.WriteLine("3. feladat: Versenyzők száma: " + db);

            //4. feladat
            int noiversenyzok = 0;
            for (int i = 0; i < db; i++)
            {
                if (eredmenyek[i].kategoria=="Noi")
                {
                    noiversenyzok++;
                }

            }
            double noiversenyzokArany = (double) noiversenyzok/db*100;
            Console.WriteLine("4. feladat: A női versenyzők aránya: " +Math.Round( noiversenyzokArany,2) + "%");

            //6. feladat
            int maxi=0;
            for (int i = 1; i < db; i++)
            {
                if (Osszpontszam(eredmenyek[i].pontok)>Osszpontszam(eredmenyek[maxi].pontok) && eredmenyek[i].kategoria == "Noi")
                {
                    maxi = i;
                }
            }

            Console.WriteLine("6. feladat: A bajnok női versenyző");
            Console.WriteLine("\t Név: {0}",eredmenyek[maxi].nev);
            Console.WriteLine("\t Egyesület: {0}", eredmenyek[maxi].egyesulet);
            Console.WriteLine("\t Összpont: {0}", Osszpontszam(eredmenyek[maxi].pontok));



            //7. feladat
            StreamWriter sw = new StreamWriter(@"E:\infoemelt\footgolf\osszpontFF.txt");
            for (int i = 0; i < db; i++)
            {
                if (eredmenyek[i].kategoria == "Felnott ferfi")
                {
                    sw.WriteLine(eredmenyek[i].nev + ";" + Osszpontszam(eredmenyek[i].pontok));
                    
                }
            }

            sw.Close();



            //8. feladat
            List<string> egyesuletek = new List<string>();
            
            for (int i = 0; i < db; i++)
            {
                if (!egyesuletek.Contains(eredmenyek[i].egyesulet))
                {
                    egyesuletek.Add(eredmenyek[i].egyesulet);
                }
            }
            int[] egyesuletszam = new int[egyesuletek.Count];

            for (int i = 0; i < db; i++)
            {
                if (egyesuletek.Contains(eredmenyek[i].egyesulet))
                {
                    int index = egyesuletek.IndexOf(eredmenyek[i].egyesulet);
                    egyesuletszam[index] += 1;
                }
            }

            
            Console.WriteLine("8. feladat: Egyesület statisztika");
            
            for (int i = 0; i < egyesuletek.Count; i++)
            {
                if (egyesuletek[i] == "n.a." || egyesuletszam[i] <= 2)
                {
                    //ne irja ki
                }
                else
                {
                    Console.WriteLine("\t {0} - {1} fő", egyesuletek[i],egyesuletszam[i]);
                }
            }


            

        }
    }
}
