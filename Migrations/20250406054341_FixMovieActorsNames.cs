using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETickets.Migrations
{
    /// <inheritdoc />
    public partial class FixMovieActorsNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Actors_ActorsId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movies_MoiveId",
                table: "MovieActors");

            migrationBuilder.RenameColumn(
                name: "ActorsId",
                table: "MovieActors",
                newName: "ActorId");

            migrationBuilder.RenameColumn(
                name: "MoiveId",
                table: "MovieActors",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActors_ActorsId",
                table: "MovieActors",
                newName: "IX_MovieActors_ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Actors_ActorId",
                table: "MovieActors",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Actors_ActorId",
                table: "MovieActors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieActors_Movies_MovieId",
                table: "MovieActors");

            migrationBuilder.RenameColumn(
                name: "ActorId",
                table: "MovieActors",
                newName: "ActorsId");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieActors",
                newName: "MoiveId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                newName: "IX_MovieActors_ActorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Actors_ActorsId",
                table: "MovieActors",
                column: "ActorsId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieActors_Movies_MoiveId",
                table: "MovieActors",
                column: "MoiveId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
