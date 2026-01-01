using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserEntity6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("491d6676-8d5a-4673-b59f-948edfafb499"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("adc74516-6740-4c2a-ab02-9efcfc43f570"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2617f8a-bb80-45db-9021-a1bd2cc1eec7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b8e84886-0ef4-4f1f-a78a-3cde2de9d0b8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e35bc3b5-878d-4578-ab62-8a18cbee351f"));

            migrationBuilder.AddColumn<string>(
                name: "HeadshotStatusMessage",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainStatusMessage",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeliCardStatusMessage",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("28e24f1c-fa28-427d-85d0-eb1fbea62944"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6088), "SuperAdmin", null },
                    { new Guid("430a307c-0b1f-4c07-b808-b7bf038fe02d"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6098), "Client", null },
                    { new Guid("a4ce3392-04a5-4908-b780-29b4b8a44250"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6047), "King", null },
                    { new Guid("df29e227-0dd7-457a-945d-405dd8e4a746"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6093), "Admin", null },
                    { new Guid("faf42f18-cf58-4b49-acb8-ef1d88379e2a"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6115), "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("28e24f1c-fa28-427d-85d0-eb1fbea62944"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("430a307c-0b1f-4c07-b808-b7bf038fe02d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4ce3392-04a5-4908-b780-29b4b8a44250"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df29e227-0dd7-457a-945d-405dd8e4a746"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("faf42f18-cf58-4b49-acb8-ef1d88379e2a"));

            migrationBuilder.DropColumn(
                name: "HeadshotStatusMessage",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MainStatusMessage",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeliCardStatusMessage",
                schema: "dbo",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("491d6676-8d5a-4673-b59f-948edfafb499"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3932), "User", null },
                    { new Guid("adc74516-6740-4c2a-ab02-9efcfc43f570"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3921), "Admin", null },
                    { new Guid("b2617f8a-bb80-45db-9021-a1bd2cc1eec7"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3894), "SuperAdmin", null },
                    { new Guid("b8e84886-0ef4-4f1f-a78a-3cde2de9d0b8"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3927), "Client", null },
                    { new Guid("e35bc3b5-878d-4578-ab62-8a18cbee351f"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3857), "King", null }
                });
        }
    }
}
