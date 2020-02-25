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


            var abfrage3 = inputListe.Where(x => x.Geschlecht == Geschlecht.Männlich && x.PolitischeHeimat == PolitischeHeimat.Demokraten).OrderBy(x => x.Alter);


            foreach (var item in abfrage3)
            {
                Console.WriteLine("Id : {0,5} Vorname : {1,-11} Nachname : {4,-11} Geschlecht :{2,-11} Schicht : {3,-15}  Politische Heimat : {5,-15}", item.ID, item.Vorname, item.Geschlecht, item.Schicht, item.Nachname, item.PolitischeHeimat, item.PolitischeHeimat);
            }

        }

        public static void Abfrage4(List<Person> inputListe)//Anzahl der Personen die Republikaner gewählt haben, gruppiert nach Nachname
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

        public static void Abfrage5(List<Person> inputListe)//Anzahl der Personen die Republikaner gewählt haben, gruppiert nach Nachname
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

        public static void Abfrage6(List<Person> inputListe)//Anzahl der Personen die Republikaner gewählt haben, gruppiert nach Nachname
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

        public static void Abfrage7(List<Person> inputListe)
        {
            var abfrage7 = inputListe.Where(x => x.Schicht == Schicht.OberemittelSchicht && x.Beeinflußbarkeit == Beeinflußbarkeit.Leicht || x.Beeinflußbarkeit == Beeinflußbarkeit.Mittel);

            foreach (var item in abfrage7)
            {
                Console.WriteLine("Id : {0} | Vn : {1,-11} | Nn : {4,-11} | Plz : {6,-15} | M/W :{2,-10} | Schicht : {3,-18} | Politische Heimat : {5,-15}", item.ID, item.Vorname, item.Geschlecht, item.Schicht, item.Nachname, item.PolitischeHeimat, item.PolitischeHeimat, item.PLZ);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }


        }

        public static void Abfrage8(List<Person> inputListe)
        {

            var abfrage8 = inputListe.Where(x => x.PolitischeHeimat == PolitischeHeimat.Republikaner && x.Alter < 40);

            foreach (var item in abfrage8)
            {
                Console.WriteLine("Id : {0} | Vn : {1,-11} | Nn : {4,-11} | Plz : {6,-15} | M/W :{2,-10} | Schicht : {3,-18} | Politische Heimat : {5,-15} | Alter : {8}", item.ID, item.Vorname, item.Geschlecht, item.Schicht, item.Nachname, item.PolitischeHeimat, item.PolitischeHeimat, item.PLZ,item.Alter);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }

        } 

        public static void Abfrage9(List<Person> inputListe)
        {

            var abfrage9 = inputListe.Where(x => x.PolitischeHeimat == PolitischeHeimat.Demokraten).OrderBy(x=>x.Alter).First();

            //foreach (var item in abfrage9)
            //{
           // Console.WriteLine(abfrage9.Vorname);
            Console.WriteLine("Id : {0} | Vn : {1,-11} | Nn : {4,-11} | Plz : {7,-15} | M/W :{2,-10} | Schicht : {3,-18} | Politische Heimat : {5,-15} | Alter : {8}",abfrage9.ID, abfrage9.Vorname, abfrage9.Geschlecht, abfrage9.Schicht, abfrage9.Nachname, abfrage9.PolitischeHeimat, abfrage9.PolitischeHeimat, abfrage9.PLZ, abfrage9.Alter);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            //}


        }

        public static void Abfrage10(List<Person> inputListe)
        {
            var abfrage10 = inputListe.Where(x=>x.PolitischeHeimat==PolitischeHeimat.Republikaner && x.Alter>=30 && x.Alter<=50 && x.Schicht==Schicht.ObereSchicht);
            foreach (var item in abfrage10)
            {
                Console.WriteLine("Id : {0} | Vn : {1,-11} | Nn : {4,-11} | Plz : {6,-15} | M/W :{2,-10} | Schicht : {3,-18} | Politische Heimat : {5,-15} | Alter : {8}", item.ID, item.Vorname, item.Geschlecht, item.Schicht, item.Nachname, item.PolitischeHeimat, item.PolitischeHeimat, item.PLZ,item.Alter);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }


        }
    }
}
