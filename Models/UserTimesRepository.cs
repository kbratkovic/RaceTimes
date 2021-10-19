using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimes.Models
{
    public class UserTimesRepository
    {
        private static List<Racer> userTimesList = new List<Racer>();

        public static IEnumerable<Racer> UserTimes => userTimesList;

        public static void AddUserTime(Racer userTime)
        {
            userTimesList.Add(userTime);
        }

        public static void DeleteUserTime(Racer userTime)
        {
            userTimesList.Remove(userTime);
        }

    }
}
