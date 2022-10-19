using SimCity.Events;
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
        internal static void PrintCityEvents(List<Event> events) {
            //Print Colored Events at correct position
            foreach (Event e in events) {
                if ( !(e is NullEvent)) {
                    Console.SetCursorPosition(e.Row, e.Col);
                    Console.ForegroundColor = e.Color;
                    Console.Write(e.Symbol);
                }
            }
            //Print stats for event types at good location

            //Print newsflash at correct position

        }
    }
}
