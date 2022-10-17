using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Events
{
    internal class Arrest
    {
        private static int _numberOfArrests;
        public ConsoleColor Color { get { return ConsoleColor.Blue; } }
        public int NumberOfInstances { get { return _numberOfArrests; } }
    }
}
