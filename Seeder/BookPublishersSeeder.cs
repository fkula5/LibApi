using LibApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class BookPublishersSeeder(LibDbContext context)
{
    public void SeedBookPublishers()
    {
        context.Database.Migrate();
        if (context.BookPublishers.Any()) return;
        var books = context.Books.ToList();
        var publishers = context.Publishers.ToList();
        IEnumerable<BookPublishers> bookPublishers = new List<BookPublishers>
        {
            new()
            {
                BookId = books.First(b => b.Title == "1984").Id,
                PublisherId = publishers.First(p => p.Name == "Penguin Books").Id
            },
            new()
            {
                BookId = books.First(b => b.Title == "Pride and Prejudice").Id,
                PublisherId = publishers.First(p => p.Name == "Vintage Books").Id
            },
            new()
            {
                BookId = books.First(b => b.Title == "Adventures of Huckleberry Finn").Id,
                PublisherId = publishers.First(p => p.Name == "HarperCollins").Id
            },
            new()
            {
                BookId = books.First(b => b.Title == "Crime and Punishment").Id,
                PublisherId = publishers.First(p => p.Name == "Vintage Books").Id
            }
        };

        context.AddRange(bookPublishers);
        context.SaveChanges();
    }
}