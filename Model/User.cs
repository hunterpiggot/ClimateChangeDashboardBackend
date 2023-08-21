using System.ComponentModel.DataAnnotations;

namespace ClimateChangeDashboardBackend.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The username is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "The role is required")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "The CreatedAt is required")]
        public string CreatedAt { get; set; } = string.Empty;

        [Required(ErrorMessage = "The <MembershipLevel> is required")]
        public string MembershipLevel { get; set; } = string.Empty;

        [Required(ErrorMessage = "The Password is required")]
        public string Password { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        [UseSorting]
        public ICollection<Feedback>? Feedbacks { get; set; }

        [UseSorting]
        public ICollection<Analytics>? Analytics { get; set; }
    }
}