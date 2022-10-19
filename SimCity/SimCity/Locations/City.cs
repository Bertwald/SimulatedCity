using SimCity.Events;
using SimCity.GUI;
using SimCity.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity.Locations
{
    internal class City
    {
        private int _fps = 6;
        private List<Location> _locations = new();
        public string Name { get; set; }
        private List<Event> _events;
        private List<Person> _population;

        public City(string name)
        {
            Name = name;
            _locations.Add(new CityCenter());
            _locations.Add(new Jail());
            _events = new List<Event>();
            _population = new List<Person>();
            PopulateCity(10, 20, 30);

            foreach (Person pop in _population) {
                _locations[0].AddPerson(pop);
            }
        }
        private void PopulateCity(int thieves, int police, int citizens)
        {
            for (int i = 0; i < thieves; i++)
            {
                _population.Add(new Thief(_locations[0], _locations[0].GetRandomPosition()));
            }
            for (int i = 0; i < police; i++)
            {
                _population.Add(new Police(_locations[0], _locations[0].GetRandomPosition()));
            }
            for (int i = 0; i < citizens; i++)
            {
                _population.Add(new Citizen(_locations[0], _locations[0].GetRandomPosition()));
            }
        }
        public void SimulateCity()
        {
            for (int hour = 0; true; hour++)
            {
               UpdateLocations();
               HandleEvents();
               HandleIO();
               CleanEvents();
               Thread.Sleep(1000/_fps);
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
        private void HandleIO()
        {
            string toPrint = "";
            foreach(Location location in _locations) {
                toPrint += location.GetPrintableString();
            }
            View.PrintCityString(toPrint);
            View.PrintCityEvents(_events);
        }
        private void CleanEvents()
        {
            _events.Clear();
        }
        private void HandleEvents()
        {
            var pairs = from first in _locations[0].Inhabitants
                        from second in _locations[0].Inhabitants
                        where first.Position == second.Position && (first != second) && first is Thief && !(second is Thief)
                        select (first, second);
            foreach (var pair in pairs) {
                _events.Add(Event.Create(pair));
            }
            //Generate the events by finding all collisions between population
            ;
            //Execute the "Event.Resolve" action for each event
        }
        private void UpdateLocations()
        {
            foreach(Person person in _population) {
                person.Move();
            }
            /*
            foreach(Location location in _locations) {
                foreach(Person person in location.Inhabitants) {
                    person.Move();
                }
            }
            */
        }
    }
}
