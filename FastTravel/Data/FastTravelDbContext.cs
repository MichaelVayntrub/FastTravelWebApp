using FastTravel.Models;
using Microsoft.EntityFrameworkCore;

namespace FastTravel.Data
{
    public class FastTravelDbContext : DbContext
    {
        //public DbSet<PetTicket> PetTickets { get; set; }
        public DbSet<Luggage> Luggages { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public FastTravelDbContext(DbContextOptions<FastTravelDbContext> options) : base(options)
        {

        }
    }
}
