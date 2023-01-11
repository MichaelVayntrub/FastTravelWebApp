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
        public IActionResult Plane(PlanesView planesView)
        {
            if (planesView.chosenPlane != -1)
            {
                planesView.newPlane = _db.FindPlane(planesView.chosenPlane);
                planesView.planes = _db.Planes.ToList();
                planesView.chosenPlane = -1;
            }
            else
            {
                planesView.planes = _db.GetFilteredPlaneList(planesView.filter);
            }
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
            if (portsView.chosenPort != -1)
            {
                portsView.newPort = _db.FindPort(portsView.chosenPort);
                portsView.ports = _db.Ports.ToList();
            }
            else
            {
                portsView.ports = _db.GetFilteredPortList(portsView.filter);
            }
            return View(portsView);
        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPort(PortsView portsView)
        {
            if (portsView.delete != 0)
            {
                if (portsView.chosenPort != -1)
                {
                    Port oldPort = _db.FindPort(portsView.chosenPort);
                    _db.Remove(oldPort);
                    _db.SaveChanges();
                }
            }
            else 
            {
                Port newPort = portsView.newPort;
                if (ModelState.IsValid)
                {
                    _db.Add(newPort);
                    _db.SaveChanges();
                }
            }
            portsView.newPort = new Port();
            portsView.ports = _db.Ports.ToList();

            return View("Port", portsView);
        }
    }
}
