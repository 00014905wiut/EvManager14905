using evmanager14905v2.Interfaces;
using evmanager14905v2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<EventRating>> GetEventRatings()
        {
            var ratings = _eventRatingRepository.GetEventRatings();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public ActionResult<EventRating> GetEventRating(int id)
        {
            var rating = _eventRatingRepository.GetEventRating(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        public ActionResult<EventRating> CreateEventRating(EventRating newEventRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_eventRatingRepository.CreateEventRating(newEventRating))
            {
                return CreatedAtAction(nameof(GetEventRating), new { id = newEventRating.RatingId }, newEventRating);
            }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public ActionResult<EventRating> UpdateEventRating(int id, EventRating updatedEventRating)
        {
            if (id != updatedEventRating.RatingId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_eventRatingRepository.UpdateEventRating(updatedEventRating))
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<EventRating> DeleteEventRating(int id)
        {
            if (!_eventRatingRepository.EventRatingExists(id))
            {
                return NotFound();
            }
            if (!_eventRatingRepository.DeleteEventRating(id))
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }
}
