﻿// <auto-generated />
using System;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ArticlesContext))]
    [Migration("20240711074857_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("ArticleGenre", b =>
                {
                    b.Property<int>("ArticlesArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenresGenreId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArticlesArticleId", "GenresGenreId");

                    b.HasIndex("GenresGenreId");

                    b.ToTable("ArticleGenre");
                });

            modelBuilder.Entity("ArticleKeyword", b =>
                {
                    b.Property<int>("ArticlesArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("KeywordsKeywordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArticlesArticleId", "KeywordsKeywordId");

                    b.HasIndex("KeywordsKeywordId");

                    b.ToTable("ArticleKeyword");
                });

            modelBuilder.Entity("ArticleLanguage", b =>
                {
                    b.Property<int>("ArticlesArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LanguagesLanguageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArticlesArticleId", "LanguagesLanguageId");

                    b.HasIndex("LanguagesLanguageId");

                    b.ToTable("ArticleLanguage");
                });

            modelBuilder.Entity("DatabaseLayer.IdentityModels.Reader", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("JoinTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<int>("MyProperty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReaderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reader");
                });

            modelBuilder.Entity("DatabaseLayer.IdentityModels.Writer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("JoinTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebPage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Writer");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Overview")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Popularity")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Revenue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<double?>("VoteAverage")
                        .HasColumnType("REAL");

                    b.Property<int?>("VoteCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WordNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WriterId")
                        .HasColumnType("TEXT");

                    b.HasKey("ArticleId");

                    b.HasIndex("WriterId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReaderId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReaderId1")
                        .HasColumnType("TEXT");

                    b.HasKey("CommentId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("GenreId");

                    b.HasIndex("ReaderId");

                    b.HasIndex("ReaderId1");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DatabaseLayer.Models.FavoriteArticle", b =>
                {
                    b.Property<string>("ReaderId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FavoriteArticleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReaderId1")
                        .HasColumnType("TEXT");

                    b.Property<string>("WriterId")
                        .HasColumnType("TEXT");

                    b.HasKey("ReaderId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("ReaderId1");

                    b.HasIndex("WriterId");

                    b.ToTable("FavoriteArticles");
                });

            modelBuilder.Entity("DatabaseLayer.Models.FavoriteGenre", b =>
                {
                    b.Property<int>("FavoriteGenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReaderId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FavoriteGenreId");

                    b.HasIndex("GenreId");

                    b.HasIndex("ReaderId");

                    b.ToTable("FavoriteGenres");
                });

            modelBuilder.Entity("DatabaseLayer.Models.FollowedWriter", b =>
                {
                    b.Property<int>("FollowedWriterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReaderId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WriterId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("FollowedWriterId");

                    b.HasIndex("ReaderId");

                    b.HasIndex("WriterId");

                    b.ToTable("FollowedWriters");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GenreName")
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Keyword", b =>
                {
                    b.Property<int>("KeywordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("KeywordName")
                        .HasColumnType("TEXT");

                    b.HasKey("KeywordId");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("LanguageName")
                        .HasColumnType("TEXT");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("ArticleGenre", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArticleKeyword", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.Models.Keyword", null)
                        .WithMany()
                        .HasForeignKey("KeywordsKeywordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArticleLanguage", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("ArticlesArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseLayer.Models.Article", b =>
                {
                    b.HasOne("DatabaseLayer.IdentityModels.Writer", null)
                        .WithMany("Articles")
                        .HasForeignKey("WriterId");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Comment", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.Models.Genre", null)
                        .WithMany("FavoriteGenres")
                        .HasForeignKey("GenreId");

                    b.HasOne("DatabaseLayer.IdentityModels.Reader", "Reader")
                        .WithMany("Comments")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.IdentityModels.Reader", null)
                        .WithMany("FavoriteGenres")
                        .HasForeignKey("ReaderId1");

                    b.Navigation("Article");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("DatabaseLayer.Models.FavoriteArticle", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Article", "Article")
                        .WithMany("FavoriteArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.IdentityModels.Reader", "Reader")
                        .WithMany("FavoriteArticles")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.IdentityModels.Reader", null)
                        .WithMany("FollowedWriters")
                        .HasForeignKey("ReaderId1");

                    b.HasOne("DatabaseLayer.IdentityModels.Writer", null)
                        .WithMany("FollowedWriters")
                        .HasForeignKey("WriterId");

                    b.Navigation("Article");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("DatabaseLayer.Models.FavoriteGenre", b =>
                {
                    b.HasOne("DatabaseLayer.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.IdentityModels.Reader", "Reader")
                        .WithMany()
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("DatabaseLayer.Models.FollowedWriter", b =>
                {
                    b.HasOne("DatabaseLayer.IdentityModels.Reader", "Reader")
                        .WithMany()
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayer.IdentityModels.Writer", "Writer")
                        .WithMany()
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reader");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("DatabaseLayer.IdentityModels.Reader", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FavoriteArticles");

                    b.Navigation("FavoriteGenres");

                    b.Navigation("FollowedWriters");
                });

            modelBuilder.Entity("DatabaseLayer.IdentityModels.Writer", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("FollowedWriters");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Article", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FavoriteArticles");
                });

            modelBuilder.Entity("DatabaseLayer.Models.Genre", b =>
                {
                    b.Navigation("FavoriteGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
