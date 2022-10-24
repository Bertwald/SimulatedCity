using SimCity.Locations;
namespace SimCity {
    internal class Program {
        static void Main(string[] args) {
            Console.CursorVisible = false;
            City city = new("Sim City");
            city.SimulateCity();
        }
    }
}