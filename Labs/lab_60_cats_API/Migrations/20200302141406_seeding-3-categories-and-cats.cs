using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_60_cats_API.Migrations
{
    public partial class seeding3categoriesandcats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Bengal" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Tabby" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Siamese" });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatID", "CatName", "CategoryID" },
                values: new object[] { 1, "Kitty", 1 });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatID", "CatName", "CategoryID" },
                values: new object[] { 2, "Garfield", 2 });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatID", "CatName", "CategoryID" },
                values: new object[] { 3, "Rengar", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);
        }
    }
}
