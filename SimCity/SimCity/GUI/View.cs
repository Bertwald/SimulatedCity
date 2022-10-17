using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.GUI
{
    internal class View
    {
        public static void PrintCity(string[] rows)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(string.Join(Environment.NewLine, rows));
        }
    }
}
