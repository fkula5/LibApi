using LibApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class PublisherSeeder(LibDbContext context)
{
    public void SeedPublishers()
    {
        context.Database.Migrate();
        if (context.Publishers.Any()) return;
        IEnumerable<Publisher> publishers = new List<Publisher>
        {
            new()
            {
                Name = "Penguin Books", Address = "London, UK", PhoneNumber = "+44 20 1234 5678",
                Email = "contact@penguinbooks.com"
            },
            new()
            {
                Name = "HarperCollins", Address = "New York, USA", PhoneNumber = "+1 212-207-7000",
                Email = "info@harpercollins.com"
            },
            new()
            {
                Name = "Vintage Books", Address = "London, UK", PhoneNumber = "+44 20 8765 4321",
                Email = "support@vintagebooks.com"
            }
        };

        context.Publishers.AddRange(publishers);
        context.SaveChanges();
    }
}