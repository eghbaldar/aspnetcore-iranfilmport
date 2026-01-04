using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifieduserentity7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("14321489-0574-4787-a87a-9b9a738cbc10"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2a82783a-590f-4711-bed1-509b0d67ae3a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7416f702-2204-455d-a8bb-6318f703a008"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c7de9877-6321-484d-8f57-c2b7d1fac2e3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d0277bf6-776f-4efb-ba6a-690f6e23bd5e"));

            migrationBuilder.AddColumn<int>(
                name: "UniqueCode",
                schema: "dbo",
                table: "UserProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "dbo",
                table: "UserProjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_UserId",
                schema: "dbo",
                table: "UserProjects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Users_UserId",
                schema: "dbo",
                table: "UserProjects",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Users_UserId",
                schema: "dbo",
                table: "UserProjects");

            migrationBuilder.DropIndex(
                name: "IX_UserProjects_UserId",
                schema: "dbo",
                table: "UserProjects");

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

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                schema: "dbo",
                table: "UserProjects");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "UserProjects");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("14321489-0574-4787-a87a-9b9a738cbc10"), null, new DateTime(2026, 1, 1, 18, 36, 26, 286, DateTimeKind.Local).AddTicks(1443), "Client", null },
                    { new Guid("2a82783a-590f-4711-bed1-509b0d67ae3a"), null, new DateTime(2026, 1, 1, 18, 36, 26, 286, DateTimeKind.Local).AddTicks(1436), "Admin", null },
                    { new Guid("7416f702-2204-455d-a8bb-6318f703a008"), null, new DateTime(2026, 1, 1, 18, 36, 26, 286, DateTimeKind.Local).AddTicks(1451), "User", null },
                    { new Guid("c7de9877-6321-484d-8f57-c2b7d1fac2e3"), null, new DateTime(2026, 1, 1, 18, 36, 26, 286, DateTimeKind.Local).AddTicks(1315), "King", null },
                    { new Guid("d0277bf6-776f-4efb-ba6a-690f6e23bd5e"), null, new DateTime(2026, 1, 1, 18, 36, 26, 286, DateTimeKind.Local).AddTicks(1359), "SuperAdmin", null }
                });
        }
    }
}
