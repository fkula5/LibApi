using Microsoft.EntityFrameworkCore;

namespace LibApi.Entities;

public class LibDbContext(DbContextOptions<LibDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookGenres> BookGenres { get; set; }
    public DbSet<BookPublishers> BookPublishers { get; set; }
    public DbSet<BorrowRecord> BorrowRecords { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>();
        modelBuilder.Entity<Author>();
        modelBuilder.Entity<Genre>();
        modelBuilder.Entity<BookGenres>();
        modelBuilder.Entity<BookPublishers>();
        modelBuilder.Entity<BorrowRecord>();
        modelBuilder.Entity<Member>();
        modelBuilder.Entity<Publisher>();
        modelBuilder.Entity<Reservation>();

        modelBuilder.Entity<BookPublishers>().HasKey(bp => new { bp.BookId, bp.PublisherId });
        modelBuilder.Entity<BookPublishers>().HasOne(bp => bp.Book).WithMany(b => b.BookPublishers)
            .HasForeignKey(bp => bp.BookId);
        modelBuilder.Entity<BookPublishers>().HasOne(bp => bp.Publisher).WithMany(b => b.BookPublishers)
            .HasForeignKey(bp => bp.PublisherId);

        modelBuilder.Entity<BookGenres>().HasKey(bg => new { bg.BookId, bg.GenreId });
        modelBuilder.Entity<BookGenres>().HasOne(bg => bg.Book).WithMany(b => b.BookGenres)
            .HasForeignKey(bg => bg.BookId);
        modelBuilder.Entity<BookGenres>().HasOne(bg => bg.Genre).WithMany(g => g.BookGenres)
            .HasForeignKey(bg => bg.GenreId);
    }
}