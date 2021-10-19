using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RaceTimes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimes.Controllers
{
    public class HomeController : Controller
    {
        private IRaceTimesRepository repository;
        private static int RacerIdCounter = 0;

        public HomeController(IRaceTimesRepository repo)
        {
            repository = repo;
        }


        public IActionResult Index() => 
            View(repository.Racers.OrderBy(h => h.Hours).ThenBy(m => m.Minutes).ThenBy(s => s.Seconds));


        [HttpGet]
        public IActionResult AddTime() => View("AddTime");


        [HttpPost]
        public IActionResult AddTime(Racer racer)
        {
            if (!ModelState.IsValid)
            {
                return View("AddTime");
            } 
            
            RacerIdCounter++;
            racer.RacerID = RacerIdCounter;
            UserTimesRepository.AddUserTime(racer);
            return View("AddTime", racer);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
