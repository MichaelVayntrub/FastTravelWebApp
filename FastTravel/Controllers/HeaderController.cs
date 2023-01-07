using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FastTravel.Controllers
{
    public class HeaderController : Controller
    {   
        public IActionResult Index()
        {
            Debug.WriteLine("here2");
            return View();
        }

        public void trigger_menu()
        {
            //change the class and do other stuff after the button click
            Console.WriteLine("here");
        }
    }
}
