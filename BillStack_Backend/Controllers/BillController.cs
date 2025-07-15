using BillStack_Backend.Models.DTO;
using BillStack_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillStack_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //https:localhost:xxx/api/Bill
    public class BillController : ControllerBase
    {
        private readonly IBillService billService;

        public BillController(IBillService billService)
        {
            this.billService = billService;
        }

        // POST: api/Bill
        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] CreateBillDto createBillDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var billDto = await billService.CreateBillAsync(createBillDto);
            return Ok(billDto);
        }

        // GET: api/Bill
        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            var bills = await billService.GetAllBillsAsync();
            return Ok(bills);
        }

        // GET: api/Bill/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBillById([FromRoute] Guid id)
        {
            var bill = await billService.GetBillByIdAsync(id);
            if (bill == null)
                return NotFound();

            return Ok(bill);
        }

        // PUT: api/Bill/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBillById([FromRoute] Guid id, [FromBody] UpdateBillDto updateBillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedBill = await billService.UpdateBillByIdAsync(id, updateBillDto);
            if (updatedBill == null)
                return NotFound();

            return Ok(updatedBill);
        }

        // PATCH: api/Bill/{id}
        [HttpPatch]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBillStatusById([FromRoute] Guid id, [FromBody] UpdateBillStateDto updateBillStateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedBill = await billService.UpdateBillStatusByIdAsync(id, updateBillStateDto);
            if (updatedBill == null)
                return NotFound();

            return Ok(updatedBill);
        }

        // DELETE: api/Bill/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBillById([FromRoute] Guid id)
        {
            var deletedBill = await billService.DeleteBillByIdAsync(id);
            if (deletedBill == null)
                return NotFound();

            return Ok(deletedBill);
        }
    }
}
