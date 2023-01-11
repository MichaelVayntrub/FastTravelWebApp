using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class PortsView
    {
        public IEnumerable<Port> ports { get; set; }
        public Port newPort { get; set; }
        public PortFilter filter { get; set; }
        public int chosenPort { get; set; }
        public int delete { get; set; }

        public PortsView()
        {
            this.ports = new List<Port>();
            this.newPort = new Port();
            this.filter = new PortFilter();
            chosenPort = -1;
            delete = 0;
        }
    }
}
