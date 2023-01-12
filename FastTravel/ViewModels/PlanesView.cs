using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class PlanesView
    {
        public IEnumerable<Plane> planes { get; set; }
        public Plane newPlane { get; set; }
        public PlaneFilter filter { get; set; }
        public int chosenPlane { get; set; }
        public int delete { get; set; }

        public PlanesView()
        {
            this.planes = new List<Plane>();
            this.newPlane = new Plane() { planeID = 0, company = "", seatsNum = 0};
            this.filter = new PlaneFilter();
            chosenPlane = -1;
            delete = 0;
        }
    }
}
