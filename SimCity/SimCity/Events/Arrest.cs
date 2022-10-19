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

        public Arrest(Person thief, Person police, int row, int col) : base(thief, police, row, col) {
            _numberOfArrests++;
        }
        public override void ResolveEvent() {
            //Check if there is goods in thief inventory

            //If stolen goods then
              //Put stolen goods in police inventory
              //Remove stolen goods from thief inventory
              //Place thief in jail
              //Set thief position to any random square in jail location

            //Else, Give a proper beating just in case he was up to no good
        }
        internal override string GetEventString() {
            return "Derpy description of event";
        }

        public override ConsoleColor Color { get => ConsoleColor.Blue; }
        public override int NumberOfInstances { get => _numberOfArrests; }

    }
}
