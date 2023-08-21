using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClimateChangeDashboardBackend.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<string>(type: "text", nullable: false),
                    MembershipLevel = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Analytics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: true),
                    PageViewed = table.Column<string>(type: "text", nullable: false),
                    TimeStamp = table.Column<string>(type: "text", nullable: false),
                    DeviceType = table.Column<string>(type: "text", nullable: false),
                    Browser = table.Column<string>(type: "text", nullable: false),
                    ReferrerUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analytics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analytics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedAt", "MembershipLevel", "Password", "Role", "State", "Username" },
                values: new object[,]
                {
                    { new Guid("12a605c1-51b2-4ffe-9782-13abc680c571"), "123 Lake ave", "Colorado Springs", "United States", "2023-07-03T03:03:44.569Z", "basic", "abc123", "BaseUser", "Colorado", "John" },
                    { new Guid("4d18a679-046b-46db-8c6e-0fea0c6da2cb"), "123 Lake ave", "Colorado Springs", "United States", "2023-06-27T03:21:44.569Z", "basic", "abc123", "BaseUser", "Colorado", "hunter" },
                    { new Guid("dc875fd0-da87-4c86-ac41-9cec978a58b3"), "123 Lake ave", "Colorado Springs", "United States", "2023-08-20T03:11:44.569Z", "basic", "abc123", "BaseUser", "Colorado", "hunter" }
                });

            migrationBuilder.InsertData(
                table: "Analytics",
                columns: new[] { "Id", "Browser", "DeviceType", "PageViewed", "ReferrerUrl", "SessionId", "TimeStamp", "UserId" },
                values: new object[,]
                {
                    { new Guid("61084f93-54d5-457f-9c6b-b100fc29cd6a"), "Chrome", "Desktop", "ClimateChangeDashboard", "www.google.com", new Guid("6cad72f9-f844-4dcd-a7c8-75731edfca3a"), "2023-08-20T03:11:44.569Z", new Guid("dc875fd0-da87-4c86-ac41-9cec978a58b3") },
                    { new Guid("918d2e76-cd7f-4520-850c-6cb8df002d99"), "Chrome", "Desktop", "ClimateChangeDashboard", "www.google.com", new Guid("a16ba5b6-21a4-4d83-9aa6-91d1715448f8"), "2023-08-20T03:11:44.569Z", new Guid("12a605c1-51b2-4ffe-9782-13abc680c571") },
                    { new Guid("af784f76-f05d-4930-bf41-5e587f581bc7"), "Chrome", "Desktop", "ClimateChangeDashboard", "www.google.com", new Guid("603ab4d2-8739-462b-b291-f81c383bb3e8"), "2023-08-20T03:11:44.569Z", new Guid("4d18a679-046b-46db-8c6e-0fea0c6da2cb") }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Body", "CreatedAt", "Role", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { new Guid("a5105cf4-dbfa-4087-b6c8-673f4beea6bb"), "this is the body 2", "2023-08-20T03:11:44.569Z", "BaseUser", "pending", "title 2", new Guid("12a605c1-51b2-4ffe-9782-13abc680c571") },
                    { new Guid("ce7909e5-2d6e-4980-bb10-f63b163a09d7"), "this is the body", "2023-08-20T03:11:44.569Z", "BaseUser", "pending", "title", new Guid("dc875fd0-da87-4c86-ac41-9cec978a58b3") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analytics_UserId",
                table: "Analytics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analytics");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
