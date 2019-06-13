using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework_DataAccess.Migrations
{
    public partial class addedusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_Actors_ActorId",
                table: "Movies_Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_Movies_MovieId",
                table: "Movies_Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_Cinemas_CinemaId",
                table: "Movies_Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_Movies_MovieId",
                table: "Movies_Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_Genres_GenreId",
                table: "Movies_Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_Movies_MovieId",
                table: "Movies_Genres");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movies_Genres",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Movies_Genres",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movies_Cinemas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Movies_Cinemas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movies_Actors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "Movies_Actors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartShowingFrom",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_Actors_ActorId",
                table: "Movies_Actors",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_Movies_MovieId",
                table: "Movies_Actors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_Cinemas_CinemaId",
                table: "Movies_Cinemas",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_Movies_MovieId",
                table: "Movies_Cinemas",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_Genres_GenreId",
                table: "Movies_Genres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_Movies_MovieId",
                table: "Movies_Genres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_Actors_ActorId",
                table: "Movies_Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_Movies_MovieId",
                table: "Movies_Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_Cinemas_CinemaId",
                table: "Movies_Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Cinemas_Movies_MovieId",
                table: "Movies_Cinemas");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_Genres_GenreId",
                table: "Movies_Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_Movies_MovieId",
                table: "Movies_Genres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movies_Genres",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "Movies_Genres",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movies_Cinemas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Movies_Cinemas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movies_Actors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "Movies_Actors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartShowingFrom",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_Actors_ActorId",
                table: "Movies_Actors",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_Movies_MovieId",
                table: "Movies_Actors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_Cinemas_CinemaId",
                table: "Movies_Cinemas",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Cinemas_Movies_MovieId",
                table: "Movies_Cinemas",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_Genres_GenreId",
                table: "Movies_Genres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_Movies_MovieId",
                table: "Movies_Genres",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
