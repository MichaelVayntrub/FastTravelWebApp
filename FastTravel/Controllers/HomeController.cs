using FastTravel.Data;
using FastTravel.Models;
using FastTravel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            PackageView view = new PackageView();
            //view.packages = _db.GetAllPackages();
            Flight f = new Flight() { flightNumber = 1, source = _db.Ports.First(), destination = _db.Ports.First() };
            view.packages = new List<Package>()
            {
                new Package(){packageID = 0, flight1 = f},
            };

            return View(view);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PackageView view)
        {
            //view.packages = _db.GetAllPackages();
            Flight f = new Flight() { flightNumber = 1, source = _db.Ports.First(), destination = _db.Ports.First() };
            view.packages = new List<Package>()
            {
                new Package(){packageID = 0, flight1 = f},
            };
            if (view.chosenPackage != -1)
            {
                view.curr = view.packages.ToList()[view.chosenPackage];
            }
            return View(view);
        }

        public IActionResult Checkout()
        { 
            return View();
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
    }
}