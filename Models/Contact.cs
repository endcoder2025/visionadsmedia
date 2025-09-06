using System;
using System.ComponentModel.DataAnnotations;

namespace visionadsmedia.Models
{
    public class Contact
    {
        public int Id { get; set; }   // Primary key

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Phone, StringLength(20)]
        public string? Phone { get; set; }

        [Required, StringLength(1000)]
        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
