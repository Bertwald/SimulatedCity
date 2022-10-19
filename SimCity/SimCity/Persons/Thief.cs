using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimCity.Items;
using SimCity.Locations;

namespace SimCity.Persons
{
    internal class Thief : Person
    {
        private List<Item> _plunder = new();
        public override char Graphics { get => 'T'; }
        public Thief(string? name, Location home, (int, int) position) : base(name, home, position) {
        }
        internal Thief(Location home, (int, int) position) : base(home, position) {
        }
        public Thief(string? name, Location home, (int, int) position, (int, int) direction): base(name, home, position, direction) {

        }
        public override List<Item> Inventory { get => _plunder; protected set => _plunder = value; }
    }
}
