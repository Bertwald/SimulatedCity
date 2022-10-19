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
    internal class Theft : Event
    {
        private static int _numberOfThefts = 0;
        public static int NumberOfThefts { get { return _numberOfThefts; } }
        public override char Symbol { get => 'X'; }
        public Theft(Person thief, Person citizen, int row, int col, List<Location> locations) : base(thief, citizen, row, col, locations) {
        }
        public override void ResolveEvent() {
            if (getLastPerson().Inventory.Count > 0) {
                _numberOfThefts++;
                getFirstPerson().Inventory.Add(getLastPerson().Inventory.FirstOrDefault());
                getLastPerson().Inventory.RemoveAt(0);
            }
        }
        internal override string GetEventString() {
            return "Nu rånades en medborgare!";
        }
        public override ConsoleColor Color { get => ConsoleColor.Red; }
        public override int NumberOfInstances { get => _numberOfThefts; }
    }
}
