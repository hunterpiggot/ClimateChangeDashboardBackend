using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimateChangeDashboardBackend.Models
{
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }

        public string? Title { get; set; }

        [Required(ErrorMessage = "The body is required")]
        public string Body { get; set; } = string.Empty;


        [Required(ErrorMessage = "The userid is required")]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public string? Status { get; set; }

        [Required(ErrorMessage = "The role is required")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "The CreatedAt is required")]
        public string CreatedAt { get; set; } = string.Empty;

    }
}