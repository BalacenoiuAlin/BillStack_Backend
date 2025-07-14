using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillStack_Backend.Models.Domains
{
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string BillType {  get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Info { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public bool IsPaid { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }
    }
}
