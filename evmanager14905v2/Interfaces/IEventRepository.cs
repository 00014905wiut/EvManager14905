using System;
using System.Collections.Generic;
using evmanager14905v2.Models;

namespace evmanager14905v2.Interfaces
{
    public interface IEventRepository
    {
        ICollection<Event> GetEvents();
        Event GetEvent(int eventId);
        string GetEventName(int eventId);
        bool EventExists(int eventId);
        ICollection<Event> GetEventsForDate(DateTime eventDate);
        bool CreateEvent(Event newEvent);
        bool UpdateEvent(Event updatedEvent);
        int GetEventRating(int eventId);
        bool DeleteEvent(int eventId);
        bool SaveChanges();
    }
}
