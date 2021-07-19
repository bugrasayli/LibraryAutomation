using Library.Domain.DTO.Kind;
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
    public class KindController : ControllerBase
    {
        private readonly IKindService _kind;

        public KindController(IKindService kind)
        {
            _kind = kind;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _kind.Get();
            return Ok(result);
        }
        [HttpGet("{id}",Name ="GetByID")]
        public async Task<IActionResult> GetByID(int ID)
        {
            var result = await _kind.Get(new KindRequest { ID = ID});
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddKindRequest kind)
        {
            var result = await _kind.Add(kind);
            return CreatedAtRoute(nameof(GetByID),new { ID =result.ID},result);
        }
        [HttpPut("{ID}")]
        public async Task<IActionResult> Put(int ID,[FromBody] EditKindRequest kind)
        {
            kind.ID = ID;
            var result = await _kind.Edit(kind);
            return Ok(result);
        }
        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            var result = await _kind.Delete(new KindResponse { ID = ID});
            return Ok(result);
        }
    }
}
