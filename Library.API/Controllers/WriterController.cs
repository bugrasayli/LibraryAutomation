using Library.Domain.DTO.Writer;
using Library.Domain.Entities;
using Library.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writer;

        public WriterController(IWriterService writer)
        {
            _writer = writer;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _writer.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int ID)
        {
            var result = await _writer.Get(new WriterRequest {ID=ID });
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddWriterRequest writer)
        {
            var result = await _writer.Add(writer);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditWriterRequest writer)
        {
            writer.ID = id;
            var result = await _writer.Edit(writer);
            return Ok(result);
        }
    }
}
