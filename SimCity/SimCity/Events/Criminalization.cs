using SimCity.Locations;
using SimCity.Persons;

namespace SimCity.Events {
    internal class Criminalization : Event {
        public Criminalization(Person one, Person theOther, int row, int col, List<Location> locations) : base(one, theOther, row, col, locations) {
        }
        public override void ResolveEvent() {
            //Check if there is goods in thief inventory
        }
        internal override string GetEventString() {
            return $"En medborgare blev kriminell av desperation!";
        }

        public override ConsoleColor Color { get => ConsoleColor.Blue; }
    }
}
