using Kutyak.Datas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Kutyak
{
	internal class Program
	{
       static  List<string> kutyaNevek;
        static List<KutyaFajta> fajtak;
        static void Main(string[] args)
        {

//------------------------------------------------------------------------------------------------

            /*	// Ellenőrzés --> datas-ban benne-vannak-e a fájlok.
             *	
                    var sorok = File.ReadAllLines("Datas\\KutyaNevek.csv");
                    foreach (var sor in sorok)
                    {
                        Console.WriteLine(sor);
                    }
            */
//-----------------------------------------------------------------------------------------------
            Console.WriteLine("2.feladat:");

            // 2.feladat: Olvassa be a 'KutyaNevek.csv állományban található adatokat és tárolja el egy 
            //            megfelelően megválasztott adatszerkezetben.

            /*   List<string> kutyaNevek = new List<string>();
               kutyaNevek = File.ReadAllLines("Datas\\KutyaNevek.csv")
                                .Skip(1)   // első sort kiveszem
                                .Select(sor => sor.Split(';')[1]) // kiíratjuk a sornak a 2. elemét (neveket)
                                .ToList();
            */

            // Rövidebben:

            kutyaNevek = File.ReadAllLines("Datas\\KutyaNevek.csv")
                              .Skip(1)   // első sort kiveszem (adatok fejléce)
                              .Select(sor => sor.Split(';')[1]) // kiíratjuk a sornak a 2. elemét (neveket)
                              .ToList();

            foreach (var nevek in kutyaNevek)
            {
                Console.Write(nevek + "; ");
            }

            //    kutyaNevek.ForEach(sor => Console.Write(sor + "; "));

            Console.WriteLine("\n");
            //----------------------------------------------------------------------------------------------------------

            // 3. feladat: Hány kutyanév található az állományban?

            Console.WriteLine($" 3.feladat: Kutyanevek száma: {kutyaNevek.Count}");

            Console.WriteLine();
//---------------------------------------------------------------------------------------------------------

            Console.WriteLine(" 4.feladat:");

            // 4.feladat: Olvassa be a 'KutyaFajtak.csv állományban található adatokat és tárolja el egy 
            //            megfelelően megválasztott adatszerkezetben.



            List<KutyaFajta> fajtak = File.ReadAllLines("Datas\\KutyaFajtak.csv")
                              .Skip(1)   // első sort kiveszem (adatok fejléce)

                              //   új  KutyaFajta objektumot csinálunk, amiben 3 adat kell. int és 2 string.---> 

                              .Select(sor => new KutyaFajta(int.Parse(sor.Split(';')[0]),
                                                            sor.Split(';')[1],
                                                            sor.Split(';')[2]))
                              .ToList();


            //  Csináunk egy  Segédmetódust (gyártómetódus) --> konvertert... amivel lerövidítjük az előző sorokat. A paraméter alapján
            //  egy új objektumot hoz létre, amit visszaad a hívónak.

            // hiába jelölöm ki a sorokat, aztán alt + enter, rámegyek a körtére, majd extract method-ra... nekem nem csinál beőle új metódust.

            // Ennek kellene lennie : 

            /*                  .Select(sor => StringToKutyaFajta(sor))
                                .ToList();

               private static Kutyafajta StringToKutyaFajta(string sor)

                         return new KutyaFajta(int.Parse(sor.Split(';')[0]),
                                               sor.Split(';')[1],
                                               sor.Split(';')[2]));   */


            /*  ------> átalakítva, rövidebben

                                        privat static Kutyafajta StringToKutyaFajta(string sor)

                                                                  string[] mezok = sor.Split(';');
                                                                  return new KutyaFajta(int.Parse(mezok(';')[0]),
                                                                                        mezok[1],
                                                                                        mezok[2])); 

               */
//---------------------------------------------------------------------------------------------------------

            // 5.feladat: Olvassa be a 'Kutyak.csv állományban található adatokat és tárolja el egy 
            //            megfelelően megválasztott adatszerkezetben.

            List<Kutya> kutyak = File.ReadAllLines("Datas\\Kutyak.csv")
                                     .Skip(1)
                                     .Select(sor => new Kutya(int.Parse(sor.Split(';')[0]),
                                                              int.Parse(sor.Split(';')[1]),
                                                              int.Parse(sor.Split(';')[2]),
                                                              int.Parse(sor.Split(';')[3]),
                                                              Convert.ToDateTime(sor.Split(';')[4])))
                                     .ToList();

//---------------------------------------------------------------------------------------------------------

            // 6.feladat: Mennyi a kutyák átlagos életkora 2 tizedesjegyre kerekítve?

            Console.WriteLine($"6.feladat:Kutyák átlag életkora:{kutyak.Average(x => x.EletkorId):f2}");
            Console.WriteLine($"6.feladat:Kutyák átlag életkora:{Math.Round(kutyak.Average(x => x.EletkorId), 2)}");
            Console.WriteLine($"6.feladat:Kutyák átlag életkora:{kutyak.Average(x => x.EletkorId):0.##}");

            //-------------------------------------------------------------------------------------------------------

            // 7.feladat: Mi a neve és fajtája a legidősebb kutyának?  (Konverziós eszközök alkalmazása)

            Kutya legidosebbKutya = kutyak.OrderBy(x => x.EletkorId).Last();
            Console.WriteLine($" 7.feladat: Legidősebb kutya neve és fajtája: " +
                              $"{GetKutyaNev(legidosebbKutya.NevId)}" +
                              $" {GetKutyaFajta(legidosebbKutya.FajtaId)}");

//----------------------------------------------------------------------------------------------------------------

            // 8.feladat: 2018. január 10-én fajtánként hány kutya volt az állatorvosi rendelőben?

            kutyak.Where(x => x.UtolsoEllenorzes == new DateTime(2018, 1, 10))
                .GroupBy(x => x.FajtaId)
                .ToList()
                .ForEach(kfaj => Console.WriteLine($"8.feladat: Január 10-én vizsgált kutyafajták: {GetKutyaFajta(kfaj.Key)}: {kfaj.Count()} kutya"));

//---------------------------------------------------------------------------------------------------------

    /*        // 9.feladat: Melyik nap volt a rendelő a legjobban leterhelve és hány kutyát láttal el aznap?

            var legterheltebbNap = kutyak.GroupBy(x => x.UtolsoEllenorzes).Max(x => x.Count());
            Console.WriteLine($" 9.feladat: Legjobban leterhelt nap: {legterheltebbNap.Key.ToShortDateString()}: {legterheltebbNap.Count()} kutya");

            */

//---------------------------------------------------------------------------------------------------------

            // 10.feladat: Névstatisztika.txt néven hozzon létre egy új, pontosvesszővel tagolt állományt csökkenő
            //             sorrendben,amely tartalmazza a vizsgált kutyák nevét és az adott nevű kutyák számát.

           var sorok = kutyak.GroupBy(x => x.NevId)
                  .OrderByDescending(x => x.Count())
                  .ThenBy(x => x.Key)              // ThenBy növekvő... ThenByDescending csökkenő
                  .Select(x => $"{GetKutyaNev(x.Key)} : {x.Count()}");

            File.WriteAllLines("Nevstatisztika.txt", sorok);
//----------------------------------------------------------------------------------------------------------------

        }
        //   Keresőmetódus a 7. feladathoz:

        static public string GetKutyaNev(int id)
        {
            return kutyaNevek[id-1];
        }

        static private string GetKutyaFajta(int id)
        {
            return fajtak[id-1].Nev;
        }    
       
    }
}
