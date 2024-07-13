using System;
using System.Collections.Generic;

namespace DatabaseLayer.Models;

public class Genre
{
    public string GenreId { get; set; }
    public string? GenreName { get; set; }
    public virtual ICollection<Article> Articles { get; set; }
    public virtual ICollection<FavoriteGenre> FavoriteGenres { get; set; }


}
