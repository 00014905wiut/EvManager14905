using System.ComponentModel.DataAnnotations;

namespace evmanager14905v2.Models;
public class Event
{

    [Key] 
    public int EventId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public ICollection<EventRating> Ratings { get; set; }
}

