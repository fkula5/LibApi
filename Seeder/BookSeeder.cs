using LibApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class BookSeeder(LibDbContext context)
{
    public void SeedBooks()
    {
        context.Database.Migrate();
        if (context.Books.Any()) return;
        var authors = context.Authors.ToList();
        IEnumerable<Book> books = new List<Book>
        {
            new()
            {
                Title = "1984", PublicationDate = new DateTime(1949, 6, 8, 0, 0, 0, DateTimeKind.Utc),
                Language = "English", ISBN = "1234567890",
                AuthorId = authors.First(a => a.LastName == "Orwell").Id, TotalCopies = 5, AvailableCopies = 5
            },
            new()
            {
                Title = "Pride and Prejudice", PublicationDate = new DateTime(1813, 1, 28, 0, 0, 0, DateTimeKind.Utc),
                Language = "English",
                ISBN = "0987654321", AuthorId = authors.First(a => a.LastName == "Austen").Id, TotalCopies = 4,
                AvailableCopies = 4
            },
            new()
            {
                Title = "Adventures of Huckleberry Finn",
                PublicationDate = new DateTime(1884, 12, 10, 0, 0, 0, DateTimeKind.Utc),
                Language = "English", ISBN = "1122334455", AuthorId = authors.First(a => a.LastName == "Twain").Id,
                TotalCopies = 6, AvailableCopies = 6
            },
            new()
            {
                Title = "Crime and Punishment", PublicationDate = new DateTime(1866, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Language = "Russian",
                ISBN = "6677889900", AuthorId = authors.First(a => a.LastName == "Dostoevsky").Id, TotalCopies = 3,
                AvailableCopies = 3
            }
        };

        context.Books.AddRange(books);
        context.SaveChanges();
    }
}