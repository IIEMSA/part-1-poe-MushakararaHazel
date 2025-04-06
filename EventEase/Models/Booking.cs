using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        // Required foreign key to Event
        [Required]
        [Display(Name = "Event")]
        public int EventId { get; set; }

        // Navigation property
        public Events? Event { get; set; }

        // Required foreign key to Venue
        [Required]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        // Navigation property
        public Venue? Venue { get; set; }

        // Default to current date/time
        [DataType(DataType.DateTime)]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; } = DateTime.Now;
    }
}
