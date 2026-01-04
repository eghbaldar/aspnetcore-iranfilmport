using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5dd081f3-df83-4ab1-adce-6bebd98bab00"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6a6fbbe0-dbe8-48b7-9961-2f3d5fbb7270"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9459429f-8d63-4886-87fb-5386742a55c7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("96c4abdd-5054-4e01-80c5-6f7df550a6c6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b179dc8f-577a-40d6-92d6-60a5dce68c47"));

            migrationBuilder.AddColumn<string>(
                name: "DetailEn",
                schema: "dbo",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirectorEn",
                schema: "dbo",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProduerEn",
                schema: "dbo",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WriterEn",
                schema: "dbo",
                table: "UserProjects",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DetailEn",
                schema: "dbo",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "DirectorEn",
                schema: "dbo",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "ProduerEn",
                schema: "dbo",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "WriterEn",
                schema: "dbo",
                table: "UserProjects");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("5dd081f3-df83-4ab1-adce-6bebd98bab00"), null, new DateTime(2026, 1, 3, 19, 0, 58, 931, DateTimeKind.Local).AddTicks(1141), "User", null },
                    { new Guid("6a6fbbe0-dbe8-48b7-9961-2f3d5fbb7270"), null, new DateTime(2026, 1, 3, 19, 0, 58, 931, DateTimeKind.Local).AddTicks(1114), "SuperAdmin", null },
                    { new Guid("9459429f-8d63-4886-87fb-5386742a55c7"), null, new DateTime(2026, 1, 3, 19, 0, 58, 931, DateTimeKind.Local).AddTicks(1132), "Admin", null },
                    { new Guid("96c4abdd-5054-4e01-80c5-6f7df550a6c6"), null, new DateTime(2026, 1, 3, 19, 0, 58, 931, DateTimeKind.Local).AddTicks(1069), "King", null },
                    { new Guid("b179dc8f-577a-40d6-92d6-60a5dce68c47"), null, new DateTime(2026, 1, 3, 19, 0, 58, 931, DateTimeKind.Local).AddTicks(1136), "Client", null }
                });
        }
    }
}
