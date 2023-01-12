using FastTravel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace FastTravel.Data
{
    public class FastTravelDbContext : DbContext
    {
        public DbSet<Port> Ports { get; set; }
        public DbSet<Plane> Planes { get; set; }
        //public List<Flight> Flights { get; set; }
        public DbSet<FlightData> FlightsData { get; set; }

        //public DbSet<Luggage> Luggages { get; set; }

        public FastTravelDbContext(DbContextOptions<FastTravelDbContext> options) : base(options)
        {

        }

        public void AddPlane(Plane plane)
        {
            Planes.Add(plane);
            SaveChanges();
        }

        public void AddFlight(Flight flight)
        {
            FlightsData.Add(ConvertFlightToData(flight));
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

        public Port FindPort(int id)
        {
            return Ports.First(p => p.portID == id);
        }
        public Port? FindPort(int? id)
        {
            if (id == null) return null;
            return Ports.First(p => p.portID == id);
        }
        public Plane FindPlane(int id)
        {
            return Planes.First(p => p.planeID == id);
        }
        public Plane? FindPlane(int? id)
        {
            if (id == null) return null;
            return Planes.First(p => p.planeID == id);
        }
        public Flight FindFlight(int id)
        {
            List<Port> ports = Ports.ToList();
            List<Plane> planes = Planes.ToList();
            return ConvertDataToFlight(FlightsData.First(f => f.flightNumber == id), ports, planes);
        }

        public List<Flight> GetFlights()
        {
            List<Port> ports = Ports.ToList();
            List<Plane> planes = Planes.ToList();
            List<Flight> flights = new List<Flight>();
            foreach(FlightData data in FlightsData)
            {
                flights.Add(ConvertDataToFlight(data, ports, planes));
            }
            return flights;
        }

        public Flight ConvertDataToFlight(FlightData data, List<Port> ports, List<Plane> planes)
        {
            Port? fstop1 = null, fstop2 = null;
            DateTime? fdate1 = null, fdate2 = null;
            if (data.stop1 != null)
            {
                fstop1 = ports.Where(p => p.portID == (int)data.stop1).First();
                fdate1 = data.date1;
            }
            if (data.stop2 != null)
            {
                fstop2 = ports.Where(p => p.portID == (int)data.stop2).First();
                fdate2 = data.date2;
            }

            Flight flight = new Flight()
            {
                flightNumber = data.flightNumber,
                source = ports.Where(p => p.portID == data.source).First(),
                dateFrom = data.dateFrom,
                destination = ports.Where(p => p.portID == data.destination).First(),
                dateTo = data.dateTo,
                stop1 = fstop1,
                date1 = fdate1,
                stop2 = fstop2,
                date2 = fdate2,
                plane = planes.Where(p => p.planeID == data.plane).First(),
                child = data.child,
                adult = data.adult,
                elder = data.elder
            };
            return flight;
        }
        public FlightData ConvertFlightToData(Flight flight)
        {
            int? dstop1 = null, dstop2 = null;
            DateTime? ddate1 = null, ddate2 = null;
            if (flight.stop1 != null)
            {
                dstop1 = flight.stop1.portID;
                ddate1 = flight.date1;
            }
            if (flight.stop2 != null)
            {
                dstop2 = flight.stop2.portID;
                ddate2 = flight.date2;
            }
            
            FlightData data = new FlightData()
            {
                flightNumber = flight.flightNumber,
                source = flight.source.portID,
                dateFrom = flight.dateFrom,
                destination = flight.destination.portID,
                dateTo = flight.dateTo,
                stop1 = dstop1,
                date1 = ddate1,
                stop2 = dstop2,
                date2 = ddate2,
                plane = flight.plane.planeID,
                child = flight.child,
                adult = flight.adult,
                elder = flight.elder
            };
            return data;
        }

        public List<Package> GetAllPackages()
        {
            List<Flight> flights = GetFlights();
            List<Package> packages = new List<Package>();
            int count = 0;

            foreach (Flight flight in flights)
            {
                packages.Add(new Package() { 
                    packageID = count++,
                    //image = ???
                    flight1 = flight,
                    //flight2 = flight,
                });
            }
            return packages;
        }
    }
}
