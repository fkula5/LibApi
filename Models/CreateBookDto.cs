namespace LibApi.Models;

public class CreateBookDto
{
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Language { get; set; }
    public string ISBN { get; set; }
    public int AuthorId { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public List<int> GenreIds { get; set; }
    public List<int> PublisherIds { get; set; }
}