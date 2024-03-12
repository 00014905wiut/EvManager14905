using Microsoft.AspNetCore.Mvc;
using evmanager14905v2.Interfaces;
using evmanager14905v2.Models;
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
        public IActionResult GetEvents()
        {
            var events = _eventRepository.GetEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var @event = _eventRepository.GetEvent(id);
            if (@event == null)
                return NotFound();
            return Ok(@event);
        }

        [HttpPost]
        public IActionResult CreateEvent(Event newEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_eventRepository.CreateEvent(newEvent))
                return CreatedAtAction(nameof(GetEvent), new { id = newEvent.EventId }, newEvent);

            return StatusCode(500, "Could not create the event.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, Event updatedEvent)
        {
            if (id != updatedEvent.EventId)
                return BadRequest("Event ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_eventRepository.EventExists(id))
                return NotFound();

            if (_eventRepository.UpdateEvent(updatedEvent))
                return NoContent();

            return StatusCode(500, "Could not update the event.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var existingEvent = _eventRepository.GetEvent(id);
            if (existingEvent == null)
                return NotFound();

            if (_eventRepository.DeleteEvent(id))
                return NoContent();

            return StatusCode(500, "Could not delete the event.");
        }
    }
}
