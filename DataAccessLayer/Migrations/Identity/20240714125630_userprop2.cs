using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations.Identity
{
    /// <inheritdoc />
    public partial class userprop2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_AspNetUsers_WriterId",
                table: "Article");

            migrationBuilder.AlterColumn<string>(
                name: "WriterId",
                table: "Article",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_AspNetUsers_WriterId",
                table: "Article",
                column: "WriterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_AspNetUsers_WriterId",
                table: "Article");

            migrationBuilder.AlterColumn<string>(
                name: "WriterId",
                table: "Article",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_AspNetUsers_WriterId",
                table: "Article",
                column: "WriterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
