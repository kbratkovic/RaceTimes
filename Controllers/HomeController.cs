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

        public HomeController(IRaceTimesRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index() => View(repository.Racers.OrderBy(h => h.Hours).ThenBy(m => m.Minutes).ThenBy(s => s.Seconds));

        [HttpGet]
        public IActionResult AddTime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTime(Racer racer)
        {
            if (racer.FirstName != null && racer.LastName != null
                && racer.Hours != 0 && racer.Minutes != 0 && racer.Seconds != 0 && racer.Milliseconds != 0)
            {
                UserTimesRepository.AddUserTime(racer);
            }
            return View("AddTime", racer);
        }

        public ViewResult ListOfRacers()
        {
            return View(UserTimesRepository.UserTimes);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
