using evmanager14905v2.Interfaces;
using evmanager14905v2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace evmanager14905v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventWithRating>> GetEvents()
        {
            var events = _eventRepository.GetEvents();

            
            var eventsWithRatings = new List<EventWithRating>();

            
            foreach (var evnt in events)
            {
                
                var rating = _eventRepository.GetEventRating(evnt.EventId);

                
                var eventWithRating = new EventWithRating
                {
                    EventId = evnt.EventId,
                    Name = evnt.Name,
                    CreatedAt = evnt.CreatedAt,
                    CompletedDate = evnt.CompletedDate,
                    EventRating = rating
                };

               
                eventsWithRatings.Add(eventWithRating);
            }

            return Ok(eventsWithRatings);
        }

        [HttpGet("{id}")]
        public ActionResult<EventWithRating> GetEvent(int id)
        {
            var evnt = _eventRepository.GetEvent(id);
            if (evnt == null)
            {
                return NotFound();
            }

           
            var rating = _eventRepository.GetEventRating(id);

          
            var eventWithRating = new EventWithRating
            {
                EventId = evnt.EventId,
                Name = evnt.Name,
                CreatedAt = evnt.CreatedAt,
                CompletedDate = evnt.CompletedDate,
                EventRating = rating
            };

            return Ok(eventWithRating);
        }

        [HttpPost]
        public ActionResult<Event> CreateEvent(Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_eventRepository.CreateEvent(newEvent))
            {
                return CreatedAtAction(nameof(GetEvent), new { id = newEvent.EventId }, newEvent);
            }
            return StatusCode(500);
        }

        [HttpPut("{id}")]
        public ActionResult<Event> UpdateEvent(int id, Event updatedEvent)
        {
            if (id != updatedEvent.EventId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_eventRepository.UpdateEvent(updatedEvent))
            {
                return StatusCode(500);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Event> DeleteEvent(int id)
        {
            if (!_eventRepository.EventExists(id))
            {
                return NotFound();
            }
            if (!_eventRepository.DeleteEvent(id))
            {
                return StatusCode(500);
            }
            return NoContent();
        }
    }

    // Define a new class to represent the response with event details and rating
    public class EventWithRating
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedDate { get; set; }
        public double EventRating { get; set; } // Assuming the rating is a double
    }
}
