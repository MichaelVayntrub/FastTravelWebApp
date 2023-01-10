using FastTravel.Data;
using FastTravel.Models;
using FastTravel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Composition;

namespace FastTravel.Controllers
{
    public class AdminController : Controller
    {
        private readonly FastTravelDbContext _db;

        public AdminController(FastTravelDbContext db)
        {
            _db = db;
        }

        public IActionResult Flight()
        {
            //IEnumerable<Flight> flightList = _db.Flights.ToList();
            //List<Flight> flightList = new List<Flight>();
            //flightList.Add(new Flight());
            //flightList.Add(new Flight());
            //flightList.Add(new Flight());
            //flightList.Add(new Flight());
            //flightList.Add(new Flight());
            //flightList.Add(new Flight());
            //flightList.Add(new Flight());
            //flightList.Add(new Flight());

            FlightsView flightsView = new FlightsView();
            flightsView.ports = _db.Ports.ToList();
            return View(flightsView);
        }

        public IActionResult Plane()
        {
            PlanesView planesView = new PlanesView();
            planesView.planes = _db.Planes.ToList();
            return View(planesView);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPlane(PlanesView planesView)
        {
            PlanesView planesView2 = new PlanesView();
            List<Plane> planeList = _db.Planes.ToList();
            Plane newPlane = planesView.newPlane;

            if (ModelState.IsValid)
            {
                _db.AddPlane(newPlane);
            }
            planesView2.planes = _db.Planes.ToList();
            return View("Plane", planesView2);
        }

        public IActionResult Port()
        {
            PortsView portsView = new PortsView();
            portsView.ports = _db.Ports.ToList();

            return View(portsView);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Port(PortsView portsView)
        {
            PortsView portsView2 = new PortsView();
            if (portsView.filter != null)
            {
                portsView2.ports = _db.GetFilteredPortList(portsView.filter);
            }
            else portsView2.ports.ToList();

            return View(portsView2);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPort(PortsView portsView)
        {
            PortsView portsView2 = new PortsView();
            List<Port> portList = _db.Ports.ToList();
            Port newPort = portsView.newPort;

            if (ModelState.IsValid)
            {
                _db.Add(newPort);
                _db.SaveChanges();
            }
            portsView2.ports = _db.Ports.ToList();
            return View("Port", portsView2);
        }

        //GET
        public IActionResult CreateLuggage()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateLuggage(Luggage luggage)
        {
            if (ModelState.IsValid)
            {
                _db.Add(luggage);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(luggage);
        }

        //GET
        //public IActionResult CreatePetTicket()
        //{
        //    return View();
        //}

        //POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreatePetTicket(PetTicket petTicket)
        //{
        //    Animal animal = _db.Animals.Where(animal => animal.animalID == petTicket.animalID).First();
        //    string error = $"The maximum weight for {animal.animalType} is {animal.maxWeight}";

        //    if (ModelState.IsValid)
        //    {
        //        if (animal.maxWeight >= petTicket.weight)
        //        {
        //            _db.Add(petTicket);
        //            _db.SaveChanges();
        //            return RedirectToAction("Index"); 
        //        }
        //        else
        //        {
        //            return View(petTicket);
        //        }
        //    }
        //    return View(petTicket);
        //}
    }
}
