using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gameapi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "games",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false),
        //            name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            released = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            background_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            rating = table.Column<double>(type: "float", nullable: false),
        //            ratings_count = table.Column<int>(type: "int", nullable: false),
        //            added = table.Column<int>(type: "int", nullable: false),
        //            metacritic = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_games", x => x.id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "genres",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false),
        //            name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            games_count = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_genres", x => x.id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "platforms",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false),
        //            name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_platforms", x => x.id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tags",
        //        columns: table => new
        //        {
        //            id = table.Column<int>(type: "int", nullable: false),
        //            name = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //            games_count = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_tags", x => x.id);
        //        });

            migrationBuilder.CreateTable(
                name: "UserRate",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                });

        //    migrationBuilder.CreateTable(
        //        name: "Genresgames",
        //        columns: table => new
        //        {
        //            gamesid = table.Column<int>(type: "int", nullable: false),
        //            genresid = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Genresgames", x => new { x.gamesid, x.genresid });
        //            table.ForeignKey(
        //                name: "FK_Genresgames_games_gamesid",
        //                column: x => x.gamesid,
        //                principalTable: "games",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Genresgames_genres_genresid",
        //                column: x => x.genresid,
        //                principalTable: "genres",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Platformsgames",
        //        columns: table => new
        //        {
        //            gamesplatformsid = table.Column<int>(type: "int", nullable: false),
        //            platformsid = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Platformsgames", x => new { x.gamesplatformsid, x.platformsid });
        //            table.ForeignKey(
        //                name: "FK_Platformsgames_games_gamesplatformsid",
        //                column: x => x.gamesplatformsid,
        //                principalTable: "games",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Platformsgames_platforms_platformsid",
        //                column: x => x.platformsid,
        //                principalTable: "platforms",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Tagsgames",
        //        columns: table => new
        //        {
        //            gamesid = table.Column<int>(type: "int", nullable: false),
        //            tagsid = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Tagsgames", x => new { x.gamesid, x.tagsid });
        //            table.ForeignKey(
        //                name: "FK_Tagsgames_games_gamesid",
        //                column: x => x.gamesid,
        //                principalTable: "games",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Tagsgames_tags_tagsid",
        //                column: x => x.tagsid,
        //                principalTable: "tags",
        //                principalColumn: "id",
        //                onDelete: ReferentialAction.Cascade);
        //        });
        //    migrationBuilder.CreateIndex(
        //        name: "IX_Genresgames_genresid",
        //        table: "Genresgames",
        //        column: "genresid");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Platformsgames_platformsid",
        //        table: "Platformsgames",
        //        column: "platformsid");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Tagsgames_tagsid",
        //        table: "Tagsgames",
        //        column: "tagsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genresgames");

            migrationBuilder.DropTable(
                name: "Platformsgames");

            migrationBuilder.DropTable(
                name: "Tagsgames");

            migrationBuilder.DropTable(
                name: "UserRate");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "platforms");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "tags");
        }
    }
}
