using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedAccoladesEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2684988f-829a-415b-bb6d-6cad828acbe8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("29d681e7-ae48-462c-8fec-16345313dcfb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3da56702-909c-4d76-b6df-29ce000cccbb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8734affc-79ab-43c1-99c6-a954766b4f9e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c6521bea-1b94-4e16-8e21-7e3db8aa13f5"));

            migrationBuilder.CreateTable(
                name: "Accolades",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<long>(type: "bigint", nullable: false),
                    AccoladeFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccoladeEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accolades", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("46e0bf46-1f4c-4483-af63-976fe3bd3435"), null, new DateTime(2026, 1, 6, 12, 26, 15, 824, DateTimeKind.Local).AddTicks(274), "User", null },
                    { new Guid("51857070-25af-4a88-81d1-80c8dbc215c9"), null, new DateTime(2026, 1, 6, 12, 26, 15, 824, DateTimeKind.Local).AddTicks(259), "Client", null },
                    { new Guid("6a2b02aa-3343-443d-b1e1-6830ea985ca7"), null, new DateTime(2026, 1, 6, 12, 26, 15, 824, DateTimeKind.Local).AddTicks(197), "King", null },
                    { new Guid("78f505f2-871d-4f74-941a-231bc5f039c4"), null, new DateTime(2026, 1, 6, 12, 26, 15, 824, DateTimeKind.Local).AddTicks(247), "SuperAdmin", null },
                    { new Guid("a494378f-96b6-49e0-b20b-4f96b87f095e"), null, new DateTime(2026, 1, 6, 12, 26, 15, 824, DateTimeKind.Local).AddTicks(253), "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accolades",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46e0bf46-1f4c-4483-af63-976fe3bd3435"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("51857070-25af-4a88-81d1-80c8dbc215c9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6a2b02aa-3343-443d-b1e1-6830ea985ca7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("78f505f2-871d-4f74-941a-231bc5f039c4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a494378f-96b6-49e0-b20b-4f96b87f095e"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("2684988f-829a-415b-bb6d-6cad828acbe8"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6505), "King", null },
                    { new Guid("29d681e7-ae48-462c-8fec-16345313dcfb"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6569), "User", null },
                    { new Guid("3da56702-909c-4d76-b6df-29ce000cccbb"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6562), "Client", null },
                    { new Guid("8734affc-79ab-43c1-99c6-a954766b4f9e"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6551), "SuperAdmin", null },
                    { new Guid("c6521bea-1b94-4e16-8e21-7e3db8aa13f5"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6558), "Admin", null }
                });
        }
    }
}
