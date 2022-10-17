using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Events
{
    internal class Theft
    {
        private static int _numberOfThefts;
        public ConsoleColor Color { get { return ConsoleColor.Red; } }
        public int NumberOfInstances { get { return _numberOfThefts; } }
    }
}
