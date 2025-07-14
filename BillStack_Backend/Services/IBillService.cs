using BillStack_Backend.Models.DTO;

namespace BillStack_Backend.Services
{
    public interface IBillService
    {
        Task<ObtainBillDto> CreateBillAsync(CreateBillDto createBillDto);
        Task<List<ObtainBillDto>> GetAllBillsAsync();
        Task<ObtainBillDto?> GetBillByIdAsync(Guid id);
        Task<ObtainBillDto?> UpdateBillByIdAsync(Guid id, UpdateBillDto updateBillDto);
        Task<ObtainBillDto?> UpdateBillStatusByIdAsync(Guid id, UpdateBillStateDto updateBillStateDto);
        Task<ObtainBillDto?> DeleteBillByIdAsync(Guid id);
    }
}
