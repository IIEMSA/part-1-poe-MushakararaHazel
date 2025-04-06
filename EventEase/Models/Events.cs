using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Events
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required")]
        [StringLength(100, ErrorMessage = "Event name cannot exceed 100 characters")]
        public string? EventName { get; set; }

        // Date validation ensuring future dates
        [Required(ErrorMessage = "Event date is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Event Date")]
        [FutureDate(ErrorMessage = "Event date must be in the future")]
        public DateTime EventDate { get; set; }

        public string? Description { get; set; }

        // Foreign key (nullable for unbooked events)
        [Display(Name = "Venue")]
        public int? VenueId { get; set; }

        // Navigation property
        public Venue? Venue { get; set; }

        // Collection of bookings for this event
        public ICollection<Booking>? Bookings { get; set; }

        private class FutureDateAttribute : Attribute
        {
            public string? ErrorMessage;
        }
    }
}
