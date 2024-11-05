using LibApi.Entities;
using LibApi.Enums;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class BorrowRecordsSeeder(LibDbContext context)
{
    public void SeedBorrowRecords()
    {
        context.Database.Migrate();
        if (context.BorrowRecords.Any()) return;
        var members = context.Members.ToList();
        var books = context.Books.ToList();
        ICollection<BorrowRecord> borrowRecords = new List<BorrowRecord>
        {
            new()
            {
                BookId = books.First(b => b.Title == "1984").Id,
                MemberId = members.First(m => m.LastName == "Smith").Id,
                BorrowDate = DateTime.UtcNow.AddDays(-10),
                DueDate = DateTime.UtcNow.AddDays(20),
                ReturnDate = null,
                Status = BorrowStatus.Borrowed
            },
            new()
            {
                BookId = books.First(b => b.Title == "Pride and Prejudice").Id,
                MemberId = members.First(m => m.LastName == "Johnson").Id,
                BorrowDate = DateTime.UtcNow.AddDays(-15),
                DueDate = DateTime.UtcNow.AddDays(15),
                ReturnDate = DateTime.UtcNow.AddDays(-5),
                Status = BorrowStatus.Returned
            },
            new()
            {
                BookId = books.First(b => b.Title == "Adventures of Huckleberry Finn").Id,
                MemberId = members.First(m => m.LastName == "Williams").Id,
                BorrowDate = DateTime.UtcNow.AddDays(-3),
                DueDate = DateTime.UtcNow.AddDays(27),
                ReturnDate = null,
                Status = BorrowStatus.Borrowed
            }
        };

        context.BorrowRecords.AddRange(borrowRecords);
        context.SaveChanges();
    }
}