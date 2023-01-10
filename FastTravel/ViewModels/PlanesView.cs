using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class PlanesView
    {
        public IEnumerable<Plane> planes { get; set; }
        public Plane newPlane { get; set; }

        public PlanesView()
        {
            this.planes = new List<Plane>();
            this.newPlane = new Plane();
        }
    }
}
