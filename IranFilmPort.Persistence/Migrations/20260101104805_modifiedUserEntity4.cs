using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserEntity4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("23ac6261-e38c-4d9d-b1fe-76697a8199f8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6405982a-6626-4e3c-b676-fba6980e9ac2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b0836028-d42b-44f8-9a67-36a73c332475"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c18198fc-1c06-498a-b8f9-b598a3ab7d8e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("deb98172-c1fa-408d-bf3b-fb5e17e6f53c"));

            migrationBuilder.AddColumn<byte>(
                name: "Position",
                schema: "dbo",
                table: "Users",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("31d9c7e7-8707-498c-9dd1-0497f55e725b"), null, new DateTime(2026, 1, 1, 14, 18, 3, 169, DateTimeKind.Local).AddTicks(865), "SuperAdmin", null },
                    { new Guid("4705f784-6634-4c2b-88e4-16e817805948"), null, new DateTime(2026, 1, 1, 14, 18, 3, 169, DateTimeKind.Local).AddTicks(826), "King", null },
                    { new Guid("55cda1e8-372a-46ed-a29b-dba237af43f1"), null, new DateTime(2026, 1, 1, 14, 18, 3, 169, DateTimeKind.Local).AddTicks(872), "Admin", null },
                    { new Guid("6872d361-6412-45ad-8dd1-4bea4a683eeb"), null, new DateTime(2026, 1, 1, 14, 18, 3, 169, DateTimeKind.Local).AddTicks(884), "User", null },
                    { new Guid("6e4f3615-8526-43f4-9ba3-452cd3f7b742"), null, new DateTime(2026, 1, 1, 14, 18, 3, 169, DateTimeKind.Local).AddTicks(876), "Client", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("31d9c7e7-8707-498c-9dd1-0497f55e725b"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4705f784-6634-4c2b-88e4-16e817805948"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("55cda1e8-372a-46ed-a29b-dba237af43f1"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6872d361-6412-45ad-8dd1-4bea4a683eeb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6e4f3615-8526-43f4-9ba3-452cd3f7b742"));

            migrationBuilder.DropColumn(
                name: "Position",
                schema: "dbo",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("23ac6261-e38c-4d9d-b1fe-76697a8199f8"), null, new DateTime(2026, 1, 1, 12, 54, 16, 777, DateTimeKind.Local).AddTicks(1588), "King", null },
                    { new Guid("6405982a-6626-4e3c-b676-fba6980e9ac2"), null, new DateTime(2026, 1, 1, 12, 54, 16, 777, DateTimeKind.Local).AddTicks(1656), "User", null },
                    { new Guid("b0836028-d42b-44f8-9a67-36a73c332475"), null, new DateTime(2026, 1, 1, 12, 54, 16, 777, DateTimeKind.Local).AddTicks(1630), "SuperAdmin", null },
                    { new Guid("c18198fc-1c06-498a-b8f9-b598a3ab7d8e"), null, new DateTime(2026, 1, 1, 12, 54, 16, 777, DateTimeKind.Local).AddTicks(1635), "Admin", null },
                    { new Guid("deb98172-c1fa-408d-bf3b-fb5e17e6f53c"), null, new DateTime(2026, 1, 1, 12, 54, 16, 777, DateTimeKind.Local).AddTicks(1651), "Client", null }
                });
        }
    }
}
