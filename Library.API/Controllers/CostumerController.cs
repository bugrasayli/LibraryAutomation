using Library.Domain.DTO.Costumer;
using Library.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerService _costumer;

        public CostumerController(ICostumerService costumer)
        {
            _costumer = costumer;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _costumer.Get();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _costumer.Get(new CostumerRequest { ID =id});
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCostumerRequest costumer) 
        {
            var result = await _costumer.Add(costumer);
            return CreatedAtAction(nameof(GetByID),new {id =result.ID },result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] EditCostumerRequest costumer)
        {
            costumer.ID = id;
            var result = await _costumer.Edit(costumer);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var result =await _costumer.Delete(new CostumerRequest { ID = id });
            return Ok(result);
        }
    }
}
