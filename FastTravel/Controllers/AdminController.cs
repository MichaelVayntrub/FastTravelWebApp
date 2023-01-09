using FastTravel.Data;
using FastTravel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastTravel.Controllers
{
    public class AdminController : Controller
    {
        private readonly FastTravelDbContext _db;

        public AdminController(FastTravelDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            //IEnumerable<Flight> flightList = _db.Flights.ToList();
            List<Flight> flightList = new List<Flight>();
            flightList.Add(new Flight());
            flightList.Add(new Flight());
            flightList.Add(new Flight());
            flightList.Add(new Flight());
            flightList.Add(new Flight());
            flightList.Add(new Flight());
            flightList.Add(new Flight());
            flightList.Add(new Flight());
            return View(flightList);
            //return View();
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
