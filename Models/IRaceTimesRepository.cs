using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimes.Models
{
    public interface IRaceTimesRepository
    {
        IQueryable<Racer> Racers { get; }

        void AddRaceTime(Racer r);
        void DeleteRaceTime(Racer r);
    }
}
