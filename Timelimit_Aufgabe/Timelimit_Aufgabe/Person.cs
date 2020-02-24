using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timelimit_Aufgabe { //Aufstellen der Enums
    enum Geschlecht { Weiblich, Männlich }
    enum Beeinflußbarkeit { Leicht, Mittel, Schwer }
    enum Schicht { UnterSchicht, UntermittelSchicht, OberemittelSchicht, ObereSchicht }
    enum PolitischeHeimat { Republikaner, Demokraten }


    class Person { //Properties der Klasse Person
        public int ID { get; set; }
        public int Alter { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int PLZ { get; set; }
        public Geschlecht Geschlecht { get; set; }
        public Beeinflußbarkeit Beeinflußbarkeit { get; set; }
        public Schicht Schicht { get; set; }
        public PolitischeHeimat PolitischeHeimat { get; set; }
       

        //Einlesen der 3 Dateien für Vorname(Mädchen/Jungen) und Nachnamen
        string[] Nachnamearray = File.ReadAllLines("nachnamen-UTF8.txt");
        string[] JungVornamearray = File.ReadAllLines("jungennamen.txt");
        string[] MädchenVornamearray = File.ReadAllLines("maedchennamen.txt");

        static Random zf = new Random();
        public Person() {      //Der Konstruktor von Person, wir erstellen eine Zufallszahl, anhand der wir das Geschlecht zuweisen, je nachdem ob dabei ein Mann oder eine Frau erschaffen wird, werden die anderen Attribute wie Vorname gesetzt.
            Geschlecht = (Geschlecht)(zf.Next(2));

            if (Geschlecht == 0)
            { //Anweisungen werden ausgeführt, wenn die erzeugt Person eine Frau ist (geschlecht == 0)
                Nachname = Nachnamearray[zf.Next(1000)];
                Vorname = MädchenVornamearray[zf.Next(MädchenVornamearray.Length)];
                Beeinflußbarkeit = (Beeinflußbarkeit)zf.Next(3);
                PolitischeHeimat = (PolitischeHeimat)zf.Next(2);
                Schicht = (Schicht)zf.Next(4);
                ID = zf.Next(10000, 50000);
                Alter = zf.Next(20, 90);
                PLZ = zf.Next(10000, 99999);
            }
            else
            {
                Nachname = Nachnamearray[zf.Next(1000)]; //Anweisungen werden ausgeführt, wenn die erzeugt Person ein Mann ist
                Vorname = JungVornamearray[zf.Next(JungVornamearray.Length)];
                Beeinflußbarkeit = (Beeinflußbarkeit)zf.Next(3);
                PolitischeHeimat = (PolitischeHeimat)zf.Next(2);
                Schicht = (Schicht)zf.Next(4);
                ID = zf.Next(50001, 100000);
                Alter = zf.Next(20, 90);
                PLZ = zf.Next(10000, 99999);
            }

        }
    }
}
