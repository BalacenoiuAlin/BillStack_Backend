using AutoMapper;
using BillStack_Backend.Models.Domains;
using BillStack_Backend.Models.DTO;
using BillStack_Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillStack_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api//Bill
    public class BillController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBillRepository billRepository;

        public BillController(IMapper mapper, IBillRepository billRepository)
        {
            this.mapper = mapper;
            this.billRepository = billRepository;
        }

        // Create a new bill
        // POST: https:localhost:7217/api/Bill
        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillDto createBillDto)
        {
            // Map dto to domain, because the client should work only with the dto`s, not entire domains
            var billDomainModel = mapper.Map<Bill>(createBillDto);

            await billRepository.CreateBillAsync(billDomainModel);

            // Map domain to dto again to send it to the client as a response
            var billDto = mapper.Map<ObtainBillDto>(billDomainModel);

            return Ok(billDto);
        }

        // Get all bills
        // GET: https:localhost:7217/api/Bill
        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            // Get bills from db
            var billsDomainModel = await billRepository.GetAllBillAsync();

            // Map domain model to dto for client response
            var billDto = mapper.Map<List<ObtainBillDto>>(billsDomainModel);

            return Ok(billDto);
        }

        // Get bill by id
        // GET: https:localhost:7217/api/Bill/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBillById([FromRoute] Guid id)
        {
            // Find first bill with given id if possible
            var billDomainModel = await billRepository.GetBillByIdAsync(id);

            if (billDomainModel == null)
                return NotFound();

            // Map domain to Dto back to client
            var billDto = mapper.Map<ObtainBillDto>(billDomainModel);

            return Ok(billDto );
        }

        // Update bill by id
        // POST: https:localhost:7217/api/Bill/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBillById([FromRoute]Guid id, UpdateBillDto updateBillDto)
        {
            // Map Dto to domain model to work on it
            var billDomainModel = mapper.Map<Bill>(updateBillDto);

            billDomainModel = await billRepository.UpdateBillByIdAsync(id, billDomainModel);

            if (billDomainModel == null)
                return NotFound();

            // Map domain model back to dto to give it to the client
            var billDto = mapper.Map<ObtainBillDto>(billDomainModel);

            return Ok(billDto);
        }

        // Update bill status and give payment duedate
        // PATCH: https:localhost:7217/api/Bill/{id}
        [HttpPatch]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateBillStatusById([FromRoute] Guid id, UpdateBillStateDto updateBillStateDto)
        {
            // Map Dto to domain model to work on it
            var billDomainModel = mapper.Map<Bill>(updateBillStateDto);

            billDomainModel = await billRepository.UpdateBillStateByIdAsync(id, billDomainModel);

            if (billDomainModel == null)
                return NotFound();

            // Map domain model back to dto for client
            var billDto = mapper.Map<ObtainBillDto>(billDomainModel);

            return Ok(billDto);
        }

        // Delete a bill by id
        // DELETE:https:localhost:7217/api/Bill/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBillById([FromRoute] Guid id)
        {
            var billDomain = await billRepository.DeleteBillByIdAsync(id);

            if (billDomain == null)
                return NotFound();

            // Map domain to dto for client response
            var billDto = mapper.Map<ObtainBillDto>(billDomain);

            return Ok(billDto);
        }
    }
}
