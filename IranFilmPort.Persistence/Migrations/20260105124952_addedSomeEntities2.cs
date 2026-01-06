using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedSomeEntities2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DollarToRial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComissionForFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionForFree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApkStuff = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApkClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WinApp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marquee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModalOnAllPage = table.Column<bool>(type: "bit", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("03a2498c-9e29-4b68-ad70-b3a6d6fc8704"), null, new DateTime(2026, 1, 5, 16, 19, 51, 309, DateTimeKind.Local).AddTicks(7394), "King", null },
                    { new Guid("42df6a6b-b46e-4b62-9abf-26989881ecd2"), null, new DateTime(2026, 1, 5, 16, 19, 51, 309, DateTimeKind.Local).AddTicks(7498), "Client", null },
                    { new Guid("50a1d9f7-cf16-4a5b-9fe5-6842030b2a7a"), null, new DateTime(2026, 1, 5, 16, 19, 51, 309, DateTimeKind.Local).AddTicks(7454), "SuperAdmin", null },
                    { new Guid("602d1090-d8e2-4f61-b996-edab602d1124"), null, new DateTime(2026, 1, 5, 16, 19, 51, 309, DateTimeKind.Local).AddTicks(7463), "Admin", null },
                    { new Guid("f8f98220-8375-4ebf-b8c7-62201feceffd"), null, new DateTime(2026, 1, 5, 16, 19, 51, 309, DateTimeKind.Local).AddTicks(7511), "User", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("03a2498c-9e29-4b68-ad70-b3a6d6fc8704"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("42df6a6b-b46e-4b62-9abf-26989881ecd2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("50a1d9f7-cf16-4a5b-9fe5-6842030b2a7a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("602d1090-d8e2-4f61-b996-edab602d1124"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f8f98220-8375-4ebf-b8c7-62201feceffd"));

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
    }
}
