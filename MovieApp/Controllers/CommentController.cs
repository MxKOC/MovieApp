using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DTOs.CommentDto;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommentServices _commentServices;

        public CommentController(ICommentServices commentServices, IMapper mapper)
        {
            _commentServices = commentServices;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetCommentById([FromRoute] string id)
        {
            var comment = await _commentServices.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommentDto>(comment));
        }



            [HttpGet("reader/{readerId}")]
            public async Task<ActionResult<List<CommentDto>>> GetAllCommentOfReader([FromRoute] string readerId)
            {
                var comments = await _commentServices.GetAllCommentByReaderIdAsync(readerId);
                var commentsDtos = _mapper.Map<List<CommentDto>>(comments);
                return Ok(commentsDtos);
            }



            [HttpPost]
            public async Task<ActionResult<CommentDto>> CreateComment([FromBody] CommentCreateDto commentDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var DomainComment = _mapper.Map<Comment>(commentDto);
                var artcileId = await _commentServices.CreateCommentAsync(DomainComment);
                if (artcileId == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create comment");
                }

                var EntityDto = _mapper.Map<CommentDto>(DomainComment);
                // Assuming Id is set after creation, retrieve the created comment

                return CreatedAtAction(nameof(GetCommentById), new { id = EntityDto.CommentId }, EntityDto);
            }


            [HttpPut("{Id}")]
            public async Task<ActionResult<CommentDto>> UpdateComment([FromRoute] string Id, [FromBody] CommentCreateDto commentDto)
            {

                var DomainComment = _mapper.Map<Comment>(commentDto);



                var updatedComment = await _commentServices.UpdateCommentAsync(Id, DomainComment);
                if (updatedComment == null)
                {
                    return NotFound();
                }
                var EntityDto = _mapper.Map<CommentDto>(updatedComment);

                return CreatedAtAction(nameof(GetCommentById), new { id = EntityDto.CommentId }, EntityDto);

            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteComment([FromRoute] string id)
            {
                var result = await _commentServices.DeleteCommentAsync(id);
                if (!result)
                {
                    return NotFound();
                }

                return Ok();
            }
        }

    }