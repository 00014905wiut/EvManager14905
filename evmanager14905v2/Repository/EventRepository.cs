using evmanager14905v2.Data;
using evmanager14905v2.Interfaces;
using evmanager14905v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace evmanager14905v2.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        public Event GetEvent(int eventId)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == eventId);
        }

        public Event GetEventByName(string eventName)
        {
            return _context.Events.FirstOrDefault(e => e.Name == eventName);
        }

        public double GetAverageEventRating(int eventId)
        {
            var eventRatings = _context.EventRatings.Where(er => er.EventId == eventId).Select(er => er.Rating);
            return eventRatings.Any() ? eventRatings.Average() : 0;
        }

        public string GetEventName(int eventId)
        {
            var eventName = _context.Events.Where(e => e.EventId == eventId).Select(e => e.Name).FirstOrDefault();
            return eventName ?? string.Empty;
        }

        public bool EventExists(int eventId)
        {
            return _context.Events.Any(e => e.EventId == eventId);
        }

        public ICollection<Event> GetEventsForDate(DateTime eventDate)
        {
            return _context.Events.Where(e => e.CreatedAt.Date == eventDate.Date).ToList();
        }

        public bool CreateEvent(Event newEvent)
        {
            try
            {
                _context.Events.Add(newEvent);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEvent(Event updatedEvent)
        {
            try
            {
                _context.Events.Update(updatedEvent);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteEvent(int eventId)
        {
            try
            {
                var eventToDelete = _context.Events.FirstOrDefault(e => e.EventId == eventId);
                if (eventToDelete != null)
                {
                    _context.Events.Remove(eventToDelete);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
