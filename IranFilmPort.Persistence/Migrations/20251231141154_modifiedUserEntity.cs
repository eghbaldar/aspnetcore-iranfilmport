using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4aba8f8e-9782-4e63-8c55-f7d1f67b823d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7453bcd8-70df-4051-8713-f1e81fd81768"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("882fbd4b-5c24-454a-a197-2a66331910e8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("89185ff7-6a85-4893-a00a-e0497074bc44"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9f90cd1f-49fe-465f-a2c8-e85a247f19bb"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Degree",
                schema: "dbo",
                table: "Users",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DegreeField",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Email_Visibility",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Headshot",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMDb",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Idenitifcation",
                schema: "dbo",
                table: "Users",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeliCardFile",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Phone_Visibility",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resume_En",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Birthday",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Degree",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DegreeField",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email_Visibility",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Facebook",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Firstname_En",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Headshot",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IMDb",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Idenitifcation",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Instagram",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lastname_En",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MeliCardFile",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone_Visibility",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Resume",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Resume_En",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Twitter",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Website",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "Users",
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
                    { new Guid("4aba8f8e-9782-4e63-8c55-f7d1f67b823d"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6708), "SuperAdmin", null },
                    { new Guid("7453bcd8-70df-4051-8713-f1e81fd81768"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6727), "Client", null },
                    { new Guid("882fbd4b-5c24-454a-a197-2a66331910e8"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6718), "Admin", null },
                    { new Guid("89185ff7-6a85-4893-a00a-e0497074bc44"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6800), "User", null },
                    { new Guid("9f90cd1f-49fe-465f-a2c8-e85a247f19bb"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6646), "King", null }
                });
        }
    }
}
