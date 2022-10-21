using SimCity.Items;
using SimCity.Locations;

namespace SimCity.Persons
{
    internal class Thief : Person
    {
        private List<Item> _plunder = new();
        public override char Graphics { get => 'T'; }
        internal Thief(Location home, (int, int) position) : base(home, position) {
        }
        public override List<Item> Inventory { get => _plunder; protected set => _plunder = value; }
    }
}
