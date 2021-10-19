using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaceTimes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimes.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRaceTimesRepository repository;

        public AdminController(IRaceTimesRepository repo)
        {
            repository = repo;
        }


        public IActionResult Index() => 
            View(repository.Racers.OrderBy(h => h.Hours).ThenBy(m => m.Minutes).ThenBy(s => s.Seconds).ThenBy(ms => ms.Milliseconds));


        public IActionResult ConfirmTime() =>
            View(UserTimesRepository.UserTimes.OrderBy(h => h.Hours).ThenBy(m => m.Minutes).ThenBy(s => s.Seconds).ThenBy(ms => ms.Milliseconds));


        public IActionResult Delete(int? id)
        {
            var obj = repository.Racers.FirstOrDefault(r => r.RacerID == id);
            repository.DeleteRaceTime(obj);

            return RedirectToAction("Index");
        }
        

        public IActionResult DeleteFromList(int? id)
        {
            var obj = UserTimesRepository.UserTimes.FirstOrDefault(r => r.RacerID == id);
            UserTimesRepository.DeleteUserTime(obj);

            return RedirectToAction("ConfirmTime");
        }


        public IActionResult ConfirmFromList(int? id)
        {
            var obj = UserTimesRepository.UserTimes.FirstOrDefault(r => r.RacerID == id);
            Racer listRacer = new Racer
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Hours = obj.Hours,
                Minutes = obj.Minutes,
                Seconds = obj.Seconds,
                Milliseconds = obj.Milliseconds
            };

            repository.AddRaceTime(listRacer);
            UserTimesRepository.DeleteUserTime(obj);

            return RedirectToAction("ConfirmTime");
        }

    }
}
