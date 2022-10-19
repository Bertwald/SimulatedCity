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
        public Theft(Person thief, Person citizen, int row, int col) : base(thief, citizen, row, col) {
            _numberOfThefts++;
        }
        public override void ResolveEvent() {
            //Check if there is goods in civilian inventory

            //If item to steal then
              //Put stolen goods in thief inventory
              //Remove stolen goods from civilian inventory

            //Else, Give a proper beating just in case he was up to no good
        }
        internal override string GetEventString() {
            return "Derpy description of event";
        }
        public override ConsoleColor Color { get => ConsoleColor.Red; }
        public override int NumberOfInstances { get => _numberOfThefts; }
    }
}
