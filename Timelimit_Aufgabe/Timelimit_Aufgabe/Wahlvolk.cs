﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Timelimit_Aufgabe;

namespace US_Wahl {
    class Wahlvolk {



        //mit Wahlvolk.people(x) können neue Wähler der Liste people hinzugefügt werden
        public static List<Person> people(int menge) {
            List<Person> people = new List<Person>();
            for (int i = 0; i <= menge - 1; i++)
            {
                Thread.Sleep(1);
                people.Add(new Person());
            }

            return people;
        }

        //Hier
        public static void NamenInDateiSchreiben(List<Person> inputListe) {

            FileStream fs = File.Open("WählerListe.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.None);

            StreamWriter sw = new StreamWriter(fs);

            foreach (Person person in inputListe)
            {
                // sw.WriteLine("Nachname : "+person.Nachname + "\t Vorname :" + person.Vorname + "\t Politische Heimat : " + person.politischeHeimat);
                sw.WriteLine("Nachname :  {0,-11} Vorname : {1,-11} Politische Heimat : {2,-11}", person.Nachname, person.Vorname, person.PolitischeHeimat);
            }
            sw.Flush();
            sw.Close();

        }

        public static void Abfrage(List<Person> inputListe)//Methode zur Linqabfrage
      {
            int stichwort;
            string stichwortS;

            List<Person> ergebnis = new List<Person>();//Liste für die gefundenen Ergebnisse(temporär)
            Console.WriteLine("Gebe ein Suchstichwort ein:");//Eingabe des Stichworts (muss ggf für die einzelnen Attribute definiert werden)
            stichwortS = Console.ReadLine();

            //Zuerst wird probiert, die Eingabe in einen INT32 umzuwandeln, wenn dies klappt, können wir davon ausgehen, dass der Anwender nach einer numerischen ID sucht
            try
            {
                stichwort = Convert.ToInt32(stichwortS);
                var abfrage2 = from p in inputListe where p.ID.Equals(stichwort) select p; //Linq-Abfrage
                ergebnis = abfrage2.ToList();
            }
            //Für alle anderen Fälle wird versucht, den Suchbegriff im Vornamen oder Nachnamen mittels "Contains" zu finden
            catch
            {
                var abfrage = from p in inputListe where p.Vorname.Contains(stichwortS) || p.Nachname.Contains(stichwortS) select p; //Linq-abfrage  
                ergebnis = abfrage.ToList();
            }


            foreach (Person item in ergebnis)//Ausgabe des gefundenen
            {
                Console.WriteLine($"PersonenID: {item.ID}; Name: {item.Vorname}; Nachname: {item.Nachname};\n" +
                                    $"Geschlecht: {item.Geschlecht}; Schicht: {item.Schicht}");
                Console.WriteLine();
            }


        }



        public static void Abfrage1(List<Person> inputListe)
        {

            var abfrage1 = inputListe.Where(x => x.Geschlecht == Geschlecht.Weiblich).Where(x=>x.Schicht == Schicht.UnterSchicht).OrderBy(x=>x.Vorname);
            foreach (var item in abfrage1)
            {
                Console.WriteLine("Id : {0,5} Vorname : {1,-11} Nachname : {4,-11} Geschlecht :{2,-11} Schicht : {3,-11}  Politische Heimat : {5,-11}",item.ID,item.Vorname,item.Geschlecht,item.Schicht,item.Nachname,item.PolitischeHeimat,item.PolitischeHeimat);
            }


        }

        public static void Abfrage2(List<Person> inputListe)
        {
            int count = 0;
            var abfrage2 = inputListe.Where(x => x.Schicht == Schicht.UntermittelSchicht || x.Schicht == Schicht.OberemittelSchicht);

            foreach (var item in abfrage2)
            {
                count++;
            }

            Console.WriteLine(count);
        }

        public static void Abfrage3(List<Person> inputListe)
        {

            var abfrage3 = inputListe.Where(x=>x.)



        }
    }
}
