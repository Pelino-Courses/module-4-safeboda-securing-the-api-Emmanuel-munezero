using SafeBoda.Core;

public interface ITripRepository
{
    IEnumerable<Trip> GetActiveTrips();
    Trip GetTripById(Guid id);
    void AddTrip(Trip trip);
    void UpdateTrip(Trip trip);
    void DeleteTrip(Guid id);
}