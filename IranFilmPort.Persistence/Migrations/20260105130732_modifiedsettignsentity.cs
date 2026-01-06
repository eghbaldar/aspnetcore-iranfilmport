using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedsettignsentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "WinApp",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Marquee",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DollarToRial",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CommissionForFree",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ComissionForFee",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApkStuff",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApkClient",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("08ab78c0-079f-4af4-9117-093415dcd165"), null, new DateTime(2026, 1, 5, 16, 37, 31, 787, DateTimeKind.Local).AddTicks(192), "User", null },
                    { new Guid("3f8ea82e-5cf3-4334-8424-85841dbde5a2"), null, new DateTime(2026, 1, 5, 16, 37, 31, 787, DateTimeKind.Local).AddTicks(110), "Admin", null },
                    { new Guid("6d14054b-31b2-4508-b206-2432b275526d"), null, new DateTime(2026, 1, 5, 16, 37, 31, 787, DateTimeKind.Local).AddTicks(56), "King", null },
                    { new Guid("dad752bc-1202-41ce-862f-92d238849faf"), null, new DateTime(2026, 1, 5, 16, 37, 31, 787, DateTimeKind.Local).AddTicks(104), "SuperAdmin", null },
                    { new Guid("eb849dc8-fc0c-4b33-8d9c-12af4281ab5a"), null, new DateTime(2026, 1, 5, 16, 37, 31, 787, DateTimeKind.Local).AddTicks(171), "Client", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("08ab78c0-079f-4af4-9117-093415dcd165"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3f8ea82e-5cf3-4334-8424-85841dbde5a2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d14054b-31b2-4508-b206-2432b275526d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dad752bc-1202-41ce-862f-92d238849faf"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("eb849dc8-fc0c-4b33-8d9c-12af4281ab5a"));

            migrationBuilder.AlterColumn<string>(
                name: "WinApp",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Marquee",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DollarToRial",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommissionForFree",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComissionForFee",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApkStuff",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApkClient",
                schema: "dbo",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
