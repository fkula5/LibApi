namespace LibApi.Entities;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<BookGenres> BookGenres { get; set; }
}