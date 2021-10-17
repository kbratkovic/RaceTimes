using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimes.Models
{
    public class EFRaceTimesRepository : IRaceTimesRepository
    {
        private RacerDbContext context;

        public EFRaceTimesRepository(RacerDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Racer> Racers => context.Racers;
        
        public void AddRaceTime(Racer r)
        {
            context.Add(r);
            context.SaveChanges();
        }

        public void DeleteRaceTime(Racer r)
        {
            context.Remove(r);
            context.SaveChanges();
        }

    }
}
