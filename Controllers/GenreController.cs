using LibApi.Entities;
using LibApi.Models;
using LibApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenreController(IGenreService genreService) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Genre>> GetAll()
    {
        var genres = genreService.GetAll();
        return Ok(genres);
    }

    [HttpPost]
    public ActionResult<Genre> CreateGenre([FromBody] CreateGenreDto genreDto)
    {
        var id = genreService.CreateGenre(genreDto);
        return Created($"/api/genres/{id}", id);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        genreService.Delete(id);
        return NoContent();
    }
}