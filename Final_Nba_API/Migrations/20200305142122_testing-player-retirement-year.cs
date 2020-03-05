using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Nba_API.Migrations
{
    public partial class testingplayerretirementyear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 1,
                column: "PlayerRetired",
                value: new DateTime(1974, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 1,
                column: "PlayerRetired",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1974));
        }
    }
}
