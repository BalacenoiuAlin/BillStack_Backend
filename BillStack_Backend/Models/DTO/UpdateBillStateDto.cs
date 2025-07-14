using System.ComponentModel.DataAnnotations;

namespace BillStack_Backend.Models.DTO
{
    public class UpdateBillStateDto
    {
        [Required]
        public bool IsPaid { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
