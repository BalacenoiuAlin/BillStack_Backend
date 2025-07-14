namespace BillStack_Backend.Models.DTO
{
    public class ObtainBillDto
    {
        public Guid Id { get; set; }

        public string BillType { get; set; }

        public string Name { get; set; }

        public string? ImageUrl { get; set; }

        public string Type { get; set; }

        public string Info { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UserId { get; set; }
    }
}
