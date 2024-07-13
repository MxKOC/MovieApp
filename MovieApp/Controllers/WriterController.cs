using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services;
using DatabaseLayer.IdentityModels;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DTOs.ArticleDto;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/writers")]
    public class WriterController : ControllerBase
    {
        private readonly IWriterServices _writerServices;
        private readonly IMapper _mapper;

        public WriterController(IWriterServices writerServices, IMapper mapper)
        {
            _writerServices = writerServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<WriterDto>>> GetAllWriters()
        {
            var writers = await _writerServices.GetAllWritersAsync();
            var writerDtos = _mapper.Map<List<WriterDto>>(writers);
            return Ok(writerDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WriterDto>> GetWriterById(string id)
        {
            var writer = await _writerServices.GetWriterByIdAsync(id);
            if (writer == null)
            {
                return NotFound();
            }
            var writerDto = _mapper.Map<WriterDto>(writer);
            return Ok(writerDto);
        }

        [HttpPost]
        public async Task<ActionResult<WriterDto>> CreateWriter(WriterCreateDto writerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var writer = _mapper.Map<Writer>(writerDto);
            var writerId = await _writerServices.CreateWriterAsync(writer);
            if (writerId == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create writer");
            }

            var createdWriter = await _writerServices.GetWriterByIdAsync(writer.Id);
            var createdWriterDto = _mapper.Map<WriterDto>(createdWriter);
            return CreatedAtAction(nameof(GetWriterById), new { id = writer.Id }, createdWriterDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WriterDto>> UpdateWriter(string id, WriterCreateDto writerDto)
        {

            var writer = _mapper.Map<Writer>(writerDto);

            if (id != writer.Id)
            {
                return BadRequest("Writer ID mismatch");
            }

            var result = await _writerServices.UpdateWriterAsync(id, writer);
            if (!result)
            {
                return NotFound();
            }

            var updatedWriter = await _writerServices.GetWriterByIdAsync(id);
            var updatedWriterDto = _mapper.Map<WriterDto>(updatedWriter);
            return Ok(updatedWriterDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWriter(string id)
        {
            var result = await _writerServices.DeleteWriterAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}