using FastTravel.Areas.Identity.Data;
using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class PackageView
    {
        public IEnumerable<Package> packages { get; set; }
        public Package curr { get; set; }
        public int chosenPackage { get; set; }
        public int ways { get; set; }
        public PackageFilter filter { get; set; }

        public string filterSource { get; set; } = null;
        public string filterDestination { get; set; } = null;

        public PackageView()
        {
            packages = new List<Package>();
            curr = new Package();
            chosenPackage = -1;
            ways = 1;
            filter = new PackageFilter();
        }
    }
}
