using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedAdvertisementMOdalsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("557386ad-9208-4c14-b33c-adc91fec3975"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6e805c94-bbbc-429a-a5a3-ece37acf85e5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("89d1374c-3063-49ae-8fa8-c7a227e88730"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9638e388-b771-41b5-a1ed-4f1e15b5f82a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b931c0e0-6355-4ce8-aee2-9fb134c1be19"));

            migrationBuilder.CreateTable(
                name: "AdvertisementModals",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlinkText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubText1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkSubText1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubText2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkSubText2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visit = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementModals", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("03f0a0e7-b1d8-475d-b7b8-afe4f2729b56"), null, new DateTime(2026, 1, 7, 10, 25, 54, 500, DateTimeKind.Local).AddTicks(956), "King", null },
                    { new Guid("2e89b49c-0b3a-4049-a93d-4c205e7ebcc7"), null, new DateTime(2026, 1, 7, 10, 25, 54, 500, DateTimeKind.Local).AddTicks(1028), "User", null },
                    { new Guid("62de6972-6b42-4b5f-b28f-90c4f6fc28f9"), null, new DateTime(2026, 1, 7, 10, 25, 54, 500, DateTimeKind.Local).AddTicks(998), "SuperAdmin", null },
                    { new Guid("8640ec19-a7db-4e69-afa4-6eef890f189f"), null, new DateTime(2026, 1, 7, 10, 25, 54, 500, DateTimeKind.Local).AddTicks(1023), "Client", null },
                    { new Guid("d9d14231-aaeb-43ff-80a5-a55069f0061f"), null, new DateTime(2026, 1, 7, 10, 25, 54, 500, DateTimeKind.Local).AddTicks(1004), "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementModals",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("03f0a0e7-b1d8-475d-b7b8-afe4f2729b56"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2e89b49c-0b3a-4049-a93d-4c205e7ebcc7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("62de6972-6b42-4b5f-b28f-90c4f6fc28f9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8640ec19-a7db-4e69-afa4-6eef890f189f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d9d14231-aaeb-43ff-80a5-a55069f0061f"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("557386ad-9208-4c14-b33c-adc91fec3975"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4923), "King", null },
                    { new Guid("6e805c94-bbbc-429a-a5a3-ece37acf85e5"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4966), "Admin", null },
                    { new Guid("89d1374c-3063-49ae-8fa8-c7a227e88730"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4980), "Client", null },
                    { new Guid("9638e388-b771-41b5-a1ed-4f1e15b5f82a"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4985), "User", null },
                    { new Guid("b931c0e0-6355-4ce8-aee2-9fb134c1be19"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4960), "SuperAdmin", null }
                });
        }
    }
}
