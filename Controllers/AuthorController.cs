using LibApi.Entities;
using LibApi.Models;
using LibApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Author>> GetAll()
    {
        var authors = authorService.GetAll();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public ActionResult<Author> GetAuthorById([FromRoute] int id)
    {
        return Ok(authorService.GetById(id));
    }

    [HttpPost]
    public ActionResult CreateAuthor([FromBody] CreateAuthorDto auhtorDto)
    {
        var id = authorService.Create(auhtorDto);
        return Created($"/api/author/{id}", id);
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromRoute] int id, [FromBody] UpdateAuthorDto auhtorDto)
    {
        authorService.Update(id, auhtorDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        authorService.Delete(id);
        return NoContent();
    }
}