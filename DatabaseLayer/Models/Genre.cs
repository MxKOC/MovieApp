using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseLayer.Models;

public class Genre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string GenreId { get; set; }
    public string? GenreName { get; set; }
    public virtual ICollection<Article> Articles { get; set; }
    public virtual ICollection<FavoriteGenre> FavoriteGenres { get; set; }


}
