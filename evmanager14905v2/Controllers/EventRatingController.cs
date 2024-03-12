using Microsoft.AspNetCore.Mvc;
using evmanager14905v2.Interfaces;
using evmanager14905v2.Models;
using System;

namespace evmanager14905v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRatingController : ControllerBase
    {
        private readonly IEventRatingRepository _eventRatingRepository;

        public EventRatingController(IEventRatingRepository eventRatingRepository)
        {
            _eventRatingRepository = eventRatingRepository;
        }

        [HttpGet]
        public IActionResult GetEventRatings()
        {
            var eventRatings = _eventRatingRepository.GetEventRatings();
            return Ok(eventRatings);
        }

        [HttpGet("{id}")]
        public IActionResult GetEventRating(int id)
        {
            var eventRating = _eventRatingRepository.GetEventRating(id);
            if (eventRating == null)
                return NotFound();
            return Ok(eventRating);
        }

        [HttpPost]
        public IActionResult CreateEventRating(EventRating newEventRating)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_eventRatingRepository.CreateEventRating(newEventRating))
                return CreatedAtAction(nameof(GetEventRating), new { id = newEventRating.RatingId }, newEventRating);

            return StatusCode(500, "Could not create the event rating.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEventRating(int id, EventRating updatedEventRating)
        {
            if (id != updatedEventRating.RatingId)
                return BadRequest("Rating ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_eventRatingRepository.EventRatingExists(id))
                return NotFound();

            if (_eventRatingRepository.UpdateEventRating(updatedEventRating))
                return NoContent();

            return StatusCode(500, "Could not update the event rating.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEventRating(int id)
        {
            var existingEventRating = _eventRatingRepository.GetEventRating(id);
            if (existingEventRating == null)
                return NotFound();

            if (_eventRatingRepository.DeleteEventRating(id))
                return NoContent();

            return StatusCode(500, "Could not delete the event rating.");
        }
    }
}
