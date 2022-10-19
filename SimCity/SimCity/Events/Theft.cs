using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Events
{
    internal class Theft : Event
    {
        private static int _numberOfThefts = 0;
        public override char Symbol { get => 'X'; }
        public Theft(Person one, Person theOther, int row, int col) : base(one, theOther, row, col) {
            _numberOfThefts++;
        }
        public override ConsoleColor Color { get => ConsoleColor.Red; }
        public override int NumberOfInstances { get => _numberOfThefts; }
    }
}
