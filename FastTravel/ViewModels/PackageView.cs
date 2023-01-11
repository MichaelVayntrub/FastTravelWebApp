using FastTravel.Areas.Identity.Data;
using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class PackageView
    {
        public IEnumerable<Package> packages { get; set; }
        public Package curr { get; set; }
        public int chosenPackage { get; set; }

        public PackageView()
        {
            packages = new List<Package>();
            curr = new Package();
            chosenPackage = -1;
        }
    }
}
