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
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Reader)
            .WithMany(r => r.Comments) // Many comments can be associated with one reader
            .HasForeignKey(c => c.ReaderId)
            .OnDelete(DeleteBehavior.Restrict); // If needed, configure delete behavior

        // Configure other relationships as needed

        // Optionally, if you want to ignore some properties:
        // modelBuilder.Entity<Comment>().Ignore(c => c.SomeProperty);

        // Configure Article-Comment relationship
        modelBuilder.Entity<Article>()
            .HasMany(a => a.Comments)
            .WithOne(c => c.Article)
            .HasForeignKey(c => c.ArticleId)
            .OnDelete(DeleteBehavior.Cascade); // If deleting an article, delete all associated comments

        modelBuilder.Entity<FavoriteArticle>()
            .HasKey(fa => new { fa.ReaderId, fa.ArticleId });

        modelBuilder.Entity<FavoriteArticle>()
            .HasOne(fa => fa.Reader)
            .WithMany(r => r.FavoriteArticles) // A reader can have many favorite articles
            .HasForeignKey(fa => fa.ReaderId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if a reader is deleted

        modelBuilder.Entity<FavoriteArticle>()
            .HasOne(fa => fa.Article)
            .WithMany(a => a.FavoriteArticles) // An article can be favorited by many readers
            .HasForeignKey(fa => fa.ArticleId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete if an article is deleted

    }
}
