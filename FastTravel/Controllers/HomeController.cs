using FastTravel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Diagnostics;

namespace FastTravel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<PetTicket> petTicketList = new List<PetTicket>();
            return View(petTicketList);
        }
        [HttpPost]
        public IActionResult Index(IEnumerable<PetTicket> petTicket)
        {
            return View(petTicket);
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