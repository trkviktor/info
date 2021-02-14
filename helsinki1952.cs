using System;
using System.IO;

namespace helsinki1952
{
    struct sor
    {
        public int helyezes;
        public int sportolokSzama;
        public string sportag;
        public string versenyszam;
    }
    class helsinki1952
    {
        static void Main(string[] args)
        {
            //2. feladat
            sor[] eredmenyek = new sor[200];
            StreamReader sr = new StreamReader("helsinki.txt");
            int db = 0;
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(' ');
                eredmenyek[db].helyezes = int.Parse(temp[0]);
                eredmenyek[db].sportolokSzama = int.Parse(temp[1]);
                eredmenyek[db].sportag = temp[2];
                eredmenyek[db].versenyszam = temp[3];
                db++;
            }
            sr.Close();
            //3. feladat
            Console.WriteLine("3. feladat:\n" + "Pontszerző helyezések száma: " + db);
            //4. feladat
            int arany = 0, ezust = 0, bronz = 0, negyedik = 0, otodik = 0, hatodik = 0;
            for (int i = 0; i < db; i++)
            {
                if (eredmenyek[i].helyezes == 1)
                {
                    arany++;
                }
                if (eredmenyek[i].helyezes == 2)
                {
                    ezust++;
                }
                if (eredmenyek[i].helyezes == 3)
                {
                    bronz++;
                }
                if (eredmenyek[i].helyezes == 4)
                {
                    negyedik++;
                }
                if (eredmenyek[i].helyezes == 5)
                {
                    otodik++;
                }
                if (eredmenyek[i].helyezes == 6)
                {
                    hatodik++;
                }
            }
            Console.WriteLine("4. feladat");
            Console.WriteLine("Arany: " + arany);
            Console.WriteLine("Ezüst: " + ezust);
            Console.WriteLine("Bronz: " + bronz);
            

            //5. feladat
            Console.WriteLine("5. feladat");
            Console.WriteLine("Olimpia pontok száma: {0}", arany * 7 + ezust * 5 + bronz * 4 + negyedik * 3 + otodik * 2 + hatodik);


            //6. feladat

            //atletika,uszas,birkozas,torna,vivas,okolvivas,sportloveszet,labdarugas,ottusa,vizilabda,kajakkenu
            Console.WriteLine("6. feladat");
            int torna = 0, vivas = 0, okolvivas = 0, atletika = 0, uszas = 0, birkozas = 0, sportloveszet = 0, kajakkenu = 0, vizilabda = 0, labdarugas = 0, ottusa = 0;
            int tornaSportolokszama = 0, vivasSportolokszama = 0, okolvivasSportolokszama = 0, atletikaSportolokszama = 0, uszasSportolokszama = 0, birkozasSportolokszama = 0, sportloveszetSportolokszama = 0, kajakkenuSportolokszama = 0, vizilabdaSportolokszama = 0, labdarugasSportolokszama = 0, ottusaSportolokszama = 0;
            
            for (int i = 0; i < 64; i++)
            {
                if (eredmenyek[i].sportag == "torna") {torna++; tornaSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "vivas"){vivas++; vivasSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "okolvivas"){okolvivas++; okolvivasSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "atletika"){atletika++; atletikaSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "uszas"){uszas++; uszasSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "birkozas") {birkozas++; birkozasSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "sportloveszet"){sportloveszet++; sportloveszetSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "labdarugas"){labdarugas++; labdarugasSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "ottusa"){ottusa++; ottusaSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "vizilabda"){vizilabda++; vizilabdaSportolokszama += eredmenyek[i].sportolokSzama; }
                if (eredmenyek[i].sportag == "kajakkenu"){kajakkenu++; kajakkenuSportolokszama += eredmenyek[i].sportolokSzama; }
            }
            int[] Sportolokszama_ = { tornaSportolokszama, vivasSportolokszama, okolvivasSportolokszama, atletikaSportolokszama, uszasSportolokszama, birkozasSportolokszama, sportloveszetSportolokszama, kajakkenuSportolokszama, vizilabdaSportolokszama, labdarugasSportolokszama, ottusaSportolokszama };

            
            //string[] sportagak = { "atletika", "uszas", "birkozas", "torna", "vivas", "okolvivas", "sportloveszet", "labdarugas", "ottusa", "vizilabda", "kajakkenu" };
            int[] sportagak = { atletika, uszas, birkozas, torna, vivas, okolvivas, sportloveszet, labdarugas, ottusa, vizilabda, kajakkenu };

