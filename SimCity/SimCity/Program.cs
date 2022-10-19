using SimCity.Locations;
namespace SimCity {
    internal class Program {
        static void Main(string[] args) {
            Console.CursorVisible = false;
            Console.SetBufferSize(200, 70);
            City city = new City("Sim City");
            city.SimulateCity();
        }
    }
}