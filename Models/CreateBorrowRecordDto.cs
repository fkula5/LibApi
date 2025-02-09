namespace LibApi.Models;

public class CreateBorrowRecordDto
{
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
}