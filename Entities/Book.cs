namespace LibApi.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Language { get; set; }
    public string ISBN { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public ICollection<BookPublishers> BookPublishers { get; set; }
    public ICollection<BookGenres> BookGenres { get; set; }
}