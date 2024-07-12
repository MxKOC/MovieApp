using System;
using System.Collections.Generic;
using DatabaseLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

public partial class ArticlesContext : DbContext
{
    public ArticlesContext()
    {
    }

    public ArticlesContext(DbContextOptions<ArticlesContext> options)
        : base(options)
    {
    }







    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<FavoriteArticle> FavoriteArticles { get; set; }
    public virtual DbSet<FavoriteGenre> FavoriteGenres { get; set; }
    public virtual DbSet<FollowedWriter> FollowedWriters { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Keyword> Keywords { get; set; }
    public virtual DbSet<Language> Languages { get; set; }
    public virtual DbSet<Article> Articles { get; set; }

}
