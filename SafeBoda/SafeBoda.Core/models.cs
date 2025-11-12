using System;

namespace SafeBoda.Core
{
    public record Location(double Latitude, double Longitude);

    public record Rider(Guid Id, string Name, string PhoneNumber);

    public record Driver(Guid Id, string Name, string PhoneNumber, string MotoPlateNumber);

    public record Trip
    {
     
        protected Trip() { }

        public Trip(Guid Id, Guid RiderId, Guid DriverId, Location Start, Location End, decimal Fare, DateTime RequestTime)
        {
            this.Id = Id;
            this.RiderId = RiderId;
            this.DriverId = DriverId;
            this.Start = Start;
            this.End = End;
            this.Fare = Fare;
            this.RequestTime = RequestTime;
        }

        public Guid Id { get; init; }
        public Guid RiderId { get; init; }
        public Guid DriverId { get; init; }
        public Location Start { get; init; }
        public Location End { get; init; }
        public decimal Fare { get; init; }
        public DateTime RequestTime { get; init; }
    }


    public record TripRequest(Guid RiderId, Location Start, Location End);
}