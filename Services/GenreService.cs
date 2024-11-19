using AutoMapper;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;

namespace LibApi.Services;

public interface IGenreService
{
    List<GenreDto> GetAll();
    int CreateGenre(CreateGenreDto dto);
    void Delete(int id);
}

public class GenreService(LibDbContext context, IMapper mapper) : IGenreService
{
    public List<GenreDto> GetAll()
    {
        var genres = mapper.Map<List<GenreDto>>(context.Genres.ToList());
        return genres;
    }

    public int CreateGenre(CreateGenreDto dto)
    {
        var genre = new Genre { Name = dto.Name };

        context.Genres.Add(genre);
        context.SaveChanges();

        return genre.Id;
    }

    public void Delete(int id)
    {
        var genre = context.Genres.Find(id);

        if (genre is null)
            throw new NotFoundException("Genre not found");

        context.Genres.Remove(genre);
        context.SaveChanges();
    }
}