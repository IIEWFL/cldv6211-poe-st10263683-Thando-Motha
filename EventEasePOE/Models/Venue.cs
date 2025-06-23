using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventEasePOE.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required]
        [StringLength(100)]
        public string VenueName { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        public int Capacity { get; set; }

        public string? ImageUrl { get; set; }

        public int? EventTypeId { get; set; }

        [ForeignKey("EventTypeId")]
        public EventType? EventType { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
