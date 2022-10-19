using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Items
{
    public class Item
    {
        internal Person Owner { get; init; }
        internal Item(Person owner)
        {
            Owner = owner;
        }
    }
}
