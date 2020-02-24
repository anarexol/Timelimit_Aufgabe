using System;
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

        /*public static void abfrage(List<Person> inputListe)//Methode zur Linqabfrage 
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
        }*/

        public static void abfrage4(List<Person> inputListe)//Anzahl der Personen die Republikaner gewählt haben, gruppiert nach Nachname
        {

            List<Person> ergebnis = new List<Person>();      //Liste für die gefundenen Ergebnisse(temporär)




            var abfrage4 = from p in inputListe
                           where p.PolitischeHeimat == 0
                           group p by p.Nachname;

            foreach (var item in abfrage4)
            {
                Console.WriteLine(item.Key);
                foreach (var p in item)
                {
                    Console.WriteLine($"PersonenID: {p.ID}; Name: {p.Vorname}; Nachname: {p.Nachname};\n" +
                                    $"Geschlecht: {p.Geschlecht}; Schicht: {p.Schicht}; Politische Heimat: {p.PolitischeHeimat}");
                }
            }
        }

        public static void abfrage5(List<Person> inputListe)//Anzahl der Personen die Republikaner gewählt haben, gruppiert nach Nachname
        {

            List<Person> ergebnis = new List<Person>();      //Liste für die gefundenen Ergebnisse(temporär)




            var abfrage5 = from p in inputListe
                           where (p.Alter < 40) && (p.Beeinflußbarkeit == Beeinflußbarkeit.Leicht)
                           select p;

            foreach (var item in abfrage5)
            {
                Console.WriteLine($"Name: {item.Vorname}; Nachname: {item.Nachname}; ID: {item.ID}; Alter: {item.Alter}");

            }
        }

        public static void abfrage6(List<Person> inputListe)//Anzahl der Personen die Republikaner gewählt haben, gruppiert nach Nachname
        {

            List<Person> ergebnis = new List<Person>();      //Liste für die gefundenen Ergebnisse(temporär)




            var abfrage6 = from p in inputListe
                           where ((p.PLZ < 20000) || (p.PLZ > 80000)) && p.Nachname.Contains("M")
                           select p;

            foreach (var item in abfrage6)
            {
                Console.WriteLine($"PersonenID: {item.ID}; Name: {item.Vorname}; Nachname: {item.Nachname};\n" +
                    $"Geschlecht: {item.Geschlecht}; Schicht: {item.Schicht}; Alter: {item.Alter}; PLZ: {item.PLZ}");
                Console.WriteLine();

            }
        }



    }
}
