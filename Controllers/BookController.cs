using LibApi.Models;
using LibApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<BookDto>> GetAll()
    {
        var booksDtos = bookService.GetAll();
        return Ok(booksDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<BookDto> GetBookById([FromRoute] int id)
    {
        return Ok(bookService.GetById(id));
    }

    [HttpPost]
    public ActionResult CreateBook([FromBody] CreateBookDto bookDto)
    {
        var id = bookService.Create(bookDto);
        return Created($"/api/books/{id}", null);
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromRoute] int id, [FromBody] UpdateBookDto bookDto)
    {
        bookService.Update(id, bookDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        bookService.Delete(id);
        return NoContent();
    }
}