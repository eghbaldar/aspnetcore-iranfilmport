using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifedFestivalEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0f96b598-9c41-41f8-9c9f-0de4823c5b17"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49a0b5ce-dee3-4477-8f26-a88bfb84cee7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4e0bd103-2834-4160-808e-85ae87ac3539"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("97ea0939-a26e-4bc7-9b13-2c7212f60229"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c73005fe-0254-4cf0-9a9e-3943f0c74dab"));

            migrationBuilder.AddColumn<int>(
                name: "UniqueCode",
                schema: "dbo",
                table: "Festivals",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                schema: "dbo",
                table: "Festivals");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("0f96b598-9c41-41f8-9c9f-0de4823c5b17"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1386), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49a0b5ce-dee3-4477-8f26-a88bfb84cee7"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1392), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e0bd103-2834-4160-808e-85ae87ac3539"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1367), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("97ea0939-a26e-4bc7-9b13-2c7212f60229"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1324), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c73005fe-0254-4cf0-9a9e-3943f0c74dab"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1360), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
