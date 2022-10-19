using SimCity.Events;
using SimCity.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.GUI
{
    internal class View
    {
        private static List<string> news = new();
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
                    Console.SetCursorPosition(e.Col, e.Row);
                    Console.ForegroundColor = e.Color;
                    Console.Write(e.Symbol);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.SetCursorPosition(0, 34);
            Console.WriteLine($"Antal i fängelse: {locations[1].Inhabitants.Count}");
            Console.WriteLine($"Antal fångar som fått amnesti: {Arrest.NumberJailed - locations[1].Inhabitants.Count}");
            //Print stats for event types at good location
            Console.SetCursorPosition(0, 38);
            Console.WriteLine($"Antal visiterade tjuvar: {Arrest.Arrests} \t Antal arresteringar: {Arrest.NumberJailed} \t Antal stölder: {Theft.NumberOfThefts}");
            Console.SetCursorPosition(0,45);
            foreach (Event e in events) {
                if (!(e is NullEvent)) {
                    Console.WriteLine(e.GetEventString());
                }
            }

        }
    }
}
