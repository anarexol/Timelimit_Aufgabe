using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timelimit_Aufgabe;

namespace US_Wahl {
    class Program {
        static void Main(string[] args) {

            int mengeWaehler = 100;

            List<Person> list = Wahlvolk.people(mengeWaehler); //Wir erstellen eine Liste mit 500 zufälligen Wählern
            Wahlvolk.NamenInDateiSchreiben(list); // Hier schreiben wir die Liste in eine Datei
            //Wahlvolk.abfrage(list); //wir wenden eine Linq abfrage auf die eben erstellte Liste an und geben die Ergebnisse aus
            Wahlvolk.abfrage6(list);
            Console.ReadLine();


            Console.ReadLine();
        }
    }
}
