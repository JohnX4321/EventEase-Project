using System.ComponentModel.DataAnnotations;

namespace EventEase.Models
{
    public class Registration
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}