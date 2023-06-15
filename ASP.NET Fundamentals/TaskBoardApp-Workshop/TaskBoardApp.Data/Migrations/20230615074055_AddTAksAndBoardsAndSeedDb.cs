using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class AddTAksAndBoardsAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Open" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "In Progress" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("3a28dd1e-cedc-45db-939d-ff0928967c17"), 1, new DateTime(2022, 11, 27, 10, 40, 55, 643, DateTimeKind.Local).AddTicks(3688), "Implement better styling for all public pages", "79a30247-dad3-4084-b998-d5b58bf7438f", "Improve css styles" },
                    { new Guid("8eb33a84-cc6d-4bab-95d6-f94d256df14e"), 2, new DateTime(2023, 5, 15, 10, 40, 55, 643, DateTimeKind.Local).AddTicks(3746), "Create desktop client app for restfull task board service", "79a30247-dad3-4084-b998-d5b58bf7438f", "Desktop client app" },
                    { new Guid("a30cb3a7-a565-4510-ab46-86f702dd449b"), 1, new DateTime(2023, 1, 15, 10, 40, 55, 643, DateTimeKind.Local).AddTicks(3740), "Create android client app for restfull task board service", "9f38a765-116e-4f82-b21f-1b91c890281c", "Android Client app" },
                    { new Guid("ac03e600-4f00-4df1-863e-e8655bcdf21a"), 3, new DateTime(2022, 6, 15, 10, 40, 55, 643, DateTimeKind.Local).AddTicks(3751), "Implement create taks page for addingn tasks", "79a30247-dad3-4084-b998-d5b58bf7438f", "Create taksk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