            int max = 0;
            
            string maxNev = "?";
            for (int i = 0; i < sportagak.Length; i++)
            {
                if (max < sportagak[i])
                {
                    max = sportagak[i];
                    
                }
            }

            int egyenlo = 0;
            bool egyenlo_;
            for (int i = 0; i < sportagak.Length; i++)
            {
                if (sportagak[i] == max)
                {
                    egyenlo++;
                }
            }
            if (egyenlo > 1)
            {
                egyenlo_ = true;
            }
            else
            {
                egyenlo_ = false;
            }

            if (!egyenlo_)
            {
                if (max == atletika) { maxNev = "Atletika"; }
                if (max == uszas) { maxNev = "Úszás"; }
                if (max == birkozas) { maxNev = "Bírkózás "; }
                if (max == torna) { maxNev = "Torna"; }
                if (max == vivas) { maxNev = "Vívás"; }
                if (max == okolvivas) { maxNev = "Ökölvívás"; }
                if (max == sportloveszet) { maxNev = "Sportlövészet"; }
                if (max == labdarugas) { maxNev = "Labdarugás"; }
                if (max == ottusa) { maxNev = "Öttusa"; }
                if (max == vizilabda) { maxNev = "Vízilabda"; }
                if (max == kajakkenu) { maxNev = "Kajakkenu"; }
                Console.WriteLine("{0} sportágban szereztek több érmet", maxNev);
            }
            else
            {
                Console.WriteLine("Egyenlő volt az érmek száma");
            }

            


            //Console.WriteLine(torna + " " + vivas + " " + okolvivas + " " + atletika + " " + uszas + " " + birkozas + " " + sportloveszet + " " + labdarugas + " " + ottusa + " " + vizilabda + " " + kajakkenu);


            //7. feladat
            Console.WriteLine("7. feladat");
            //StreamWriter sw = new StreamWriter(@"E:\infoemelt\helsinki\helsinki2.txt");
            //sw.WriteLine("Hello");
            // sw.Close();

            //8. feladat
            Console.WriteLine("8. feladat");

            int maxSportolokSzama = 0;
            int maxSportolokSzamaIndex = -1;
            for (int i = 0; i < 11; i++)
            {
                if (maxSportolokSzama < Sportolokszama_[i])
                {
                    maxSportolokSzama = Sportolokszama_[i];
                    maxSportolokSzamaIndex = i;
                }
            }
           // Console.WriteLine(maxspo);
            //tornaSportolokszama, vivasSportolokszama, okolvivasSportolokszama, atletikaSportolokszama,uszasSportolokszama,birkozasSportolokszama,sportloveszetSportolokszama,kajakkenuSportolokszama,vizilabdaSportolokszama,labdarugasSportolokszama,ottusaSportolokszama
            if (maxSportolokSzamaIndex == 0){ Console.WriteLine("Sportág: torna");}
            if (maxSportolokSzamaIndex == 1){ Console.WriteLine("Sportág: vivas");}
            if (maxSportolokSzamaIndex == 2){ Console.WriteLine("Sportág: okolvivas");}
            if (maxSportolokSzamaIndex == 3){ Console.WriteLine("Sportág: atletika");}
            if (maxSportolokSzamaIndex == 4){ Console.WriteLine("Sportág: uszas");}
            if (maxSportolokSzamaIndex == 5){ Console.WriteLine("Sportág: birkozas");}
            if (maxSportolokSzamaIndex == 6){ Console.WriteLine("Sportág: sportloveszet");}
            if (maxSportolokSzamaIndex == 7){ Console.WriteLine("Sportág: kajakkenu");}
            if (maxSportolokSzamaIndex == 8){ Console.WriteLine("Sportág: vizilabda");}
            if (maxSportolokSzamaIndex == 9){ Console.WriteLine("Sportág: labdarugas");}
            if (maxSportolokSzamaIndex == 10){ Console.WriteLine("Sportág: ottusa");}

            
            

        }
    }
}
