using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace evmanager14905v2.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        
        public EventRating EventRating { get; set; }
    }
}

