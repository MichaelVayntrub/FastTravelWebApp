using FastTravel.Data;
using FastTravel.Models;
using FastTravel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.OData.Edm;
using System.Collections.Generic;
using System.Diagnostics;

namespace FastTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FastTravelDbContext _db;

        public HomeController(ILogger<HomeController> logger, FastTravelDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            //List<PackageView> packageList = new List<PackageView>();

            List<Package> packageList = new List<Package>();
            packageList.Add(new Package());
            packageList.Add(new Package());
            packageList.Add(new Package());
            packageList.Add(new Package());

            return View(packageList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult MenuTrigger()
        {
            Debug.WriteLine("test");
            return null;
        }

        //private List<PackageView> FindAllPackages()
        //{
        //    List<PackageView> packages = new List<PackageView>();
        //    List<Flight> flights = _db.Flights.ToList();


        //}

        //private StationView CreateStationView(Station station)
        //{
            //Port port = _db.Ports.Where(port => port.portID == station.portID).ToList()[0];
            //return new StationView(station.order, station.time, station.date, port);
        //}
    }
}