using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceTimes.Models
{
    public class RacerDbContext : DbContext
    {
        public RacerDbContext(DbContextOptions<RacerDbContext> options) : base (options)
        {
        }

        public DbSet<Racer> Racers { get; set; }
    }
}
