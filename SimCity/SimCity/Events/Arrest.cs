using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Events
{
    internal class Arrest : Event
    {
        private static int _numberOfArrests = 0;
        public override char Symbol { get => 'A'; }

        public Arrest(Person one, Person theOther, int row, int col) : base(one, theOther, row, col) {
            _numberOfArrests++;
        }

        public override ConsoleColor Color { get => ConsoleColor.Blue; }
        public override int NumberOfInstances { get => _numberOfArrests; }

    }
}
