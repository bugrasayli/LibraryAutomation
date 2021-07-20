using Library.Domain.DTO.Kind;
using Library.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}/book")]
        public async Task<IActionResult> GetBookByKind(int id)
        {
            var result = await _kind.GetBookByKind(new KindRequest { ID = id});
            return Ok(result);

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _kind.Get();
            return Ok(result);
        }

        [HttpGet("{id}",Name ="GetKindByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _kind.Get(new KindRequest { ID = id});
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddKindRequest kind)
        {
            var result = await _kind.Add(kind);
            return CreatedAtRoute("GetKindByID", new { id =result.ID},result);
            //return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] EditKindRequest kind)
        {
            kind.ID = id;
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
