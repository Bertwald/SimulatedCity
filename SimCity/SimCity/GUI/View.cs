using SimCity.Events;
using SimCity.Locations;
using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.GUI
{
    internal class View
    {
        private static string[] news = new string[5];
        public static void PrintCity(string[] rows)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(string.Join(Environment.NewLine, rows));
        }
        internal static void PrintCityString(string City) {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(City);
        }
        internal static void PrintCityEvents(List<Event> events, List<Location> locations) {
            //Print Colored Events at correct position
            foreach (Event e in events) {
                if ( !(e is NullEvent)) {
                    Console.SetCursorPosition(e.Col+1, e.Row+1);
                    Console.ForegroundColor = e.Color;
                    Console.Write(e.Symbol);
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(500);
                }
            }
            Console.SetCursorPosition(0, 34);
            Console.WriteLine($"Antal i fängelse: {locations[1].Inhabitants.Count}     ");
            Console.WriteLine($"Antal fångar som fått amnesti: {Arrest.NumberJailed - locations[1].Inhabitants.Count}    ");
            Console.WriteLine($"Antal tjuvar i det lösa: {City.Thieves- locations[1].Inhabitants.Count}     ");
            //Print stats for event types at good location
            Console.SetCursorPosition(0, 38);
            Console.WriteLine($"Antal visiterade tjuvar: {Arrest.Arrests} \t Antal arresteringar: {Arrest.NumberJailed} \t Antal stölder: {Theft.NumberOfThefts} {Environment.NewLine}Antal återgivna ägodelar: {Reclamation.NumberOfReturns} \t Antal stöldgods i omlopp: {Theft.NumberOfThefts- Reclamation.NumberOfReturns} \t Antal stöldgods hos polisen: {Police._confiscated.Count}     {Environment.NewLine}");

            foreach (Event e in events) {
                if (!(e is NullEvent)) {
                    AddNews(e.GetEventString());
                }
            }
            PrintNews();
        }

        private static void PrintNews() {
            Console.Write(string.Join(Environment.NewLine, news));
        }

        private static void AddNews(string newsEvent) {
            for (int i = news.Length - 1; i > 0; i--) {
                news[i] = news[i - 1];
            }
            news[0] = newsEvent + new string(' ', 20);
        }
    }
}
