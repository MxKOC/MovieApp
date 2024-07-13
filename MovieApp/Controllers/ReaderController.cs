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
    [Route("api/readers")]
    public class ReaderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReaderServices _readerServices;

        public ReaderController(IReaderServices readerServices, IMapper mapper)
        {
            _readerServices = readerServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReaderDto>>> GetAllReaders()
        {
            var readers = await _readerServices.GetAllReadersAsync();
            var readerDtos = _mapper.Map<List<ReaderDto>>(readers);
            return Ok(readerDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReaderDto>> GetReaderById(string id)
        {
            var reader = await _readerServices.GetReaderByIdAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            var readerDto = _mapper.Map<ReaderDto>(reader);
            return Ok(readerDto);
        }


        [HttpPost]
        public async Task<ActionResult<ReaderDto>> CreateReader(ReaderCreateDto readerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reader = _mapper.Map<Reader>(readerDto);
            var readerId = await _readerServices.CreateReaderAsync(reader);
            if (readerId == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create reader");
            }

            var createdReader = await _readerServices.GetReaderByIdAsync(reader.Id);
            var createdReaderDto = _mapper.Map<ReaderDto>(createdReader);
            return CreatedAtAction(nameof(GetReaderById), new { id = reader.Id }, createdReaderDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReaderDto>> UpdateReader(string id, ReaderCreateDto readerDto)
        {
            var reader = _mapper.Map<Reader>(readerDto);

            if (id != reader.Id)
            {
                return BadRequest("Reader ID mismatch");
            }

            var result = await _readerServices.UpdateReaderAsync(id, reader);
            if (!result)
            {
                return NotFound();
            }

            var updatedReader = await _readerServices.GetReaderByIdAsync(id);
            var updatedReaderDto = _mapper.Map<ReaderDto>(updatedReader);
            return Ok(updatedReaderDto);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReader(string id)
        {
            var result = await _readerServices.DeleteReaderAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}