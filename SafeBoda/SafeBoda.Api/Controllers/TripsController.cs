using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SafeBoda;
using SafeBoda.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeBoda.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  // This secures the entire controller
    public class TripsController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;

        public TripsController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Trip>> GetActiveTrips()
        {
            var activeTrips = _tripRepository.GetActiveTrips();
            return Ok(activeTrips);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Trip> GetTripById(Guid id)
        {
            var trip = _tripRepository.GetTripById(id);
            if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        [HttpPost("request")]
        public ActionResult<Trip> RequestTrip([FromBody] TripRequest tripRequest)
        {
            if (tripRequest == null)
            {
                return BadRequest("Invalid trip request.");
            }

            var newTrip = new Trip(
                Id: Guid.NewGuid(),
                RiderId: tripRequest.RiderId,
                DriverId: Guid.Empty, 
                Start: tripRequest.Start,
                End: tripRequest.End,
                Fare: 0, 
                RequestTime: DateTime.UtcNow);

            _tripRepository.AddTrip(newTrip); 
            return CreatedAtAction(nameof(GetTripById), new { id = newTrip.Id }, newTrip);
        }

      
        [HttpPut("{id}")]
        public ActionResult UpdateTrip(Guid id, [FromBody] Trip updatedTrip)
        {
            if (updatedTrip == null || id != updatedTrip.Id)
            {
                return BadRequest("Trip ID mismatch or invalid trip data.");
            }

            var existingTrip = _tripRepository.GetTripById(id);
            if (existingTrip == null)
            {
                return NotFound();
            }

            _tripRepository.UpdateTrip(updatedTrip); 
            return NoContent(); 
        }

    
        [HttpDelete("{id}")]
        public ActionResult DeleteTrip(Guid id)
        {
            var trip = _tripRepository.GetTripById(id);
            if (trip == null)
            {
                return NotFound();
            }

            _tripRepository.DeleteTrip(id);
            return NoContent(); 
        }
    }
}