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
            if(view.ways == 1)
            {
                view.packages = _db.GetOneWayPackages(user);
            }
            else
            {
                view.packages = _db.GetTwoWayPackages(user);
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

            return View("Index");
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

        private List<Package> GetFilteredPackagesOneWay(PackageView view)
        {
            List<Package> filtered = view.packages.ToList();
            if(view.filter.minPrice != null)
            {
                filtered.Where(p => p.flight1.adult >= view.filter.minPrice);
            }
            if (view.filter.maxPrice != null)
            {
                filtered.Where(p => p.flight1.adult <= view.filter.maxPrice);
            }
            if (view.filter.directOnly)
            {
                filtered.Where(p => p.flight1.adult <= view.filter.maxPrice);
            }
            if (view.filter.dateSource != null)
            {
                filtered.Where(p => p.flight1.adult <= view.filter.maxPrice);
            }

            return filtered;
        }
    }
}