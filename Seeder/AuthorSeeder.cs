using LibApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class AuthorSeeder(LibDbContext context)
{
    public void SeedAuthors()
    {
        context.Database.Migrate();
        if (context.Authors.Any()) return;
        IEnumerable<Author> authors = new List<Author>()
        {
            new() { FirstName = "George", LastName = "Orwell", Nationality = "British" },
            new() { FirstName = "Jane", LastName = "Austen", Nationality = "British" },
            new() { FirstName = "Mark", LastName = "Twain", Nationality = "American" },
            new() { FirstName = "Fyodor", LastName = "Dostoevsky", Nationality = "Russian" }

        };
            
        context.Authors.AddRange(authors);
        context.SaveChanges();
    }
}