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

            Menu(list);

            Console.ReadLine();
        }
        public static void Menu(List<Person> inputListe) {
            int auswahl;
            bool exitKey = true;
            while (exitKey)
            {
                Console.Clear();
                Console.WriteLine("=============================================\n" +
                                    "+++           US-Wahl Manipulator V0.5    +++\n" +
                                    "+++   written by the Developer Division   +++\n" +
                                    "=============================================\n");
                Console.WriteLine("=============================================\n" +
                                    "+++                Hauptmenu              +++\n" +
                                    "=============================================\n" +
                                    "Was möchtest du tun?\n" +
                                    "\n" +
                                    "[1] Alle weiblichen Personen von der Unterschicht, sortiert nach Vornamen ausgeben\n" +
                                    "[2] Anzahl Personen der Mittelschicht ausgeben\n" +
                                    "[3] Alle männlichen Demokraten sortiert nach Alter ausgeben\n" +
                                    "[4] Anzahl Personen, die Republikaner gewählt haben, nach Nachname sortiert ausgeben\n" +
                                    "[5] Nur Vor/Nachname/ID von Personen unter 40, die leicht beeinflussbar sind ausgeben\n" +
                                    "[6] Alle Personen, deren PLZ > 80000 oder PLZ < 20000 mit 'M' im Nachnamen\n" +
                                    "[7] Vorname, Nachname u. PLZ von Personen aus der Obermittelschicht, mit Beeinflussbarkeit leicht/mittel\n" +
                                    "[8] Anzahl weibliche Republikaner unter 40\n" +
                                    "[9] Die Älteste Person, die die Demokraten gewählt hat\n" +
                                    "[10] Vor/Nachname und PLZ der Oberschicht, die Republikaner gewählt haben u. zwischen 30 und 50 Jahren sind\n"
                                    );
                auswahl = Convert.ToInt32(Console.ReadLine());

                switch (auswahl)
                {
                    case 0:
                        {
                            exitKey = false;
                            Console.Clear();
                            break;
                        }
                    case 1:
                        {
                            Wahlvolk.Abfrage1(inputListe);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {

                            Wahlvolk.Abfrage2(inputListe);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            Wahlvolk.Abfrage3(inputListe);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 4:
                        Wahlvolk.Abfrage4(inputListe);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        {

                            Wahlvolk.Abfrage5(inputListe);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 6:
                        {
                            Wahlvolk.Abfrage6(inputListe);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        /*case 7:
                            {
                                Wahlvolk.Abfrage7(inputListe);
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        case 8:
                            {
                                Wahlvolk.Abfrage8(inputListe);
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        case 9:
                            {
                                Wahlvolk.Abfrage9(inputListe);
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        case 10:
                            {
                                Wahlvolk.Abfrage9(inputListe);
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            } */
                }

            }
        }
    }
}