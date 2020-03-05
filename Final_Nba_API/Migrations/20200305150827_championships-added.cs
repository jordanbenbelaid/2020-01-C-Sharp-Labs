using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Nba_API.Migrations
{
    public partial class championshipsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChampionshipAppearances",
                table: "NbaTeams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChampionshipWins",
                table: "NbaTeams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "NbaTeams",
                keyColumn: "NbaTeamID",
                keyValue: 1,
                columns: new[] { "ChampionshipAppearances", "ChampionshipWins" },
                values: new object[] { 31, 16 });

            migrationBuilder.UpdateData(
                table: "NbaTeams",
                keyColumn: "NbaTeamID",
                keyValue: 2,
                columns: new[] { "ChampionshipAppearances", "ChampionshipWins" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "NbaTeams",
                keyColumn: "NbaTeamID",
                keyValue: 3,
                columns: new[] { "ChampionshipAppearances", "ChampionshipWins" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "NbaTeams",
                keyColumn: "NbaTeamID",
                keyValue: 4,
                columns: new[] { "ChampionshipAppearances", "ChampionshipWins" },
                values: new object[] { 3, 1 });

            migrationBuilder.UpdateData(
                table: "NbaTeams",
                keyColumn: "NbaTeamID",
                keyValue: 5,
                columns: new[] { "ChampionshipAppearances", "ChampionshipWins" },
                values: new object[] { 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChampionshipAppearances",
                table: "NbaTeams");

            migrationBuilder.DropColumn(
                name: "ChampionshipWins",
                table: "NbaTeams");
        }
    }
}
