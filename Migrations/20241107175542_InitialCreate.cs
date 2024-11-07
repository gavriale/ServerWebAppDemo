using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CertificateId = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@example.com", "John Doe", "U001" },
                    { 2, new DateTime(1992, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane@example.com", "Jane Smith", "U002" },
                    { 3, new DateTime(1985, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@example.com", "Alice Johnson", "U003" },
                    { 4, new DateTime(1995, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@example.com", "Bob Brown", "U004" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "CertificateId", "Description", "DueDate", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, "C001", "Certification A", new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3673), new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3625), 1 },
                    { 2, "C002", "Certification B", new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3683), new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3681), 2 },
                    { 3, "C003", "Certification C", new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3689), new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3687), 3 },
                    { 4, "C004", "Certification D", new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3694), new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3692), 1 },
                    { 5, "C005", "Certification E", new DateTime(2025, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3700), new DateTime(2024, 11, 7, 12, 55, 42, 213, DateTimeKind.Local).AddTicks(3698), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_UserId",
                table: "Certificates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
