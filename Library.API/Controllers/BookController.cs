using Library.Domain.DTO.Book;
using Library.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();
            return Ok(result);
        }
        [HttpGet("{id}", Name = "GetBookByID")]
        public async Task<IActionResult> GetBookByID(int id)
        {
            var result = await _service.Get(new BookRequest { ID = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddBookRequest book)
        {
            var result = await _service.Add(book);
            return CreatedAtRoute(nameof(GetBookByID), new { id = result.ID },result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditBookRequest book)
        {
            book.ID = id;
            var result = await _service.Edit(book);
            return Ok(result);  
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(new BookRequest { ID = id });
            return Ok(result);
        }
    }
}
