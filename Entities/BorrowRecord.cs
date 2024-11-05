using LibApi.Enums;

namespace LibApi.Entities;

public class BorrowRecord
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public BorrowStatus Status { get; set; }
}