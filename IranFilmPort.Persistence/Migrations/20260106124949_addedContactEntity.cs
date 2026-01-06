using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedContactEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("157be899-2b39-49ad-b06b-239f8b3fe549"), null, new DateTime(2026, 1, 6, 16, 19, 48, 822, DateTimeKind.Local).AddTicks(783), "User", null },
                    { new Guid("4a248546-b26c-4460-b670-f75aee2df544"), null, new DateTime(2026, 1, 6, 16, 19, 48, 822, DateTimeKind.Local).AddTicks(709), "King", null },
                    { new Guid("7e3a10e8-afee-4505-b1d4-c7e6770df184"), null, new DateTime(2026, 1, 6, 16, 19, 48, 822, DateTimeKind.Local).AddTicks(768), "Client", null },
                    { new Guid("a29b1bfb-2339-4140-9cbe-69e1f64965ca"), null, new DateTime(2026, 1, 6, 16, 19, 48, 822, DateTimeKind.Local).AddTicks(756), "SuperAdmin", null },
                    { new Guid("e58eadaf-796b-4c68-95bb-1e832423def9"), null, new DateTime(2026, 1, 6, 16, 19, 48, 822, DateTimeKind.Local).AddTicks(763), "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("157be899-2b39-49ad-b06b-239f8b3fe549"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a248546-b26c-4460-b670-f75aee2df544"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7e3a10e8-afee-4505-b1d4-c7e6770df184"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a29b1bfb-2339-4140-9cbe-69e1f64965ca"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e58eadaf-796b-4c68-95bb-1e832423def9"));

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
    }
}
