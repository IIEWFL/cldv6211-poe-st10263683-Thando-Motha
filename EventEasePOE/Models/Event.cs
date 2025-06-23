// Models/Event.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventEasePOE.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        // Foreign key for Venue
        public int VenueId { get; set; }
        public Venue Venue { get; set; }  // Navigation property for Venue

        // Navigation property for related bookings
        public ICollection<Booking> Bookings { get; set; }
    }
}

