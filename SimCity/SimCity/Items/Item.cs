using SimCity.Persons;

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
