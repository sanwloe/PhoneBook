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
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfRegistration = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbers", x => x.Number);
                });

            migrationBuilder.InsertData(
                table: "Numbers",
                columns: new[] { "Number", "DateOfRegistration", "Description", "FirstName", "FullName", "LastName", "LastUpdateDate" },
                values: new object[,]
                {
                    { "+38012345678", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6593), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", "", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6659), new TimeSpan(0, 2, 0, 0, 0)) },
                    { "+38023456781", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", "", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6665), new TimeSpan(0, 2, 0, 0, 0)) },
                    { "+38034567812", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6667), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", "", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6668), new TimeSpan(0, 2, 0, 0, 0)) },
                    { "+38045678123", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6670), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", "", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6671), new TimeSpan(0, 2, 0, 0, 0)) },
                    { "+38056781234", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6672), new TimeSpan(0, 2, 0, 0, 0)), "", "", "", "", new DateTimeOffset(new DateTime(2025, 2, 17, 14, 40, 53, 514, DateTimeKind.Unspecified).AddTicks(6673), new TimeSpan(0, 2, 0, 0, 0)) }
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
