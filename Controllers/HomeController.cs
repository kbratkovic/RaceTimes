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

        public IActionResult Index() => View(repository.Racers.OrderBy(r => r.RaceTime));

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
