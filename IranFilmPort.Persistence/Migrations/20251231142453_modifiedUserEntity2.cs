using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("192c186f-8b63-4faa-bc0b-2b07287a5295"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("23f12ee0-fa58-4dd3-8880-fb38d582a6ed"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("47d5449d-67f3-4107-b58a-b68e38e7583f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5d3aaa55-d0d6-4d4f-b1cf-9e4839e5e687"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8208e70e-b1cb-4bc9-93da-144fe2a31df2"));

            migrationBuilder.RenameColumn(
                name: "MeliCardFile",
                schema: "dbo",
                table: "Users",
                newName: "MeliCard");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Resume_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMDb",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(220)",
                maxLength: 220,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("27ee87d6-76f9-4f5a-8b36-057e5952ea91"), null, new DateTime(2025, 12, 31, 17, 54, 53, 234, DateTimeKind.Local).AddTicks(3930), "Client", null },
                    { new Guid("a25e1cd2-ea23-47e1-93dc-c0d4d0f7d51f"), null, new DateTime(2025, 12, 31, 17, 54, 53, 234, DateTimeKind.Local).AddTicks(3880), "King", null },
                    { new Guid("b8377c03-85eb-4c4c-8266-1f1e2497b0ba"), null, new DateTime(2025, 12, 31, 17, 54, 53, 234, DateTimeKind.Local).AddTicks(3918), "SuperAdmin", null },
                    { new Guid("d235142a-c82a-483f-afe8-0d72e695f730"), null, new DateTime(2025, 12, 31, 17, 54, 53, 234, DateTimeKind.Local).AddTicks(3944), "User", null },
                    { new Guid("e26b2228-2b5e-41c2-b390-f27bbf936dec"), null, new DateTime(2025, 12, 31, 17, 54, 53, 234, DateTimeKind.Local).AddTicks(3924), "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("27ee87d6-76f9-4f5a-8b36-057e5952ea91"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a25e1cd2-ea23-47e1-93dc-c0d4d0f7d51f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b8377c03-85eb-4c4c-8266-1f1e2497b0ba"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d235142a-c82a-483f-afe8-0d72e695f730"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e26b2228-2b5e-41c2-b390-f27bbf936dec"));

            migrationBuilder.RenameColumn(
                name: "MeliCard",
                schema: "dbo",
                table: "Users",
                newName: "MeliCardFile");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Twitter",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Resume_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Lastname_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMDb",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(220)",
                oldMaxLength: 220,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("192c186f-8b63-4faa-bc0b-2b07287a5295"), null, new DateTime(2025, 12, 31, 17, 41, 52, 526, DateTimeKind.Local).AddTicks(2183), "SuperAdmin", null },
                    { new Guid("23f12ee0-fa58-4dd3-8880-fb38d582a6ed"), null, new DateTime(2025, 12, 31, 17, 41, 52, 526, DateTimeKind.Local).AddTicks(2203), "Client", null },
                    { new Guid("47d5449d-67f3-4107-b58a-b68e38e7583f"), null, new DateTime(2025, 12, 31, 17, 41, 52, 526, DateTimeKind.Local).AddTicks(2207), "User", null },
                    { new Guid("5d3aaa55-d0d6-4d4f-b1cf-9e4839e5e687"), null, new DateTime(2025, 12, 31, 17, 41, 52, 526, DateTimeKind.Local).AddTicks(2190), "Admin", null },
                    { new Guid("8208e70e-b1cb-4bc9-93da-144fe2a31df2"), null, new DateTime(2025, 12, 31, 17, 41, 52, 526, DateTimeKind.Local).AddTicks(2134), "King", null }
                });
        }
    }
}
