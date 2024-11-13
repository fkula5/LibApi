using AutoMapper;
using LibApi.Entities;
using LibApi.Models;

namespace LibApi;

public class LibraryMappingProfile : Profile
{
    public LibraryMappingProfile()
    {
        CreateMap<Book, BookDto>().ForMember(dest => dest.Publishers,
            opt => opt.MapFrom(src => src.BookPublishers.Select(bp => bp.Publisher))).ForMember(dest => dest.Genres,
            opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.Genre)));
        CreateMap<Author, AuthorDto>();
        CreateMap<Publisher, PublisherDto>();
        CreateMap<Genre, GenreDto>();
    }
}