using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedAccoaldeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3fa19e77-4f87-43f9-8f94-03662b8356be"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5a90bbdf-7aef-44cb-9401-419b10d1d56a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("761203ff-3c1a-4bc0-9225-d86ed04c3a4c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f2ead31-e380-4093-b332-600d435a09d5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a2c753fd-05c6-435c-94b4-8683d1e7be40"));

            migrationBuilder.AddColumn<byte>(
                name: "ArtworkType",
                schema: "dbo",
                table: "Accolades",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Director",
                schema: "dbo",
                table: "Accolades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterFile",
                schema: "dbo",
                table: "Accolades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrailerLink",
                schema: "dbo",
                table: "Accolades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("27c49e9e-353c-485c-880e-07de717c2d68"), null, new DateTime(2026, 1, 8, 12, 25, 49, 441, DateTimeKind.Local).AddTicks(8444), "Client", null },
                    { new Guid("4d342d64-9681-4252-be68-b6a0586ab268"), null, new DateTime(2026, 1, 8, 12, 25, 49, 441, DateTimeKind.Local).AddTicks(8439), "Admin", null },
                    { new Guid("789f9602-4188-4d39-9810-426cd09036d1"), null, new DateTime(2026, 1, 8, 12, 25, 49, 441, DateTimeKind.Local).AddTicks(8381), "King", null },
                    { new Guid("c8ab9033-a621-402d-b58f-534d15a7fd94"), null, new DateTime(2026, 1, 8, 12, 25, 49, 441, DateTimeKind.Local).AddTicks(8434), "SuperAdmin", null },
                    { new Guid("cf9e3239-b77f-4f3d-9c2a-2f013d0dbaec"), null, new DateTime(2026, 1, 8, 12, 25, 49, 441, DateTimeKind.Local).AddTicks(8448), "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("27c49e9e-353c-485c-880e-07de717c2d68"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d342d64-9681-4252-be68-b6a0586ab268"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("789f9602-4188-4d39-9810-426cd09036d1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c8ab9033-a621-402d-b58f-534d15a7fd94"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf9e3239-b77f-4f3d-9c2a-2f013d0dbaec"));

            migrationBuilder.DropColumn(
                name: "ArtworkType",
                schema: "dbo",
                table: "Accolades");

            migrationBuilder.DropColumn(
                name: "Director",
                schema: "dbo",
                table: "Accolades");

            migrationBuilder.DropColumn(
                name: "PosterFile",
                schema: "dbo",
                table: "Accolades");

            migrationBuilder.DropColumn(
                name: "TrailerLink",
                schema: "dbo",
                table: "Accolades");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("3fa19e77-4f87-43f9-8f94-03662b8356be"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7884), "SuperAdmin", null },
                    { new Guid("5a90bbdf-7aef-44cb-9401-419b10d1d56a"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7827), "King", null },
                    { new Guid("761203ff-3c1a-4bc0-9225-d86ed04c3a4c"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7899), "User", null },
                    { new Guid("8f2ead31-e380-4093-b332-600d435a09d5"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7895), "Client", null },
                    { new Guid("a2c753fd-05c6-435c-94b4-8683d1e7be40"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7890), "Admin", null }
                });
        }
    }
}
