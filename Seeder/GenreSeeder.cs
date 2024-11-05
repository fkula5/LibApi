using LibApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class GenreSeeder(LibDbContext context)
{
    public void SeedGenres()
    {
        context.Database.Migrate();
        if (context.Genres.Any()) return;
        IList<Genre> genres = new List<Genre>
        {
            new() { Name = "Science Fiction" },
            new() { Name = "Classic" },
            new() { Name = "Adventure" },
            new() { Name = "Philosophy" }
        };

        context.Genres.AddRange(genres);
        context.SaveChanges();
    }
}