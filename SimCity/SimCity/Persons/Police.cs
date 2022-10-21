using SimCity.Items;
using SimCity.Locations;

namespace SimCity.Persons
{
    internal class Police : Person
    {
        public static List<Item> _confiscated = new List<Item>();
        public override char Graphics { get => 'P'; }
        internal Police(Location home, (int, int) position) : base(home, position) {
        }
        public override List<Item> Inventory { get => _confiscated; protected set => _confiscated = value; }
    }
}
