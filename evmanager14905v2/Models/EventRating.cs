using System.ComponentModel.DataAnnotations;

namespace evmanager14905v2.Models
{
    public class EventRating
    {
        [Key] 
        public int RatingId { get; set; }
        public int Id { get; set; }
        public int Rating { get; set; }
        public Event Event { get; set; }
    }
}
