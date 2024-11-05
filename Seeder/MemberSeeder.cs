using LibApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class MemberSeeder(LibDbContext context)
{
    public void SeedMembers()
    {
        context.Database.Migrate();
        if (context.Members.Any()) return;
        IEnumerable<Member> members = new List<Member>
        {
            new()
            {
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice.smith@example.com",
                PhoneNumber = "+1-555-0101",
                Address = "123 Main St, Springfield, USA",
                MembershipDate = DateTime.UtcNow.AddYears(-2)
            },
            new()
            {
                FirstName = "Bob",
                LastName = "Johnson",
                Email = "bob.johnson@example.com",
                PhoneNumber = "+1-555-0102",
                Address = "456 Elm St, Springfield, USA",
                MembershipDate = DateTime.UtcNow.AddYears(-1).AddMonths(-3)
            },
            new()
            {
                FirstName = "Carol",
                LastName = "Williams",
                Email = "carol.williams@example.com",
                PhoneNumber = "+1-555-0103",
                Address = "789 Oak St, Springfield, USA",
                MembershipDate = DateTime.UtcNow.AddMonths(-10)
            },
            new()
            {
                FirstName = "David",
                LastName = "Brown",
                Email = "david.brown@example.com",
                PhoneNumber = "+1-555-0104",
                Address = "321 Maple Ave, Springfield, USA",
                MembershipDate = DateTime.UtcNow.AddMonths(-6)
            }
        };

        context.Members.AddRange(members);
        context.SaveChanges();
    }
}