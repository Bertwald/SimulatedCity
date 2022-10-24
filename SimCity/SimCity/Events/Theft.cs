using SimCity.Locations;
using SimCity.Persons;

namespace SimCity.Events
{
    internal class Theft : Event
    {
        private static int _numberOfThefts = 0;
        public static int NumberOfThefts { get =>_numberOfThefts; }
        public override char Symbol { get => 'X'; }
        public override ConsoleColor Color { get => ConsoleColor.Red; }
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

    }
}
