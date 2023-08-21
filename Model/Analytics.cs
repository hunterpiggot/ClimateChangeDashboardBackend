using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimateChangeDashboardBackend.Models
{
    public class Analytics
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The userid is required")]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public Guid? SessionId { get; set; }

        [Required(ErrorMessage = "The pageviewed is required")]
        public string PageViewed { get; set; } = string.Empty;

        [Required(ErrorMessage = "The timestamp is required")]
        public string TimeStamp { get; set; } = string.Empty;

        [Required(ErrorMessage = "The devicetype is required")]
        public string DeviceType { get; set; } = string.Empty;

        [Required(ErrorMessage = "The browser is required")]
        public string Browser { get; set; } = string.Empty;
        public string ReferrerUrl { get; set; } = string.Empty;
    }
}