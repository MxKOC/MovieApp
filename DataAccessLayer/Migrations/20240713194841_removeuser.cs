using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class removeuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "TEXT", nullable: false),
                    GenreName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    KeywordId = table.Column<string>(type: "TEXT", nullable: false),
                    KeywordName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.KeywordId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageCode = table.Column<string>(type: "TEXT", nullable: true),
                    LanguageName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    MyProperty = table.Column<int>(type: "INTEGER", nullable: false),
                    JoinTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Writer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JoinTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rate = table.Column<int>(type: "INTEGER", nullable: false),
                    WebPage = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteGenres",
                columns: table => new
                {
                    FavoriteGenreId = table.Column<string>(type: "TEXT", nullable: false),
                    ReaderId = table.Column<string>(type: "TEXT", nullable: false),
                    GenreId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteGenres", x => x.FavoriteGenreId);
                    table.ForeignKey(
                        name: "FK_FavoriteGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteGenres_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<string>(type: "TEXT", nullable: false),
                    IsPublic = table.Column<bool>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    Overview = table.Column<string>(type: "TEXT", nullable: true),
                    Popularity = table.Column<double>(type: "REAL", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Revenue = table.Column<int>(type: "INTEGER", nullable: false),
                    WordNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    VoteAverage = table.Column<double>(type: "REAL", nullable: true),
                    VoteCount = table.Column<int>(type: "INTEGER", nullable: true),
                    WriterId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Articles_Writer_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FollowedWriters",
                columns: table => new
                {
                    FollowedWriterId = table.Column<string>(type: "TEXT", nullable: false),
                    ReaderId = table.Column<string>(type: "TEXT", nullable: false),
                    WriterId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedWriters", x => x.FollowedWriterId);
                    table.ForeignKey(
                        name: "FK_FollowedWriters_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowedWriters_Writer_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleGenre",
                columns: table => new
                {
                    ArticlesArticleId = table.Column<string>(type: "TEXT", nullable: false),
                    GenresGenreId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleGenre", x => new { x.ArticlesArticleId, x.GenresGenreId });
                    table.ForeignKey(
                        name: "FK_ArticleGenre_Articles_ArticlesArticleId",
                        column: x => x.ArticlesArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleGenre_Genres_GenresGenreId",
                        column: x => x.GenresGenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleKeyword",
                columns: table => new
                {
                    ArticlesArticleId = table.Column<string>(type: "TEXT", nullable: false),
                    KeywordsKeywordId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleKeyword", x => new { x.ArticlesArticleId, x.KeywordsKeywordId });
                    table.ForeignKey(
                        name: "FK_ArticleKeyword_Articles_ArticlesArticleId",
                        column: x => x.ArticlesArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleKeyword_Keywords_KeywordsKeywordId",
                        column: x => x.KeywordsKeywordId,
                        principalTable: "Keywords",
                        principalColumn: "KeywordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleLanguage",
                columns: table => new
                {
                    ArticlesArticleId = table.Column<string>(type: "TEXT", nullable: false),
                    LanguagesLanguageId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleLanguage", x => new { x.ArticlesArticleId, x.LanguagesLanguageId });
                    table.ForeignKey(
                        name: "FK_ArticleLanguage_Articles_ArticlesArticleId",
                        column: x => x.ArticlesArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleLanguage_Languages_LanguagesLanguageId",
                        column: x => x.LanguagesLanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ReaderId = table.Column<string>(type: "TEXT", nullable: false),
                    ArticleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteArticles",
                columns: table => new
                {
                    FavoriteArticleId = table.Column<string>(type: "TEXT", nullable: false),
                    ReaderId = table.Column<string>(type: "TEXT", nullable: false),
                    ArticleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteArticles", x => x.FavoriteArticleId);
                    table.ForeignKey(
                        name: "FK_FavoriteArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteArticles_Reader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Reader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleGenre_GenresGenreId",
                table: "ArticleGenre",
                column: "GenresGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleKeyword_KeywordsKeywordId",
                table: "ArticleKeyword",
                column: "KeywordsKeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLanguage_LanguagesLanguageId",
                table: "ArticleLanguage",
                column: "LanguagesLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_WriterId",
                table: "Articles",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReaderId",
                table: "Comments",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArticles_ArticleId",
                table: "FavoriteArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArticles_ReaderId",
                table: "FavoriteArticles",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteGenres_GenreId",
                table: "FavoriteGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteGenres_ReaderId",
                table: "FavoriteGenres",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedWriters_ReaderId",
                table: "FollowedWriters",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedWriters_WriterId",
                table: "FollowedWriters",
                column: "WriterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleGenre");

            migrationBuilder.DropTable(
                name: "ArticleKeyword");

            migrationBuilder.DropTable(
                name: "ArticleLanguage");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FavoriteArticles");

            migrationBuilder.DropTable(
                name: "FavoriteGenres");

            migrationBuilder.DropTable(
                name: "FollowedWriters");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DropTable(
                name: "Writer");
        }
    }
}
