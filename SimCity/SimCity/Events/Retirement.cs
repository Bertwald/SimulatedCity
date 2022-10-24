using SimCity.Locations;
using SimCity.Persons;

namespace SimCity.Events {
    internal class Retirement : Event {
        public Retirement(Person thief, Person citizen, int row, int col, List<Location> locations) : base(thief, citizen, row, col, locations) {
        }
        public override void ResolveEvent() {
            //Create a new citizen having all things in thief inventory
        }
        internal override string GetEventString() {
            return "";
        }

        public override ConsoleColor Color { get => ConsoleColor.Blue; }
    }
}
