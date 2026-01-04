using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifidUserProjects2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22641185-7e9c-4d1a-b9c0-85b49bf89f58"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c24e8f1-4030-436b-94c6-07940379798d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("782dce4c-f9e5-420a-956a-2e8f2a888ccb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d46d5023-07a7-408b-a070-09cc48708efe"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ee1cc6f5-8373-439c-8ebd-74efeea1b36a"));

            migrationBuilder.AddColumn<int>(
                name: "Visit",
                schema: "dbo",
                table: "UserProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Visit",
                schema: "dbo",
                table: "UserProjects");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("22641185-7e9c-4d1a-b9c0-85b49bf89f58"), null, new DateTime(2026, 1, 3, 17, 37, 8, 814, DateTimeKind.Local).AddTicks(4663), "SuperAdmin", null },
                    { new Guid("4c24e8f1-4030-436b-94c6-07940379798d"), null, new DateTime(2026, 1, 3, 17, 37, 8, 814, DateTimeKind.Local).AddTicks(4672), "Client", null },
                    { new Guid("782dce4c-f9e5-420a-956a-2e8f2a888ccb"), null, new DateTime(2026, 1, 3, 17, 37, 8, 814, DateTimeKind.Local).AddTicks(4608), "King", null },
                    { new Guid("d46d5023-07a7-408b-a070-09cc48708efe"), null, new DateTime(2026, 1, 3, 17, 37, 8, 814, DateTimeKind.Local).AddTicks(4677), "User", null },
                    { new Guid("ee1cc6f5-8373-439c-8ebd-74efeea1b36a"), null, new DateTime(2026, 1, 3, 17, 37, 8, 814, DateTimeKind.Local).AddTicks(4668), "Admin", null }
                });
        }
    }
}
