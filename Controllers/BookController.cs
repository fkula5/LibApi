using Microsoft.AspNetCore.Mvc;

namespace LibApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public ActionResult Get([FromRoute] int id)
    {
        return Ok("book");
    }
}