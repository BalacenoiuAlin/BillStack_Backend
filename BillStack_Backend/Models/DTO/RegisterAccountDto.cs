using System.ComponentModel.DataAnnotations;

namespace BillStack_Backend.Models.DTO
{
    public class RegisterAccountDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Role { get; set; }
    }
}
