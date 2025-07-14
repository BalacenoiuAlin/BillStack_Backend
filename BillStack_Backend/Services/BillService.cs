using AutoMapper;
using BillStack_Backend.Models.Domains;
using BillStack_Backend.Models.DTO;
using BillStack_Backend.Repositories;

namespace BillStack_Backend.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository billRepository;
        private readonly IMapper mapper;

        public BillService(IBillRepository billRepository, IMapper mapper)
        {
            this.billRepository = billRepository;
            this.mapper = mapper;
        }
        public async Task<ObtainBillDto> CreateBillAsync(CreateBillDto createBillDto)
        {
            // Map dto to domain model
            var billDomainModel = mapper.Map<Bill>(createBillDto);

            await billRepository.CreateBillAsync(billDomainModel);

            // Map domain model to dto for client
            var billDto = mapper.Map<ObtainBillDto>(billDomainModel);

            return billDto;
            
        }

        public async Task<List<ObtainBillDto>> GetAllBillsAsync()
        {
            var bills = await billRepository.GetAllBillAsync();

            // Map domain model to dto for client
            var billsDto = mapper.Map<List<ObtainBillDto>>(bills);

            return billsDto;
        }

        public async Task<ObtainBillDto?> GetBillByIdAsync(Guid id)
        {
            var bill = await billRepository.GetBillByIdAsync(id);

            if (bill == null)
                return null;

            // Map domain model to dto
            var billDto = mapper.Map<ObtainBillDto>(bill);

            return billDto;
        }

        public async Task<ObtainBillDto?> UpdateBillByIdAsync(Guid id, UpdateBillDto updateBillDto)
        {
            // Map dto to domain model
            var bill = mapper.Map<Bill>(updateBillDto);

            var updatedBill = await billRepository.UpdateBillByIdAsync(id, bill);

            if (updatedBill == null)
                return null;

            // Map domain model back to dto for client
            var billDto = mapper.Map<ObtainBillDto>(updatedBill);

            return billDto;
        }

        public async Task<ObtainBillDto?> UpdateBillStatusByIdAsync(Guid id, UpdateBillStateDto updateBillStateDto)
        {
            // Map Dto to domain model
            var bill = mapper.Map<Bill>(updateBillStateDto);

            var updatedBill = await billRepository.UpdateBillStateByIdAsync(id, bill);

            if (updatedBill == null)
                return null;

            // Map domain model back to dto for client
            var billDto = mapper.Map<ObtainBillDto>(updatedBill);

            return billDto;
        }

        public async Task<ObtainBillDto?> DeleteBillByIdAsync(Guid id)
        {
            var bill = await billRepository.DeleteBillByIdAsync(id);

            if (bill == null)
                return null;

            // Map domain to dto
            var billDto = mapper.Map<ObtainBillDto>(bill);

            return billDto;
        }
    }
}
