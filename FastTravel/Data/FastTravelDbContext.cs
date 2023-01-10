using FastTravel.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

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

        public List<Port> GetFilteredPortList(PortFilter filter)
        {
            List<Port> filtered;

            if (filter.country != null && filter.city != null)
            {
                filtered = Ports.FromSql($@"SELECT * FROM dbo.ports WHERE country = {filter.country}
                                         AND city = {filter.city}").ToList();
            }
            else if(filter.country != null)
            {
                filtered = Ports.FromSql($"SELECT * FROM dbo.ports WHERE country = {filter.country}").ToList();
            }
            else if (filter.city != null)
            {
                filtered = Ports.FromSql($"SELECT * FROM dbo.ports WHERE city = {filter.city}").ToList();
            }
            else filtered = Ports.ToList();
            return filtered;
        }
    }
}
