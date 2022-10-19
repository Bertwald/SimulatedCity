using SimCity.Locations;
using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Events {
    internal class Reclamation : Event {
        private static int _numberOfReturns = 0;
        public static int NumberOfReturns { get { return _numberOfReturns; } }
        public override char Symbol { get => 'R'; }
        public Reclamation(Person police, Person citizen, int row, int col, List<Location> locations) : base(police, citizen, row, col, locations) {
        }
        public override void ResolveEvent() {
            //All owned goods in inventory is returned
            var belongings = from item in getFirstPerson().Inventory
                             where item.Owner == getLastPerson()
                             select item;
            _numberOfReturns += belongings.Count();
            getLastPerson().Inventory.AddRange(belongings);
            getFirstPerson().Inventory.RemoveAll(item => item.Owner == getLastPerson());
        }
        internal override string GetEventString() {
            return $"En medborgare fick tillbaka sina saker!";
        }

        public override ConsoleColor Color { get => ConsoleColor.Green; }
    }
}
