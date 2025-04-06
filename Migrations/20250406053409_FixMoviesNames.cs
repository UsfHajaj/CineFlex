using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETickets.Migrations
{
    /// <inheritdoc />
    public partial class FixMoviesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoveCategory",
                table: "Movies",
                newName: "MovieCategory");

            migrationBuilder.RenameColumn(
                name: "EndtDate",
                table: "Movies",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieCategory",
                table: "Movies",
                newName: "MoveCategory");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Movies",
                newName: "EndtDate");
        }
    }
}
