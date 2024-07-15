using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DTOs.ArticleDto;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class ArticleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArticleServices _articleServices;

        public ArticleController(IArticleServices articleServices, IMapper mapper)
        {
            _articleServices = articleServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArticleDto>>> GetAllArticles()
        {
            var articles = await _articleServices.GetAllArticlesAsync();
            var articlesDtos = _mapper.Map<List<ArticleDto>>(articles);
            return Ok(articlesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetArticleById([FromRoute] string id)
        {
            var article = await _articleServices.GetArticleByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ArticleDto>(article));
        }

        [HttpPost]
        public async Task<ActionResult<ArticleDto>> CreateArticle([FromBody] ArticleCreateDto articleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var DomainArticle = _mapper.Map<Article>(articleDto);
            var artcileId = await _articleServices.CreateArticleAsync(DomainArticle);
            if (artcileId == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create article");
            }

            var EntityDto = _mapper.Map<ArticleDto>(DomainArticle);
            // Assuming Id is set after creation, retrieve the created article

            return CreatedAtAction(nameof(GetArticleById), new { id = EntityDto.ArticleId }, EntityDto);
        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<ArticleDto>> UpdateArticle([FromRoute] string Id, [FromBody] ArticleCreateDto articleDto)
        {

            var DomainArticle = _mapper.Map<Article>(articleDto);



            var updatedArticle = await _articleServices.UpdateArticleAsync(Id, DomainArticle);
            if (updatedArticle == null)
            {
                return NotFound();
            }
            var EntityDto = _mapper.Map<ArticleDto>(updatedArticle);

            return CreatedAtAction(nameof(GetArticleById), new { id = EntityDto.ArticleId }, EntityDto);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle([FromRoute] string id)
        {
            var result = await _articleServices.DeleteArticleAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }

}