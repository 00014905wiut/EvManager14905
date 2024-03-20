using System.ComponentModel.DataAnnotations;

namespace evmanager14905v2.Models
{
    public class EventRating
    {
        
        public int RatingId { get; set; }

        public int Rating { get; set; }

        [Key] 
        public int EventId { get; set; }





    }
}
