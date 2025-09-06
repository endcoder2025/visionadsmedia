using System.ComponentModel.DataAnnotations;

namespace visionadsmedia.DTOs
{
    public class ContactCreateDto
    {
        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Phone, StringLength(20)]
        public string? Phone { get; set; }

        [Required, StringLength(2000)]
        public string Message { get; set; } = string.Empty;
    }
}
