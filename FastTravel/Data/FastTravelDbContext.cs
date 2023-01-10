using FastTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace FastTravel.Data
{
    public class FastTravelDbContext : DbContext
    {
        public DbSet<Port> Ports { get; set; }
        public DbSet<Plane> Planes { get; set; }
        //public DbSet<Luggage> Luggages { get; set; }
        //public DbSet<Flight> Flights { get; set; }

        public FastTravelDbContext(DbContextOptions<FastTravelDbContext> options) : base(options)
        {
            
        }

        public void AddPlane(Plane plane)
        {
            Planes.Add(plane);
            SaveChanges();
        }
    }
}
