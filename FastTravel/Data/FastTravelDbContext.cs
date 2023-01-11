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
            else if (filter.country != null)
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

        public List<Plane> GetFilteredPlaneList(PlaneFilter filter)
        {
            List<Plane> filtered = Planes.ToList();

            if (filter.company != null)
            {
                filtered = filtered.Where(x => x.company == filter.company).ToList();
            }
            if (filter.minSeats != null)
            {
                filtered = filtered.Where(x => x.seatsNum >= filter.minSeats).ToList();
            }
            if (filter.maxSeats != null)
            {
                filtered = filtered.Where(x => x.seatsNum <= filter.maxSeats).ToList();
            }
            return filtered;
        }

        public List<Flight> GetFilteredFlightList(FlightFilter filter)
        {
            List<Flight> filtered = new List<Flight>();

            if(filter.destination != null)
            {
                filtered = filtered.Where(x => x.destination == filter.destination).ToList();
            }
            if(filter.dateFrom != null)
            {
                filtered = filtered.Where(x => x.dateFrom >= filter.dateFrom).ToList();
            }
            if (filter.dateTo != null)
            {
                filtered = filtered.Where(x => x.dateTo <= filter.dateTo).ToList();
            }
            return filtered;
        }
    }
}
