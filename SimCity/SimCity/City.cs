using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCity {
    internal class City {
        private List<Location> _locations = new();
        public string Name { get; set; }
        //Fix name!
        private List<Event> _events;
        private List<Person> _population;

        public City() {
            _locations.Add(new Location("City Center", new Tuple<int,int>(0, 0), new Tuple<int, int>(20, 100)));
            _events = new List<Event>();
            _population = new List<Person>();
            PopulateCity(10, 20, 30);
        }

        private void PopulateCity(int thieves, int police, int citizens) {
            for (int i = 0; i < thieves; i++) {
                _population.Add(new Thief());
            }
            for (int i = 0; i < police; i++) {
                _population.Add(new Police());
            }
            for (int i = 0; i < citizens; i++) {
                _population.Add(new Citizen());
            }
        }

        public void SimulateCity() {
            for(int hour = 0; true ; hour++) {
                foreach (Location location in _locations) {
                    //UpdatePositions();
                    //HandleEvents();
                    /*
                    _view.Printlocations(location);
                    _view.PrintEvents();
                    */
                    //CleanEvents();
                }

                Thread.Sleep(200);
            }


        }
    }
}
