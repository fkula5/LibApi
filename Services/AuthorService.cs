using AutoMapper;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;

namespace LibApi.Services;

public interface IAuthorService
{
    int Create(CreateAuthorDto author);
    Author GetById(int id);
    List<Author> GetAll();
    void Delete(int id);
    void Update(int id, UpdateAuthorDto author);
}

public class AuthorService(LibDbContext context, IMapper mapper) : IAuthorService
{
    public Author GetById(int id)
    {
        var author = context.Authors.Find(id);

        if (author is null)
            throw new NotFoundException("Author not found");

        return mapper.Map<Author>(author);
    }

    public List<Author> GetAll()
    {
        var authors = context.Authors.ToList();

        return mapper.Map<List<Author>>(authors);
    }

    public void Delete(int id)
    {
        var author = context.Authors.Find(id);

        if (author is null)
            throw new NotFoundException("Author not found");

        context.Authors.Remove(author);
        context.SaveChanges();
    }

    public void Update(int id, UpdateAuthorDto dto)
    {
        var author = context.Authors.Find(id);

        if (author is null)
            throw new NotFoundException("Author not found");

        author.FirstName = dto.FirstName;
        author.LastName = dto.LastName;
        author.Nationality = dto.Nationality;

        context.SaveChanges();
    }

    public int Create(CreateAuthorDto dto)
    {
        var author = new Author
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Nationality = dto.Nationality
        };

        context.Authors.Add(author);
        context.SaveChanges();

        return author.Id;
    }
}