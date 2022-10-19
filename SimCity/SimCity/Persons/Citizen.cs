using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimCity.Items;
using SimCity.Locations;

namespace SimCity.Persons
{
    internal class Citizen : Person
    {
        private List<Item> _belongings = new();
        public override char Graphics { get => 'M'; }
        public Citizen(string? name, Location home, (int, int) position) : base(name, home, position) {
            Inventory = InventoryBuilder.GetCitizenInventory(this);
        }
        internal Citizen(Location home, (int, int) position) : base(home, position) {
            Inventory = InventoryBuilder.GetCitizenInventory(this);
        }
        public Citizen(string? name, Location home, (int, int) position, (int, int) direction) : base(name, home, position, direction) {
            Inventory = InventoryBuilder.GetCitizenInventory(this);
        }
        public override List<Item> Inventory { get => _belongings; protected set => _belongings = value; }
    }
}
