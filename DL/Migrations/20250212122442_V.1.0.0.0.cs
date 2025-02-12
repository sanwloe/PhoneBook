using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DL.Migrations
{
    /// <inheritdoc />
    public partial class V1000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Numbers",
                columns: table => new
                {
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfRegistration = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbers", x => x.Number);
                });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Number", "DateOfRegistration", "FirstName", "FullName", "LastName", "LastUpdateDate" },
                values: new object[,]
                {
                    { "+38012345678", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(918), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(984), new TimeSpan(0, 2, 0, 0, 0)) },
                    { "+38023456781", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(988), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(990), new TimeSpan(0, 2, 0, 0, 0)) },
                    { "+38034567812", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(992), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(993), new TimeSpan(0, 2, 0, 0, 0)) },
                    { "+38045678123", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(995), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(996), new TimeSpan(0, 2, 0, 0, 0)) },
                    { "+38056781234", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(998), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", new DateTimeOffset(new DateTime(2025, 2, 12, 14, 24, 42, 316, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 2, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_Number",
                table: "Numbers",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Numbers");
        }
    }
}
