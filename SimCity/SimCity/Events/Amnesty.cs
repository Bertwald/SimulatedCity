using SimCity.Locations;
using SimCity.Persons;

namespace SimCity.Events {
    internal class Amnesty : Event {
        private static int _amnesties = 0;
        public static int Amnesties { get { return _amnesties; } }
        public override char Symbol { get => 'R'; }
        public override ConsoleColor Color { get => ConsoleColor.Cyan; }
        public Amnesty(Person one, Person theOther, int row, int col, List<Location> locations) : base(one, theOther, row, col, locations) {
        }
        public override void ResolveEvent() {
            _amnesties++;
            _locations[0].AddPerson(getFirstPerson());
            _locations[1].RemovePerson(getFirstPerson());
            getFirstPerson().SetHome(_locations[0]);
        }
        internal override string GetEventString() {
            return $"Nu Frisläpptes en fånge!";
        }

    }
}
