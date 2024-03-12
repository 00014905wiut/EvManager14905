using System;
using System.Collections.Generic;
using evmanager14905v2.Models;

namespace evmanager14905v2.Interfaces
{
    public interface IEventRatingRepository
    {
        ICollection<EventRating> GetEventRatings();
        EventRating GetEventRating(int eventRatingId);
        ICollection<EventRating> GetEventRatingsForEvent(int eventId);
        double GetAverageEventRating(int eventId);
        bool EventRatingExists(int eventRatingId);
        bool CreateEventRating(EventRating newEventRating);
        bool UpdateEventRating(EventRating updatedEventRating);
        bool DeleteEventRating(int eventRatingId);
        bool SaveChanges();
    }
}
