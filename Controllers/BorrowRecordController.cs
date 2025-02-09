using LibApi.Models;
using LibApi.Services;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace LibApi.Controllers;

[ApiController]
[Route("api/borrow-records")]
public class BorrowRecordController(IBorrowRecordService borrowRecordService) : ControllerBase
{
    [HttpPost]
    public ActionResult<int> CreateBorrowRecord([FromBody] CreateBorrowRecordDto dto)
    {
        try
        {
            var id = borrowRecordService.Create(dto);
            return Ok(id);
        }
        catch (PostgresException ex) when (ex.MessageText.Contains("No available copies"))
        {
            return BadRequest("No available copies for the requested book");
        }
    }
}