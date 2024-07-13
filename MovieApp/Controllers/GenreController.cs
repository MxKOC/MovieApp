using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    [ApiController]
[Route("api/genres")]
public class GenreController : ControllerBase
{
    private readonly IGenreServices _genreServices;

    public GenreController(IGenreServices genreServices)
    {
        _genreServices = genreServices;
    }

    [HttpGet]
    public async Task<ActionResult<List<Genre>>> GetAllGenres()
    {
        var genres = await _genreServices.GetAllGenresAsync();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> GetGenreById(string id)
    {
        var genre = await _genreServices.GetGenreByIdAsync(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public async Task<ActionResult<Genre>> CreateGenre(Genre genre)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var genreId = await _genreServices.CreateGenreAsync(genre);
        if (genreId==null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create genre");
        }

        // Assuming Id is set after creation, retrieve the created genre
        var createdGenre = await _genreServices.GetGenreByIdAsync(genre.GenreId);
        return CreatedAtAction(nameof(GetGenreById), new { id = genre.GenreId }, createdGenre);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Genre>> UpdateGenre(string id, Genre genre)
    {
        if (id != genre.GenreId)
        {
            return BadRequest("Genre ID mismatch");
        }

        var result = await _genreServices.UpdateGenreAsync(id, genre);
        if (!result)
        {
            return NotFound();
        }

        // Return the updated genre
        var updatedGenre = await _genreServices.GetGenreByIdAsync(id);
        return Ok(updatedGenre);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGenre(string id)
    {
        var result = await _genreServices.DeleteGenreAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}

}