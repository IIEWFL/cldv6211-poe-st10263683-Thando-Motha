// Models/Booking.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace EventEasePOE.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        // Foreign keys for the related Event and Venue
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }
    }
}
