using AutoMapper;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibApi.Services;

public interface IBookService
{
    int Create(CreateBookDto dto);
    BookDto GetById(int id);
    List<BookDto> GetAll();
    void Delete(int id);
    void Update(int id, UpdateBookDto dto);
}

public class BookService(LibDbContext context, IMapper mapper) : IBookService
{
    public int Create(CreateBookDto dto)
    {
        var author = context.Authors.Find(dto.AuthorId);
        if (author is null)
            throw new NotFoundException("Author not found");

        var genres = context.Genres.Where(g => dto.GenreIds.Contains(g.Id)).ToList();
        if (genres.Count != dto.GenreIds.Count)
            throw new NotFoundException("Genre count mismatch");

        var publishers = context.Publishers.Where(p => dto.PublisherIds.Contains(p.Id)).ToList();
        if (publishers.Count != dto.PublisherIds.Count)
            throw new NotFoundException("Publisher count mismatch");

        var book = new Book
        {
            Title = dto.Title,
            PublicationDate = dto.PublicationDate,
            Language = dto.Language,
            ISBN = dto.ISBN,
            Author = author,
            TotalCopies = dto.TotalCopies,
            AvailableCopies = dto.AvailableCopies,
            BookGenres = genres.Select(g => new BookGenres { Genre = g }).ToList(),
            BookPublishers = publishers.Select(p => new BookPublishers { Publisher = p }).ToList()
        };

        context.Books.Add(book);
        context.SaveChanges();

        return book.Id;
    }

    public BookDto GetById(int id)
    {
        var book = context.Books.Include(b => b.Author)
            .Include(b => b.BookPublishers).ThenInclude(bp => bp.Publisher)
            .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre).FirstOrDefault(b => b.Id == id);

        if (book is null)
            throw new NotFoundException("Book not found");

        return mapper.Map<BookDto>(book);
    }

    public List<BookDto> GetAll()
    {
        var books = context.Books.Include(b => b.Author)
            .Include(b => b.BookPublishers).ThenInclude(bp => bp.Publisher)
            .Include(b => b.BookGenres).ThenInclude(bg => bg.Genre).ToList();

        return mapper.Map<List<BookDto>>(books);
    }

    public void Delete(int id)
    {
        var book = context.Books.FirstOrDefault(b => b.Id == id);

        if (book is null)
            throw new NotFoundException("Book not found");

        context.Books.Remove(book);
        context.SaveChanges();
    }

    public void Update(int id, UpdateBookDto dto)
    {
        var book = context.Books
            .Include(b => b.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .Include(b => b.BookPublishers)
            .ThenInclude(bp => bp.Publisher)
            .FirstOrDefault(b => b.Id == id);

        if (book is null)
            throw new NotFoundException("Book not found");

        book.Title = dto.Title;
        book.PublicationDate = dto.PublicationDate;
        book.Language = dto.Language;
        book.ISBN = dto.ISBN;
        book.TotalCopies = dto.TotalCopies;
        book.AvailableCopies = dto.AvailableCopies;

        book.BookGenres.Clear();

        var genres = context.Genres.Where(g => dto.GenreIds.Contains(g.Id)).ToList();

        if (genres.Count != dto.GenreIds.Count)
            throw new NotFoundException("Genre count mismatch");

        foreach (var genre in genres) book.BookGenres.Add(new BookGenres { Genre = genre });

        book.BookPublishers.Clear();

        var publishers = context.Publishers.Where(p => dto.PublisherIds.Contains(p.Id)).ToList();

        if (publishers.Count != dto.PublisherIds.Count)
            throw new NotFoundException("Publisher count mismatch");

        foreach (var publisher in publishers) book.BookPublishers.Add(new BookPublishers { Publisher = publisher });

        context.SaveChanges();
    }
}