using BillStack_Backend.Models.Domains;

namespace BillStack_Backend.Repositories
{
    public interface IBillRepository
    {
        Task <Bill> CreateBillAsync(Bill bill);
        Task <List<Bill>> GetAllBillAsync();
        Task <Bill> GetBillByIdAsync(Guid id);
        Task<Bill> UpdateBillByIdAsync(Guid id, Bill bill);
        Task<Bill> UpdateBillStateByIdAsync(Guid id, Bill bill);
        Task<Bill> DeleteBillByIdAsync(Guid id);
    }
}
