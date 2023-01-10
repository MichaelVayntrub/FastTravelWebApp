using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class PortsView
    {
        public IEnumerable<Port> ports { get; set; }
        public Port newPort { get; set; }

        public PortsView()
        {
            this.ports = new List<Port>();
            this.newPort = new Port();
        }
    }
}
