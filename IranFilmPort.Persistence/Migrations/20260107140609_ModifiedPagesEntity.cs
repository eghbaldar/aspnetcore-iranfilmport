using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedPagesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("03610a35-59eb-44dc-819a-64c50e337610"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2d79e8a4-ff17-4ab1-a241-9870593a0850"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("53500cf6-110c-410d-9966-f2d347483281"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("54f80d5f-be61-4ca8-902b-e26143cbb779"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d4912e4-5d58-4c77-ab33-6af382f32ce4"));

            migrationBuilder.RenameColumn(
                name: "ResumeAdvertisement",
                schema: "dbo",
                table: "Pages",
                newName: "Advertisements");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("2dcc5aca-baaf-4523-8703-4933e38b984d"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3227), "King", null },
                    { new Guid("6ac316ba-b2c9-49f0-938b-c4c8a6881467"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3299), "Client", null },
                    { new Guid("c18d806a-099b-4c3c-8a3b-2a4497f79b93"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3280), "Admin", null },
                    { new Guid("d7bffb17-12c5-403b-a996-22189b9e6d51"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3274), "SuperAdmin", null },
                    { new Guid("f9755536-efd2-4af2-9849-83eb1827463d"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3303), "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2dcc5aca-baaf-4523-8703-4933e38b984d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6ac316ba-b2c9-49f0-938b-c4c8a6881467"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c18d806a-099b-4c3c-8a3b-2a4497f79b93"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d7bffb17-12c5-403b-a996-22189b9e6d51"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f9755536-efd2-4af2-9849-83eb1827463d"));

            migrationBuilder.RenameColumn(
                name: "Advertisements",
                schema: "dbo",
                table: "Pages",
                newName: "ResumeAdvertisement");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("03610a35-59eb-44dc-819a-64c50e337610"), null, new DateTime(2026, 1, 7, 17, 27, 39, 657, DateTimeKind.Local).AddTicks(1900), "Client", null },
                    { new Guid("2d79e8a4-ff17-4ab1-a241-9870593a0850"), null, new DateTime(2026, 1, 7, 17, 27, 39, 657, DateTimeKind.Local).AddTicks(1831), "King", null },
                    { new Guid("53500cf6-110c-410d-9966-f2d347483281"), null, new DateTime(2026, 1, 7, 17, 27, 39, 657, DateTimeKind.Local).AddTicks(1904), "User", null },
                    { new Guid("54f80d5f-be61-4ca8-902b-e26143cbb779"), null, new DateTime(2026, 1, 7, 17, 27, 39, 657, DateTimeKind.Local).AddTicks(1875), "SuperAdmin", null },
                    { new Guid("7d4912e4-5d58-4c77-ab33-6af382f32ce4"), null, new DateTime(2026, 1, 7, 17, 27, 39, 657, DateTimeKind.Local).AddTicks(1895), "Admin", null }
                });
        }
    }
}
