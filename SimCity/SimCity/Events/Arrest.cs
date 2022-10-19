using SimCity.Items;
using SimCity.Locations;
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
        private static int _numberJailed = 0;
        public override char Symbol { get => 'A'; }
        public static int Arrests { get { return _numberOfArrests; } }
        public static int NumberJailed { get { return _numberJailed; } }

        public Arrest(Person thief, Person police, int row, int col, List<Location> locations) : base(thief, police, row, col, locations) {
            _numberOfArrests++;
        }
        public override void ResolveEvent() {
            //Check if there is goods in thief inventory
            if (getFirstPerson().Inventory.Count > 0) {
                _numberJailed++;
                getLastPerson().Inventory.AddRange(getFirstPerson().Inventory);
                getFirstPerson().Inventory.Clear();
                _locations[1].AddPerson(getFirstPerson());
                _locations[0].RemovePerson(getFirstPerson());
                getFirstPerson().SetHome(_locations[1]);
            }
        }
        internal override string GetEventString() {
            return $"Nu arresterades en tjuv!";
        }

        public override ConsoleColor Color { get => ConsoleColor.Blue; }
        public override int NumberOfInstances { get => _numberOfArrests; }

    }
}
