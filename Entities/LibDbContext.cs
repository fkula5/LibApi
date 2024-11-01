using Microsoft.EntityFrameworkCore;

namespace LibApi.Entities;

public class LibDbContext: DbContext
{
    public LibDbContext(DbContextOptions<LibDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>();
        modelBuilder.Entity<Author>();
        modelBuilder.Entity<Genre>();
        modelBuilder.Entity<BookGenres>().HasNoKey();
        modelBuilder.Entity<BookPublishers>().HasNoKey();
        modelBuilder.Entity<BorrowRecord>();
        modelBuilder.Entity<Member>();
        modelBuilder.Entity<Publisher>();
        modelBuilder.Entity<Reservation>();
    }
}