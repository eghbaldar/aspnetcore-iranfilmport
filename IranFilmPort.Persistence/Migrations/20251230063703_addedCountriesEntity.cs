using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedCountriesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0cd4a406-1cee-422b-9000-ba673a92382a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("35974289-23a7-48e4-b0a1-e110124da5c0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cd8711da-0a5a-4ca9-885e-43002f674a56"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d38d0132-f53b-4704-b42a-7846c3476dd3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("faa0b0ac-0098-4c4e-bd7a-cacb89d8eab0"));

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("37d2924a-406a-45a8-92bc-7216a49009af"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6509), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5183bf43-fbf8-4eaf-8420-9b018bb36f55"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6499), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b96bc713-f26b-4f7b-aefd-5a4a093e5ea8"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6479), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9b0a857-67be-45b8-be97-0734228e7982"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6441), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec4a824d-404a-4f7e-89fc-1c6d07b6e9ae"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6504), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("37d2924a-406a-45a8-92bc-7216a49009af"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5183bf43-fbf8-4eaf-8420-9b018bb36f55"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b96bc713-f26b-4f7b-aefd-5a4a093e5ea8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9b0a857-67be-45b8-be97-0734228e7982"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ec4a824d-404a-4f7e-89fc-1c6d07b6e9ae"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("0cd4a406-1cee-422b-9000-ba673a92382a"), null, new DateTime(2025, 12, 29, 9, 32, 36, 29, DateTimeKind.Local).AddTicks(4167), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("35974289-23a7-48e4-b0a1-e110124da5c0"), null, new DateTime(2025, 12, 29, 9, 32, 36, 29, DateTimeKind.Local).AddTicks(4121), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd8711da-0a5a-4ca9-885e-43002f674a56"), null, new DateTime(2025, 12, 29, 9, 32, 36, 29, DateTimeKind.Local).AddTicks(4162), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d38d0132-f53b-4704-b42a-7846c3476dd3"), null, new DateTime(2025, 12, 29, 9, 32, 36, 29, DateTimeKind.Local).AddTicks(4191), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("faa0b0ac-0098-4c4e-bd7a-cacb89d8eab0"), null, new DateTime(2025, 12, 29, 9, 32, 36, 29, DateTimeKind.Local).AddTicks(4195), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
