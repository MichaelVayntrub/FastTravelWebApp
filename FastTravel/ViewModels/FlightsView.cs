using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class FlightsView
    {
        public IEnumerable<Port> ports { get; set; }
        public IEnumerable<Flight> flights { get; set; }
        public Flight flight { get; set; }

        public FlightsView()
        {
            ports = new List<Port>();
            flights = new List<Flight>();
            flight = new Flight();
        }
    }
}
