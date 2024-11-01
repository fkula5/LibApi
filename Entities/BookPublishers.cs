namespace LibApi.Entities;

public class BookPublishers
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
}