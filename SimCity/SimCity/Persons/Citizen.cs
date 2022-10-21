using SimCity.Items;
using SimCity.Locations;

namespace SimCity.Persons
{
    internal class Citizen : Person
    {
        private List<Item> _belongings = new();
        public override char Graphics { get => 'M'; }
        internal Citizen(Location home, (int, int) position) : base(home, position) {
            Inventory = InventoryBuilder.GetCitizenInventory(this);
        }
        public override List<Item> Inventory { get => _belongings; protected set => _belongings = value; }
    }
}
