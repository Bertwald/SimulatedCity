using SimCity.Persons;

namespace SimCity.Items {
    internal class InventoryBuilder {
        public static List<Item> GetCitizenInventory(Person citizen) {
            List<Item> defaultInventory = new() {
                new Keys(citizen),
                new Cellphone(citizen),
                new Money(citizen),
                new Watch(citizen)
            };
            return defaultInventory;
        } 
    }
}
