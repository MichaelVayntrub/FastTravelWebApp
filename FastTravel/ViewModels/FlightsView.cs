using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class FlightsView
    {
        public IEnumerable<Port> ports { get; set; }
        public IEnumerable<Flight> flights { get; set; }
        public IEnumerable<Plane> planes { get; set; }
        public Flight flight { get; set; }
        public int plane { get; set; }
        public int source { get; set; }
        public int destination { get; set; }
        public int? stop1 { get; set; }
        public int? stop2 { get; set; }
        public PlaneFilter filter { get; set; }

        public FlightsView()
        {
            ports = new List<Port>();
            flights = new List<Flight>();
            planes = new List<Plane>();
            flight = new Flight();
            filter = new PlaneFilter();
        }
    }
}
