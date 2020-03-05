using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Nba_API.Migrations
{
    public partial class retireddatesfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 1,
                column: "PlayerRetired",
                value: new DateTime(1974, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 2,
                column: "PlayerRetired",
                value: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 3,
                column: "PlayerRetired",
                value: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 4,
                column: "PlayerRetired",
                value: new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 5,
                column: "PlayerRetired",
                value: new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 1,
                column: "PlayerRetired",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 2,
                column: "PlayerRetired",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 3,
                column: "PlayerRetired",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 4,
                column: "PlayerRetired",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "HistoricPlayers",
                keyColumn: "HistoricPlayerID",
                keyValue: 5,
                column: "PlayerRetired",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1989));
        }
    }
}
