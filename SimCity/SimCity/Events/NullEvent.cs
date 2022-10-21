using SimCity.Locations;
using SimCity.Persons;

namespace SimCity.Events {
    internal class NullEvent : Event {
        public NullEvent(Person one, Person theOther, int row, int col, List<Location> locations) : base(one, theOther, row, col, locations) {
        }
    }
}
