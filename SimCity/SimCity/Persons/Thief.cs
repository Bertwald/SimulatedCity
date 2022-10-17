using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimCity.Items;

namespace SimCity.Persons
{
    internal class Thief : Person
    {
        private List<Item> _plunder = new();
        public override char Graphics { get => 'T'; }
        public Thief(string? name, (int, int) position) : base(name, position) {

        }

        public override List<Item> Inventory { get => _plunder; }
    }
}
