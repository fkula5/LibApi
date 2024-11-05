using LibApi.Entities;
using LibApi.Enums;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Seeder;

public class ReservationSeeder(LibDbContext context)
{
    public void SeedReservations()
    {
        context.Database.Migrate();
        if (context.Reservations.Any()) return;
        var members = context.Members.ToList();
        var books = context.Books.ToList();
        IEnumerable<Reservation> reservations = new List<Reservation>
        {
            new()
            {
                MemberId = members.First(m => m.LastName == "Smith").Id,
                BookId = books.First(b => b.Title == "1984").Id,
                ReservationDate = DateTime.UtcNow.AddDays(-5),
                Status = ReservationStatus.Active
            },
            new()
            {
                MemberId = members.First(m => m.LastName == "Johnson").Id,
                BookId = books.First(b => b.Title == "Pride and Prejudice").Id,
                ReservationDate = DateTime.UtcNow.AddDays(-10),
                Status = ReservationStatus.Fulfilled
            },
            new()
            {
                MemberId = members.First(m => m.LastName == "Williams").Id,
                BookId = books.First(b => b.Title == "Crime and Punishment").Id,
                ReservationDate = DateTime.UtcNow.AddDays(-3),
                Status = ReservationStatus.Cancelled
            }
        };

        context.Reservations.AddRange(reservations);
        context.SaveChanges();
    }
}