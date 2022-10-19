using SimCity.Locations;
namespace SimCity {
    internal class Program {
        static void Main(string[] args) {
            Console.CursorVisible = false;
            //Console.SetBufferSize(100, 80);
            City city = new City("Sim City");
            city.SimulateCity();
        }
    }
}