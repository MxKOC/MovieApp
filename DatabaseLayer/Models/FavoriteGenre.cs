using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLayer.IdentityModels;

namespace DatabaseLayer.Models
{
public class FavoriteGenre
{
    public int FavoriteGenreId { get; set; }
    public string ReaderId { get; set; }
    public Reader Reader { get; set; }

    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
}