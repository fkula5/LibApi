﻿namespace LibApi.Models;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Language { get; set; }
    public string ISBN { get; set; }
    public AuthorDto Author { get; set; }
    public int TotalCopies { get; set; }
    public int AvailableCopies { get; set; }
    public List<PublisherDto> Publishers { get; set; }
    public List<GenreDto> Genres { get; set; }
}