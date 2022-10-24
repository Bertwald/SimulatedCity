using SimCity.Events;
using SimCity.GUI;
using SimCity.Persons;

namespace SimCity.Locations {
    internal class City {
        private int _fps = 10;
        //The variables for the population limits
        private static int _policemen = 7;
        private static int _thieves = 20;
        private static int _citizens = 40;
        //Property for getting the total amount of thieves in city
        internal static int Thieves { get => _thieves; }
        private static Random random = new();
        //The list of locations this city contains
        private List<Location> _locations = new();
        //The name of the City
        internal string Name { get; set; }
        private readonly List<Event> _events;
        private readonly List<Person> _population;

        public City(string name) {
            Name = name;
            _locations.Add(new CityCenter());
            _locations.Add(new Jail());
            _events = new List<Event>();
            _population = new List<Person>();
            PopulateCity(_thieves, _policemen, _citizens);
            //All poplation in city begins in city center
            foreach (Person pop in _population) {
                _locations[0].AddPerson(pop);
            }
        }
        private void PopulateCity(int thieves, int police, int citizens) {
            for (int i = 0; i < thieves; i++) {
                //The population is created with a home location and a random coordinate
                _population.Add(new Thief(_locations[0], _locations[0].GetRandomPosition()));
            }
            for (int i = 0; i < police; i++) {
                _population.Add(new Police(_locations[0], _locations[0].GetRandomPosition()));
            }
            for (int i = 0; i < citizens; i++) {
                _population.Add(new Citizen(_locations[0], _locations[0].GetRandomPosition()));
            }
        }
        public void SimulateCity() {
            for (int hour = 0; true; hour++) {
                UpdatePopulation();
                HandleEvents();
                PrintCity();
                CleanEvents();
                Console.SetCursorPosition(0, 48);
                Console.Write($"Timme: {hour}");
                //Thread.Sleep(1000 / _fps);
            }
        }
        private void IncreaseFPS() {
            _fps++;
        }
        private void DecreaseFPS() {
            if (_fps > 1) {
                _fps--;
            }
        }
        private void PrintCity() {
            string toPrint = "";
            foreach (Location location in _locations) {
                toPrint += location.GetPrintableString();
            }
            View.PrintCityString(toPrint);
        }
        private void CleanEvents() {
            _events.Clear();
        }
        private void HandleEvents() {
            var pairs = from first in _locations[0].Inhabitants
                        from second in _locations[0].Inhabitants
                        where first.Position == second.Position && 
                        ((first is Thief && second is not Thief) || 
                        (first is Police && second is Citizen))
                        select (first, second);
            foreach (var pair in pairs) {
                _events.Add(Event.Create(pair, _locations));
            }
            if (random.Next(10000) < _locations[1].Inhabitants.Count) {
                _events.Add(Event.Create((_locations[1].Inhabitants[0], _locations[1].Inhabitants[0]), _locations));
            }
            if((Theft.NumberOfThefts-Reclamation.NumberOfReturns) > random.Next(10000)) {
                Person? firstPolice = _population.Find(person => person is Police);
                if (firstPolice is not null) {
                    _events.Add(new ChangePatrol(firstPolice, firstPolice, firstPolice.Position.x, firstPolice.Position.y, _locations));
                }
            }
            View.PrintCityEvents(_events, _locations);
            foreach (Event e in _events) {
                e.ResolveEvent();
            }
        }
        private void UpdatePopulation() {
            foreach (Person person in _population) {
                person.Move();
            }
        }
    }
}
