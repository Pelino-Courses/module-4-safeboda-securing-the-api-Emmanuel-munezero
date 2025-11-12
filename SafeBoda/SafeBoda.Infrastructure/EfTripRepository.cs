using System.Collections.Generic;
using System.Linq;
using SafeBoda;
using SafeBoda.Core;
using SafeBoda.Infrastructure;

namespace SafeBoda.Infrastructure
{
    public class EfTripRepository : ITripRepository
    {
        private readonly SafeBodaDbContext _context;

        public EfTripRepository(SafeBodaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Trip> GetActiveTrips()
        {
           
            return _context.Trips.ToList();
        }

        public Trip GetTripById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        public void UpdateTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public void DeleteTrip(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}