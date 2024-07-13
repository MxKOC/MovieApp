using System;
using System.Collections.Generic;

namespace DatabaseLayer.Models;

public class Article
{
    public string ArticleId { get; set; }
    public bool? IsPublic { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? Overview { get; set; }
    public double? Popularity { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Revenue { get; set; }
    public int WordNumber { get; set; }
    public double? VoteAverage { get; set; }
    public int? VoteCount { get; set; }
    public virtual ICollection<Genre> Genres { get; set; }
    public virtual ICollection<Keyword> Keywords { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Language> Languages { get; set; }
    public virtual ICollection<FavoriteArticle> FavoriteArticles { get; set; }


}
