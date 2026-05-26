using System.ComponentModel.DataAnnotations;

namespace TCS.USER.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120")]
        public int Age { get; set; }

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Pincode must be between 4 and 10 characters")]
        public string Pincode { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Email must be a valid email address")]
        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
