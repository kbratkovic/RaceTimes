using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimes.Models
{
    public static class UserTimesRepository
    {
        private static List<Racer> userTimes = new List<Racer>();

        public static IEnumerable<Racer> UserTimes => userTimes;

        public static void AddUserTime(Racer userTime)
        {
            userTimes.Add(userTime);
        }
    }
}
