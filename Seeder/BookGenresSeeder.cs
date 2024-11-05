using LibApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class BookGenresSeeder(LibDbContext context)
{
    public void SeedBookGenres()
    {
        context.Database.Migrate();
        if (context.BookGenres.Any()) return;
        var books = context.Books.ToList();
        var genres = context.Genres.ToList();
        IEnumerable<BookGenres> bookGenres = new List<BookGenres>
        {
            new()
            {
                BookId = books.First(b => b.Title == "1984").Id,
                GenreId = genres.First(g => g.Name == "Science Fiction").Id
            },
            new()
            {
                BookId = books.First(b => b.Title == "1984").Id, GenreId = genres.First(g => g.Name == "Philosophy").Id
            },
            new()
            {
                BookId = books.First(b => b.Title == "Pride and Prejudice").Id,
                GenreId = genres.First(g => g.Name == "Classic").Id
            },
            new()
            {
                BookId = books.First(b => b.Title == "Adventures of Huckleberry Finn").Id,
                GenreId = genres.First(g => g.Name == "Adventure").Id
            },
            new()
            {
                BookId = books.First(b => b.Title == "Crime and Punishment").Id,
                GenreId = genres.First(g => g.Name == "Philosophy").Id
            }
        };

        context.AddRange(bookGenres);
        context.SaveChanges();
    }
}