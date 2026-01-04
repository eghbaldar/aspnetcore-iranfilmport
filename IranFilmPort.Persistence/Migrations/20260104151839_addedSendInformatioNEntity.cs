using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedSendInformatioNEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4675b539-2dc9-4aa9-8cba-f50a2e772205"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("528f82c6-0398-4d17-abe0-4c1ed141dec9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66da987f-e6b0-403a-9441-902eccd9638a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7451c35a-bf01-4d00-a4f5-21a1f26b867e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8b0b6cae-32c9-4c56-a64e-95dc9c6f7c2f"));

            migrationBuilder.CreateTable(
                name: "SendInformation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhichWay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendInformation", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("1643dcdd-5c59-451c-b906-5c9d121dcabd"), null, new DateTime(2026, 1, 4, 18, 48, 38, 826, DateTimeKind.Local).AddTicks(9940), "Admin", null },
                    { new Guid("2068d78d-5fdf-406e-bd0a-b62880267d3f"), null, new DateTime(2026, 1, 4, 18, 48, 38, 826, DateTimeKind.Local).AddTicks(9891), "King", null },
                    { new Guid("37cdd4cf-0385-432a-b6d9-eddcb5e8bacf"), null, new DateTime(2026, 1, 4, 18, 48, 38, 826, DateTimeKind.Local).AddTicks(9934), "SuperAdmin", null },
                    { new Guid("71f77be8-f47a-4392-b7d5-72b28ef3a941"), null, new DateTime(2026, 1, 4, 18, 48, 38, 826, DateTimeKind.Local).AddTicks(9958), "Client", null },
                    { new Guid("b6037046-b6c7-4db0-9647-52f89c980e22"), null, new DateTime(2026, 1, 4, 18, 48, 38, 826, DateTimeKind.Local).AddTicks(9963), "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendInformation",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1643dcdd-5c59-451c-b906-5c9d121dcabd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2068d78d-5fdf-406e-bd0a-b62880267d3f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("37cdd4cf-0385-432a-b6d9-eddcb5e8bacf"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("71f77be8-f47a-4392-b7d5-72b28ef3a941"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b6037046-b6c7-4db0-9647-52f89c980e22"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("4675b539-2dc9-4aa9-8cba-f50a2e772205"), null, new DateTime(2026, 1, 4, 11, 21, 16, 454, DateTimeKind.Local).AddTicks(6554), "Client", null },
                    { new Guid("528f82c6-0398-4d17-abe0-4c1ed141dec9"), null, new DateTime(2026, 1, 4, 11, 21, 16, 454, DateTimeKind.Local).AddTicks(6545), "SuperAdmin", null },
                    { new Guid("66da987f-e6b0-403a-9441-902eccd9638a"), null, new DateTime(2026, 1, 4, 11, 21, 16, 454, DateTimeKind.Local).AddTicks(6550), "Admin", null },
                    { new Guid("7451c35a-bf01-4d00-a4f5-21a1f26b867e"), null, new DateTime(2026, 1, 4, 11, 21, 16, 454, DateTimeKind.Local).AddTicks(6571), "User", null },
                    { new Guid("8b0b6cae-32c9-4c56-a64e-95dc9c6f7c2f"), null, new DateTime(2026, 1, 4, 11, 21, 16, 454, DateTimeKind.Local).AddTicks(6502), "King", null }
                });
        }
    }
}
