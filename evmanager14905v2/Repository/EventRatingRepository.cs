using evmanager14905v2.Data;
using evmanager14905v2.Interfaces;
using evmanager14905v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace evmanager14905v2.Repositories
{
    public class EventRatingRepository : IEventRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<EventRating> GetEventRatings()
        {
            return _context.EventRatings.ToList();
        }

        public EventRating GetEventRating(int eventRatingId)
        {
            return _context.EventRatings.FirstOrDefault(er => er.RatingId == eventRatingId);
        }

        public ICollection<EventRating> GetEventRatingsForEvent(int eventId)
        {
            return _context.EventRatings.Where(er => er.EventId == eventId).ToList();
        }

        public double GetAverageEventRating(int eventId)
        {
            var eventRatings = _context.EventRatings.Where(er => er.EventId == eventId).Select(er => er.Rating);
            return eventRatings.Any() ? eventRatings.Average() : 0;
        }

        public bool EventRatingExists(int eventRatingId)
        {
            return _context.EventRatings.Any(er => er.RatingId == eventRatingId);
        }

        public bool CreateEventRating(EventRating newEventRating)
        {
            try
            {
                _context.EventRatings.Add(newEventRating);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEventRating(EventRating updatedEventRating)
        {
            try
            {
                _context.EventRatings.Update(updatedEventRating);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteEventRating(int eventRatingId)
        {
            try
            {
                var ratingToDelete = _context.EventRatings.FirstOrDefault(er => er.RatingId == eventRatingId);
                if (ratingToDelete != null)
                {
                    _context.EventRatings.Remove(ratingToDelete);
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