using System;
using System.IO;

namespace Viktor_ultrabalaton
{
    struct sor
    {
        public string versenyzo;
        public int rajtszam;
        public string kategoria;
        public string ido;
        public int szazalek;
    }
    class Ultrabalaton
    {

        static double IdőÓrában(string ido)
        {
            int óra, perc, másodperc;
            óra =int.Parse(ido.Split(':')[0]);
            perc = int.Parse(ido.Split(':')[1]);
            másodperc = int.Parse(ido.Split(':')[2]);
            double órában = óra + perc / 60.0 + másodperc / 3600.0;
            return órában;
        }
        static void Main(string[] args)
        {
            //2. feladat
            sor[] eredmenyek = new sor[500];
            StreamReader sr = new StreamReader("ub2017egyeni.txt");
            sr.ReadLine();
            int db = 0;
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(';');
                eredmenyek[db].versenyzo = temp[0];
                eredmenyek[db].rajtszam = int.Parse(temp[1]);
                eredmenyek[db].kategoria = temp[2];
                eredmenyek[db].ido = temp[3];
                eredmenyek[db].szazalek = int.Parse(temp[4]);
                db++;
            }
            sr.Close();

            //3. feladat
            Console.WriteLine("3. feladat: Egyéni indulók: {0} fő", db);

            //4.feladat
            int noCelbaert = 0;
            for (int i = 0; i < db; i++)
            {
                if (eredmenyek[i].kategoria == "Noi" && eredmenyek[i].szazalek == 100)
                {
                    noCelbaert++;
                }
            }
            Console.WriteLine("4. feladat: Célba érkező női sportolók: {0} fő", noCelbaert);

            //5. feladat

            Console.Write("5. feladat: Kérem a sportoló nevét: ");
            string sportoloNeve = Console.ReadLine();
            int van = 0;
            while (van < db && eredmenyek[van].versenyzo != sportoloNeve)
            {
                van++;
            }

            if (van<db)
            {
                Console.WriteLine("\tIndult egyéniben a sportoló? Igen");
                if (eredmenyek[van].szazalek == 100)
                {
                    Console.WriteLine("\tTeljesítette a teljes távot? Igen");
                }
                else
                {
                    Console.WriteLine("\tTeljesítette a teljes távot? Nem");
                }
            }
            else
            {
                Console.WriteLine("\tIndult egyéniben a sportoló? Nem");
            }
            //van = -1;
            //for (int i = 0; i < db; i++)
            //{

            //        if (sportoloNeve == eredmenyek[i].versenyzo)
            //        {
            //            van = i;
            //            break;
            //        }

            //}


            //Console.WriteLine(IdőÓrában(eredmenyek[0].ido));

            //7. feladat

            double ferfiIdo = 0.0;
            int ferfiCelbaert = 0;
            for (int i = 0; i < db; i++)
            {
                if (eredmenyek[i].kategoria == "Ferfi" && eredmenyek[i].szazalek == 100)
                {
                    ferfiIdo += IdőÓrában(eredmenyek[i].ido);
                    ferfiCelbaert++;
                }
            }
            
            double ferfiAtlag = ferfiIdo / ferfiCelbaert;
            Console.WriteLine("7. feladat: Átlagos idő: {0} óra", ferfiAtlag);

            int ferfiGyoztes = 0;
            int noiGyoztes = 0;
            for (int i = 1; i < db; i++)
            {
                if (eredmenyek[i].kategoria == "Ferfi" && eredmenyek[i].szazalek == 100)
                {
                    if (IdőÓrában(eredmenyek[i-1].ido) > IdőÓrában(eredmenyek[i].ido))
                    {
                        ferfiGyoztes = i;
                    }

                }
                if (eredmenyek[i].kategoria == "Noi" && eredmenyek[i].szazalek == 100)
                {
                    if (IdőÓrában(eredmenyek[i - 1].ido) > IdőÓrában(eredmenyek[i].ido))
                    {
                        noiGyoztes = i;
                    }

                }
            }
            
            Console.WriteLine("8. feladat: Verseny győztesei\n\tNők: {0} - {1}\n\tFérfiak: {2} - {3}",eredmenyek[noiGyoztes].rajtszam,eredmenyek[noiGyoztes].ido,eredmenyek[ferfiGyoztes].rajtszam,eredmenyek[ferfiGyoztes].ido);



        }
    }
}
