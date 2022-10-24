using SimCity.Locations;
using SimCity.Persons;

namespace SimCity.Events {
    internal class ChangePatrol : Event {
        public override char Symbol { get => 'U'; }
        public override ConsoleColor Color { get => ConsoleColor.DarkBlue; }
        public ChangePatrol(Person police, Person self, int row, int col, List<Location> locations) : base(police, self, row, col, locations) {
        }
        public override void ResolveEvent() {
            getFirstPerson().SetDirection(Person.GetRandomDirectionTuple());
        }
        internal override string GetEventString() {
            return $"En Polis bytte patrullrutt!";
        }
    }
}
