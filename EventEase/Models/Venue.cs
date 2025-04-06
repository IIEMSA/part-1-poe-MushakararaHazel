using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Venue
    {
        // Primary key (auto-incremented by database)
        public int VenueId { get; set; }

        // Required field with maximum length
        [Required(ErrorMessage = "Venue name is required")]
        [StringLength(100, ErrorMessage = "Venue name cannot exceed 100 characters")]
        public string? VenueName { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string? Location { get; set; }

        // Validation for numeric range
        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1")]
        public int Capacity { get; set; }

        // Optional field for image URL
        // Optional field for image URL
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? ImageUrl { get; set; }

        // Navigation property for related bookings
        public ICollection<Booking>? Bookings { get; set; }
    }
}
