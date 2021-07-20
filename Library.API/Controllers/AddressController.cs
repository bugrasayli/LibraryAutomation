using Library.Domain.DTO.Address;
using Library.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();
            return Ok(result);
        }
        [HttpGet("{id}",Name ="GetAddressByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _service.Get(new AddressRequest { ID = id});
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddAddressRequest address)
        {
            var result = await _service.Add(address);
            return CreatedAtRoute("GetAddressByID", new {id = result.ID }, result);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditAddressRequest address)
        {
            address.ID = id;
            var result = await _service.Edit(address);
            return Ok(result);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(new AddressRequest { ID = id});
            return Ok(result);
        }
    }
}
