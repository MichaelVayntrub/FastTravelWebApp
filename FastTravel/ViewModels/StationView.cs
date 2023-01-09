using Microsoft.OData.Edm;
using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class StationView
    {
        public int order { get; set; }
        public TimeOfDay time { get; set; }
        public Date date { get; set; }
        public Port port { get; set; }

        public StationView(int order, TimeOfDay time, Date date, Port port)
        {
            this.order = order;
            this.time = time;
            this.date = date;
            this.port = port;
        }
    }
}
