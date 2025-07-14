using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillStack_Backend.Models.Domains
{
    public enum Role
    {
        User,
        Admin
    }

    public class Users
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Role Role { get; set; } = Role.User;

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
        // Navigare
        public ICollection<Bill> Bills { get; set; }
    }
}
