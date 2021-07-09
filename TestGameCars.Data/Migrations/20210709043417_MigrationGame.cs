using Microsoft.EntityFrameworkCore.Migrations;

namespace TestGameCars.Data.Migrations
{
    public partial class MigrationGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    idCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandCar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.idCar);
                });

            migrationBuilder.CreateTable(
                name: "lines",
                columns: table => new
                {
                    idLine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameLine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lines", x => x.idLine);
                });

            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    idDriver = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameDriver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.idDriver);
                    table.ForeignKey(
                        name: "FK_drivers_cars_idCar",
                        column: x => x.idCar,
                        principalTable: "cars",
                        principalColumn: "idCar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tracks",
                columns: table => new
                {
                    idTrack = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kilometres = table.Column<int>(type: "int", nullable: false),
                    nameTrack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idLine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracks", x => x.idTrack);
                    table.ForeignKey(
                        name: "FK_tracks_lines_idLine",
                        column: x => x.idLine,
                        principalTable: "lines",
                        principalColumn: "idLine",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    idPlayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countPlayer = table.Column<int>(type: "int", nullable: false),
                    namePlayer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idDriver = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.idPlayer);
                    table.ForeignKey(
                        name: "FK_players_drivers_idDriver",
                        column: x => x.idDriver,
                        principalTable: "drivers",
                        principalColumn: "idDriver",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    idGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idPlayer = table.Column<int>(type: "int", nullable: false),
                    idTrack = table.Column<int>(type: "int", nullable: false),
                    idLine = table.Column<int>(type: "int", nullable: false),
                    idDriver = table.Column<int>(type: "int", nullable: false),
                    idCar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.idGame);
                    table.ForeignKey(
                        name: "FK_games_cars_idCar",
                        column: x => x.idCar,
                        principalTable: "cars",
                        principalColumn: "idCar",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_games_drivers_idDriver",
                        column: x => x.idDriver,
                        principalTable: "drivers",
                        principalColumn: "idDriver",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_games_lines_idLine",
                        column: x => x.idLine,
                        principalTable: "lines",
                        principalColumn: "idLine",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_games_players_idPlayer",
                        column: x => x.idPlayer,
                        principalTable: "players",
                        principalColumn: "idPlayer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_games_tracks_idTrack",
                        column: x => x.idTrack,
                        principalTable: "tracks",
                        principalColumn: "idTrack",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_drivers_idCar",
                table: "drivers",
                column: "idCar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_games_idCar",
                table: "games",
                column: "idCar");

            migrationBuilder.CreateIndex(
                name: "IX_games_idDriver",
                table: "games",
                column: "idDriver");

            migrationBuilder.CreateIndex(
                name: "IX_games_idLine",
                table: "games",
                column: "idLine");

            migrationBuilder.CreateIndex(
                name: "IX_games_idPlayer",
                table: "games",
                column: "idPlayer");

            migrationBuilder.CreateIndex(
                name: "IX_games_idTrack",
                table: "games",
                column: "idTrack");

            migrationBuilder.CreateIndex(
                name: "IX_players_idDriver",
                table: "players",
                column: "idDriver",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tracks_idLine",
                table: "tracks",
                column: "idLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "tracks");

            migrationBuilder.DropTable(
                name: "drivers");

            migrationBuilder.DropTable(
                name: "lines");

            migrationBuilder.DropTable(
                name: "cars");
        }
    }
}
