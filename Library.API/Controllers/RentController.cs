using Library.Domain.DTO.Rent;
using Library.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _service;
        public RentController(IRentService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRentRequest rent)
        {
            var result = await _service.Add(rent);
            return CreatedAtAction(nameof(GetByID), new { id = result.ID }, result);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();
            return Ok(result);
        }
        [HttpGet("{id}", Name = "GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _service.Get(new RentRequestByID { ID = id });
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditRentRequest rent)
        {
            rent.ID = id;
            await _service.Edit(rent);
            return Ok(rent);
        }
        [HttpPut("deliver/{id}")]
        public async Task<IActionResult> Deliver(int id)
        {
            var result =await _service.Deliver(new RentRequestByID { ID =id});
            return Ok(result);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Get(
            [FromQuery]int book,
            [FromQuery]int costumer,
            [FromQuery]string name,
            [FromQuery]bool? isDelivered,
            [FromQuery]bool? isLate)
        {
            var result =await _service.Filter(book,costumer,name,isDelivered,isLate);
            return Ok(result);
        }
    }
}
