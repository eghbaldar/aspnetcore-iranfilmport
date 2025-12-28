using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedTitleEnForNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5aabeadb-4f56-4787-bc6f-a253fbb548e3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75918b63-9d8d-46be-ad39-70da56d0bae4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cbdcbd5e-7a94-4d0c-887d-db7cea7f8816"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ea28ff58-c301-4084-b517-dcbf2e680a8d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fc031c5c-712d-4a9e-b7e3-5e3d9a9d570b"));

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                schema: "dbo",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("154850e0-84c5-43ab-bc66-8489e83e35c3"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(235), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3cf5c248-ed04-4579-8ca4-3175ed4d6c7f"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(303), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e7919e8-1990-4db7-9698-063476483f5d"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(284), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab0f4bd6-bda8-4baa-bc47-3f11b024e138"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(307), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dad2573b-9de5-4872-9491-4328d48615ce"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(279), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("154850e0-84c5-43ab-bc66-8489e83e35c3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3cf5c248-ed04-4579-8ca4-3175ed4d6c7f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7e7919e8-1990-4db7-9698-063476483f5d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ab0f4bd6-bda8-4baa-bc47-3f11b024e138"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dad2573b-9de5-4872-9491-4328d48615ce"));

            migrationBuilder.DropColumn(
                name: "TitleEn",
                schema: "dbo",
                table: "News");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("5aabeadb-4f56-4787-bc6f-a253fbb548e3"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8683), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75918b63-9d8d-46be-ad39-70da56d0bae4"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8725), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cbdcbd5e-7a94-4d0c-887d-db7cea7f8816"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8730), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea28ff58-c301-4084-b517-dcbf2e680a8d"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8753), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc031c5c-712d-4a9e-b7e3-5e3d9a9d570b"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8748), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
