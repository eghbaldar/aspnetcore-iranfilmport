using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeContactEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("2ff8bf84-894b-47a7-af40-498590d2a9e0"), null, new DateTime(2026, 1, 6, 16, 28, 57, 80, DateTimeKind.Local).AddTicks(9982), "King", null },
                    { new Guid("46a8a8e5-9f23-496a-b83d-6b823bbfa469"), null, new DateTime(2026, 1, 6, 16, 28, 57, 81, DateTimeKind.Local).AddTicks(53), "Client", null },
                    { new Guid("c02ce5af-3c50-485d-8765-c1438e3ecc5a"), null, new DateTime(2026, 1, 6, 16, 28, 57, 81, DateTimeKind.Local).AddTicks(31), "SuperAdmin", null },
                    { new Guid("ea72f172-ac4f-48a3-b747-02994d785768"), null, new DateTime(2026, 1, 6, 16, 28, 57, 81, DateTimeKind.Local).AddTicks(38), "Admin", null },
                    { new Guid("f97d0101-8a13-4ba2-bf23-2274365feab5"), null, new DateTime(2026, 1, 6, 16, 28, 57, 81, DateTimeKind.Local).AddTicks(58), "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2ff8bf84-894b-47a7-af40-498590d2a9e0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46a8a8e5-9f23-496a-b83d-6b823bbfa469"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c02ce5af-3c50-485d-8765-c1438e3ecc5a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ea72f172-ac4f-48a3-b747-02994d785768"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f97d0101-8a13-4ba2-bf23-2274365feab5"));

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Department = table.Column<byte>(type: "tinyint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
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
    }
}
