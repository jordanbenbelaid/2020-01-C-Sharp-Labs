using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Nba_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NbaTeams",
                columns: table => new
                {
                    NbaTeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbaTeamName = table.Column<string>(maxLength: 50, nullable: false),
                    NbaTeamConference = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NbaTeams", x => x.NbaTeamID);
                });

            migrationBuilder.CreateTable(
                name: "CurrentPlayers",
                columns: table => new
                {
                    CurrentPlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentPlayerName = table.Column<string>(nullable: true),
                    CurrentPlayerPosition = table.Column<string>(nullable: true),
                    CurrentPlayerDOB = table.Column<DateTime>(nullable: false),
                    NbaTeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentPlayers", x => x.CurrentPlayerID);
                    table.ForeignKey(
                        name: "FK_CurrentPlayers_NbaTeams_NbaTeamID",
                        column: x => x.NbaTeamID,
                        principalTable: "NbaTeams",
                        principalColumn: "NbaTeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricPlayers",
                columns: table => new
                {
                    HistoricPlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HistoricPlayerName = table.Column<string>(nullable: true),
                    HistoricPlayerPosition = table.Column<string>(nullable: true),
                    HistoricPlayerDOB = table.Column<DateTime>(nullable: false),
                    PlayerRetired = table.Column<DateTime>(nullable: false),
                    NbaTeamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricPlayers", x => x.HistoricPlayerID);
                    table.ForeignKey(
                        name: "FK_HistoricPlayers_NbaTeams_NbaTeamID",
                        column: x => x.NbaTeamID,
                        principalTable: "NbaTeams",
                        principalColumn: "NbaTeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NbaTeams",
                columns: new[] { "NbaTeamID", "NbaTeamConference", "NbaTeamName" },
                values: new object[,]
                {
                    { 1, "West", "LA Lakers" },
                    { 2, "East", "Miami Heat" },
                    { 3, "West", "Dallas Mavericks" },
                    { 4, "West", "Portland Trailblazers" },
                    { 5, "East", "Milwaukee Bucks" }
                });

            migrationBuilder.InsertData(
                table: "CurrentPlayers",
                columns: new[] { "CurrentPlayerID", "CurrentPlayerDOB", "CurrentPlayerName", "CurrentPlayerPosition", "NbaTeamID" },
                values: new object[,]
                {
                    { 1, new DateTime(1984, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "LeBron James", "Small Forward", 1 },
                    { 2, new DateTime(2000, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tyler Herro", "Shooting Guard", 2 },
                    { 3, new DateTime(1999, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luka Doncic", "Small Forward", 3 },
                    { 4, new DateTime(1990, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Damian Lillard", "Point Guard", 4 },
                    { 5, new DateTime(1994, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giannis Antetokounmpo", "Power Forward", 5 }
                });

            migrationBuilder.InsertData(
                table: "HistoricPlayers",
                columns: new[] { "HistoricPlayerID", "HistoricPlayerDOB", "HistoricPlayerName", "HistoricPlayerPosition", "NbaTeamID", "PlayerRetired" },
                values: new object[,]
                {
                    { 1, new DateTime(1938, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jerry West", "Point Guard", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1974) },
                    { 2, new DateTime(1982, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne Wade", "Shooting Guard", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1978, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dirk Nowitzki", "Centre", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1962, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clyde Drexler", "Small Forward", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1947, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karim Abdul-Jabbar", "Centre", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrentPlayers_NbaTeamID",
                table: "CurrentPlayers",
                column: "NbaTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricPlayers_NbaTeamID",
                table: "HistoricPlayers",
                column: "NbaTeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentPlayers");

            migrationBuilder.DropTable(
                name: "HistoricPlayers");

            migrationBuilder.DropTable(
                name: "NbaTeams");
        }
    }
}
