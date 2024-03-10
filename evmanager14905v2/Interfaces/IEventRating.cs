using evmanager14905v2.Models;
using System;
using System.Collections.Generic;

namespace Events_Manager_14905.Interfaces
{
    public interface IEventRating
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
