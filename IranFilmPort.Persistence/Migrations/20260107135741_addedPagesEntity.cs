using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedPagesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Pages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeAdvertisement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticipatePlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentsFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentsEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScriptFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages",
                schema: "dbo");

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
    }
}
