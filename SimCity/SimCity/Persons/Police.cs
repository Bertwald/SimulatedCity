using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimCity.Items;
using SimCity.Locations;

namespace SimCity.Persons
{
    internal class Police : Person
    {
        public static List<Item> _confiscated = new List<Item>();
        public override char Graphics { get => 'P'; }
        public Police(string? name, Location home, (int, int) position) : base(name, home, position) {
        }
        internal Police(Location home, (int, int) position) : base(home, position) {
        }
        public Police(string? name, Location home, (int, int) position, (int, int) direction) : base(name, home, position, direction) {

        }

        public override List<Item> Inventory { get => _confiscated; protected set => _confiscated = value; }

    }
}
