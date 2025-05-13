using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticketing_CS.Migrations
{
    /// <inheritdoc />
    public partial class FirstThreeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChoiceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Choice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticketings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelId = table.Column<int>(type: "int", nullable: false),
                    UrgencyId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    DateInput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticketings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticketings_ChoiceList_LevelId",
                        column: x => x.LevelId,
                        principalTable: "ChoiceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticketings_ChoiceList_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ChoiceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticketings_ChoiceList_UrgencyId",
                        column: x => x.UrgencyId,
                        principalTable: "ChoiceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticketings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChoiceList",
                columns: new[] { "Id", "Choice", "IsActive", "Option" },
                values: new object[,]
                {
                    { 1, "On-Progress", true, "Status" },
                    { 2, "Finished", true, "Status" },
                    { 3, "Cancelled", true, "Status" },
                    { 4, "On Waiting", true, "Status" },
                    { 5, "Normal", true, "Urgency" },
                    { 6, "Urgent", true, "Urgency" },
                    { 7, "Very Urgent", true, "Urgency" },
                    { 8, "Normal", true, "Level" },
                    { 9, "Medium", true, "Level" },
                    { 10, "Hard", true, "Level" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "UserName" },
                values: new object[] { 1, true, "1243", "Super" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticketings_LevelId",
                table: "Ticketings",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticketings_StatusId",
                table: "Ticketings",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticketings_UrgencyId",
                table: "Ticketings",
                column: "UrgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticketings_UserId",
                table: "Ticketings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticketings");

            migrationBuilder.DropTable(
                name: "ChoiceList");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
