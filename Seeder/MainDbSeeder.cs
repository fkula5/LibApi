namespace LibApi.Seeder;

public class MainDbSeeder(
    AuthorSeeder authorSeeder,
    GenreSeeder genreSeeder,
    PublisherSeeder publisherSeeder,
    BookSeeder bookSeeder,
    BookPublishersSeeder bookPublishersSeeder,
    BookGenresSeeder bookGenresSeeder,
    ReservationSeeder reservationSeeder,
    BorrowRecordsSeeder borrowRecordsSeeder,
    MemberSeeder memberSeeder
)
{
    public void Seed()
    {
        authorSeeder.SeedAuthors();
        genreSeeder.SeedGenres();
        publisherSeeder.SeedPublishers();
        bookSeeder.SeedBooks();
        memberSeeder.SeedMembers();
        bookPublishersSeeder.SeedBookPublishers();
        bookGenresSeeder.SeedBookGenres();
        reservationSeeder.SeedReservations();
        borrowRecordsSeeder.SeedBorrowRecords();
    }
}