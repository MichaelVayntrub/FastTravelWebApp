using FastTravel.Areas.Identity.Data;
using FastTravel.Data;
using FastTravel.Models;
using FastTravel.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.OData.Edm;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Security.Claims;

namespace FastTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FastTravelDbContext _db;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, FastTravelDbContext db, UserManager<User> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            PackageView view = new PackageView();
            string user = GetUserId();
            view.packages = _db.GetOneWayPackages(user);
            
            return View(view);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PackageView view)
        {
            string user = GetUserId();
            if(view.ways == 2)
            {
                List<Package> packages = _db.GetTwoWayPackages(user);
                if (view.filterSource != null)
                    packages = packages.Where(x => x.flight1.source.country == view.filterSource).ToList();
                if (view.filterDestination != null)
                    packages = packages.Where(x => x.flight1.destination.country == view.filterDestination).ToList();
                packages = packages.Where(x => x.flight1.dateFrom >= view.filter.dateSource).ToList();
                if (view.filter.minPrice != null)
                {
                    packages = packages.Where(x => x.flight1.adult >= view.filter.minPrice).ToList();
                }
                if (view.filter.maxPrice != null)
                {
                    packages = packages.Where(x => x.flight1.adult <= view.filter.maxPrice).ToList();
                }
                if (view.filter.directOnly == 1)
                {
                    packages = packages.Where(x => x.flight1.stops == 0).ToList();
                }
                view.packages = packages;
            }
            else
            {
                List<Package> packages = _db.GetOneWayPackages(user);
                if (view.filterSource != null)
                    packages = packages.Where(x => x.flight1.source.country.Equals(view.filterSource)).ToList();
                if (view.filterDestination != null)
                    packages = packages.Where(x => x.flight1.destination.country.Equals(view.filterDestination)).ToList();
                packages = packages.Where(x => x.flight1.dateFrom >= view.filter.dateSource).ToList();
                if (view.filter.minPrice != null)
                {
                    packages = packages.Where(x => x.flight1.adult >= view.filter.minPrice).ToList();
                }
                if (view.filter.maxPrice != null)
                {
                    packages = packages.Where(x => x.flight1.adult <= view.filter.maxPrice).ToList();
                }
                if (view.filter.directOnly == 1)
                {
                    packages = packages.Where(x => x.flight1.stops == 0 &&  x.flight2.stops == 0).ToList();
                }
                view.packages = packages;
            }
            
            if (view.chosenPackage != -1)
            {
                view.curr = view.packages.ToList()[view.chosenPackage];
            }
            return View(view);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(PackageView view)
        {
            CheckoutView checkout = new CheckoutView();
            string user = GetUserId();
            var id = _userManager.GetUserId(User);
            checkout.package = _db.GetOneWayPackages(id).ToList()[view.chosenPackage];
            if(_db.CheckCredit(id))
            {
                checkout.credit = _db.GetCredit(id);
                checkout.loadCredit = true;
            }
            else
            {
                checkout.credit = new Credit();
                checkout.loadCredit = false;
            }
            return View(checkout);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(CheckoutView view)
        {
            string user = GetUserId();
            string id = _userManager.GetUserId(User);

            FlightData flight = _db.FlightsData.First(x => x.flightNumber == view.flightID);
            int remaining = flight.seatsRemain;
            if (remaining - view.ticketCount < 0 || flight.dateFrom >= DateTime.Now)
            {
                return View("Checkout", view);
            }
            else
            {
                _db.FlightsData.First(x => x.flightNumber == view.flightID).seatsRemain -= view.ticketCount;
                _db.FlightsData.First(x => x.flightNumber == view.flightID).seatsUsed += view.ticketCount;
                _db.SaveChanges();

            }

            if (view.saveCredit == 1)
            {
                Credit credit = new Credit()
                {
                    fullName = view.fullName,
                    creditNum = view.creditNum,
                    expiredDate = view.expiredDate,
                    expiredYear = view.expiredYear,
                    securityCode = view.securityCode,
                    userID = id,
                };
                _db.AddCredit(id, credit);
            }
            CheckoutView checkout = new CheckoutView();
            checkout.package = _db.GetOneWayPackages(id).ToList()[view.packageID];
            if (_db.CheckCredit(id))
            {
                checkout.credit = _db.GetCredit(id);
                checkout.loadCredit = true;
            }
            else
            {
                checkout.credit = new Credit();
                checkout.loadCredit = false;
            }
            checkout.confirmed = 1;

            return View("Checkout", checkout );
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetUserId()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            bool isAdmin = currentUser.IsInRole("Admin");
            return _userManager.GetUserId(User);
        }
    }
}