
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace hegyekmo
{
    class Program
    {
        /*2. Az UTF-8 kódolású hegyekMo.txt állomány Magyarország legmagasabb hegyeinek adatait
       tartalmazza
        * a következő minta szerint (forrás: wikipedia.hu):
       Hegycsúcs neve;Hegység;Magasság
       Ágasvár;Mátra;789
       Bálvány;Bükk-vidék;956
       Büszkés-hegy;Bükk-vidék;952
       Cserepes-kő;Bükk-vidék;823
       Az állományban a hegycsúcs nevét, a hegység megnevezését és a hegycsúcs magasságát (méter) tároltuk.
       Az adatokat pontosvessző választja el. Olvassa be a hegyekMo.txt állományban lévő adatokat és
       tárolja el egy olyan adatszerkezetben,
       ami a további feladatok megoldására alkalmas! A fájlban legfeljebb 1000 sor lehet!
       Ügyeljen arra, hogy az állomány első sora az adatok fejlécét tartalmazza!
       */
        struct hegyek//Készítsen összetett változót az adatok tárolására!
        {
            public string hegycsucsnev;
            public string hegysegnev;
            public int magassag;
        }
        static hegyek[] adatok = new hegyek[1000];//Az állományban legfeljebb 1000 sor lehet.
        static void Main(string[] args)
        {
            string[] fajlbol = File.ReadAllLines("hegyekMo.txt");
            int sorokszama = 0;//sorok száma a fájlban
            int i, j;//ciklusváltozó
            for (int k = 1; k < fajlbol.Count(); k++)//Ügyeljen arra, hogy az állomány első sora az
                //adatok fejlécét tartalmazza!
        {
                string[] egysordarabolva = fajlbol[k].Split(';');//Az adatokat pontosvessző választja el.
 adatok[sorokszama].hegycsucsnev = egysordarabolva[0];
                adatok[sorokszama].hegysegnev = egysordarabolva[1];
                adatok[sorokszama].magassag = Convert.ToInt32(egysordarabolva[2]);
                sorokszama++;
            }
            int hegyekszama = sorokszama;
            /*Console.WriteLine("Az adatok listája fájlból");
            Console.WriteLine("Hegycsúcs neve Hegység Magasság");
            for (i = 0; i < hegyekszama; i++)
            {
            Console.WriteLine("{0,-25} {1,-20} {2}", adatok[i].hegycsucsnev,
           adatok[i].hegysegnev, adatok[i].magassag);
            }*/
            //3. Határozza meg és írja ki a képernyőre a minta szerint, hogy hány hegy található az
            //állományban!
        Console.WriteLine("3. feladat: Hegycsúcsok száma: {0} db", hegyekszama);
            //4.Határozza meg és írja ki a képernyőre a minta szerint az állományban található
            //hegyek //atlagmagasságát!
             //összegzés tétele

             double atlagmagassag = 0;
            for (i = 0; i < hegyekszama; i++)
            {
                atlagmagassag += adatok[i].magassag;
            }
            Console.WriteLine("4. feladat: Hegycsúcsok átlagos magassága: {0} m",
           atlagmagassag / hegyekszama);
            //5. Határozza meg és írja ki a képernyőre a minta szerint a legmagasabb hegy adatait!
            //Feltételezheti, hogy nem alakult ki holtverseny.
            //maximumkiválasztás tétele
            int max = adatok[0].magassag;
            int maxi = 0;
            for (i = 0; i < hegyekszama; i++)
            {
                if (adatok[i].magassag > max)
                {
                    max = adatok[i].magassag;
                    maxi = i;
                }
            }
            Console.WriteLine("5. feladat: A legmagasabb hegycsúcs adatai:\n\tNév: {0}\n\tHegység:{ 1}\n\tMagasság: { 2} m", 
                adatok[maxi].hegycsucsnev, adatok[maxi].hegysegnev, adatok[maxi].magassag);
        /*6. Kérjen be a felhasználótól egy magasságértéket!
 * A bevitt adatot nem kell ellenőriznie.
 * Döntse el, hogy a található-e a megadott értéknél magasabb hegycsúcs!
 * A keresést ne folytassa, ha a választ meg tudja adni!
 * A képernyőre írást a minta szerint végezze!*/
            //keresés tétele
            int keresettmagassag;
            Console.Write("6. feladat: Kérek egy magasságot: ");
            keresettmagassag = Convert.ToInt32(Console.ReadLine());
            bool van;
            i = 0;
            while ((i < hegyekszama) && !(adatok[i].magassag > keresettmagassag))
            {
                i++;
            }
            van = i < hegyekszama ? true : false;
            if (van)
            {
                Console.WriteLine("\tVan {0} m-nél magasabb hegycsúcs a{ 1} ",keresettmagassag,adatok[i].hegycsucsnev);
            }
            else
            {
                Console.WriteLine("\tNincs {0} m-nél magasabb hegycsúcs", keresettmagassag);
            }
            //7.Határozza meg és írja ki a képernyőre a minta szerint azoknak a hegycsúcsoknak a
            //számát,
 //amelyek 3000 lábnál magasabbak!Az átváltáshoz az 1 m = 3.280839895 láb értékkeldolgozzon!
        //megszámlálás tétele
 int db = 0;
            for (i = 0; i < hegyekszama; i++)
            {
                if (adatok[i].magassag * 3.280839895 > 3000)
                {
                    db++;
                }
            }
            Console.WriteLine("7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {0}", db);
            /*8. Készítsen statisztikát hegységek szerint a hegycsúcsok számáról!
            * A megoldást úgy készítse el, hogy az inputállományba később más hegységek is
           bekerülhetnek!
            * A képernyőre írást a minta szerint végezze! */
            //adott egy sorozat, határozzuk meg hány különböző eleme van és gyűjtsük ki egy tömbbe
            int kulonbozoelemekszama = 0;
            string[] hegysegnevek = new string[100];
            int[] hegysegekdb = new int[100];
            for (i = 0; i < 100; i++) hegysegekdb[i] = 0;//adatok nullázása
            for (i = 0; i < hegyekszama; i++)
            {
                j = 0;
                while ((j <= kulonbozoelemekszama) && (adatok[i].hegysegnev != hegysegnevek[j]))
                {
                    j++;
                }
                if (j > kulonbozoelemekszama)
                {
                    kulonbozoelemekszama++;
                    hegysegnevek[kulonbozoelemekszama] = adatok[i].hegysegnev;
                }
            }
            //megszámlálás tétele
            for (i = 0; i < hegyekszama; i++)
            {
                for (int k = 1; k <= kulonbozoelemekszama; k++)
                {
                    if (hegysegnevek[k] == adatok[i].hegysegnev) hegysegekdb[k]++;
                }
            }
            Console.WriteLine("8. feladat: Hegység statisztika");
            for (i = 1; i <= kulonbozoelemekszama; i++)
                Console.WriteLine("\t{0}: {1} db ", hegysegnevek[i], hegysegekdb[i]);
            /*9. A bukk-videk.txt állományba írja ki azoknak a hegycsúcsoknak nevét és magasságát a
           minta szerint,
            * amelyek a Bükk-vidéken magasodnak! Az állomány első sora az adatok fejlécét
           tartalmazza!
            * A magasságokat egy tizedesjegyre kerekítve, lábban kell kiírnia.
            * Az átváltáshoz az 1 m = 3.280839895 láb értékkel dolgozzon! */
            Console.WriteLine("9. feladat: bukk-videk.txt");
            FileStream fnev = new FileStream("bukk-videk.txt", FileMode.Create);
            StreamWriter fajlbairo = new StreamWriter(fnev);
            double magassaglab;
            fajlbairo.WriteLine("Hegycsúcs neve;Magasság láb");
            for (i = 1; i <= hegyekszama; i++)
            {
                if (adatok[i].hegysegnev == "Bükk-vidék")
                {
                    magassaglab = Math.Round((adatok[i].magassag * 3.280839895), 1);
                    fajlbairo.Write("{0};", adatok[i].hegycsucsnev);
                    fajlbairo.Write("{0}", magassaglab);
                    Console.Write("\t{0};", adatok[i].hegycsucsnev);
                    Console.WriteLine("{0}", magassaglab);
                    fajlbairo.WriteLine("\n");//sortörés
                }
            }
            fajlbairo.Close();
            fnev.Close();
            Console.ReadKey();
        }
    }
}
