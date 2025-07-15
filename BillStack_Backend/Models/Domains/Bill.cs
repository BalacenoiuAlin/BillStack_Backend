using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillStack_Backend.Models.Domains
{
    public class Bill
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string BillType {  get; set; } // House, Subscription, Car

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } // Netflix-Subscription, Apartment - House, BMW - Car

        public string? ImageUrl { get; set; } // imagine

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Type { get; set; } // Bill, Payment, Rent, Repairs

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Info { get; set; } // Small info detail

        [Required]
        [StringLength(1000, MinimumLength = 3)]
        public string Description { get; set; } // Description of the payment or whatever it is 

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; } // Price of the action

        [Required]
        public DateTime DueDate { get; set; } // DueDate until when it should be done

        [Required]
        public bool IsPaid { get; set; } = false; // Wheter is paid or not

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Created at now.time()

        [Required]
        public DateTime UpdatedAt { get; set; } // Updated when IsPaid becomes true

        [Required]
        public Guid UserId { get; set; } // GetUserId for linking with users table via FK 

        //[ForeignKey("UserId")]
        //public Users User { get; set; }
    }
}
