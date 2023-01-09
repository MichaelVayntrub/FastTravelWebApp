using FastTravel.Areas.Identity.Data;
using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class PackageView
    {
        public List<User> users;
        public List<Flight> flights;

        public PackageView(List<User> users, List<Flight> flights)
        {
            this.users = users;
            this.flights = flights;
        }
    }
}
