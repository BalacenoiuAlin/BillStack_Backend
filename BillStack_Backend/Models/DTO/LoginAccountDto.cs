using System.ComponentModel.DataAnnotations;

namespace BillStack_Backend.Models.DTO
{
    public class LoginAccountDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }
    }
}
