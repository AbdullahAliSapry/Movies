using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebsiteMovies.Migrations
{
    /// <inheritdoc />
    public partial class EditNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrailUrl",
                table: "Movies",
                newName: "TrailerUrl");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StartData",
                table: "Movies",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndData",
                table: "Movies",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrailerUrl",
                table: "Movies",
                newName: "TrailUrl");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Movies",
                newName: "StartData");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movies",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Movies",
                newName: "EndData");
        }
    }
}
