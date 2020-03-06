using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_63_ToDo_API_Users_Categories.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    ToDoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoName = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.ToDoID);
                    table.ForeignKey(
                        name: "FK_ToDos_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ToDoID", "ToDoName", "UserID" },
                values: new object[,]
                {
                    { 1, "Do this", null },
                    { 2, "And do this", null },
                    { 3, "And do this also", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "UserName" },
                values: new object[,]
                {
                    { 1, "Fred" },
                    { 2, "Johnny" },
                    { 3, "Layla" },
                    { 4, "Tim" },
                    { 5, "Venus" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UserID",
                table: "ToDos",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
