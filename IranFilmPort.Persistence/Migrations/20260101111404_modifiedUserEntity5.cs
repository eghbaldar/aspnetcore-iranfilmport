using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserEntity5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte>(
                name: "MainStatus",
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
                    { new Guid("491d6676-8d5a-4673-b59f-948edfafb499"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3932), "User", null },
                    { new Guid("adc74516-6740-4c2a-ab02-9efcfc43f570"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3921), "Admin", null },
                    { new Guid("b2617f8a-bb80-45db-9021-a1bd2cc1eec7"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3894), "SuperAdmin", null },
                    { new Guid("b8e84886-0ef4-4f1f-a78a-3cde2de9d0b8"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3927), "Client", null },
                    { new Guid("e35bc3b5-878d-4578-ab62-8a18cbee351f"), null, new DateTime(2026, 1, 1, 14, 44, 3, 872, DateTimeKind.Local).AddTicks(3857), "King", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("491d6676-8d5a-4673-b59f-948edfafb499"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("adc74516-6740-4c2a-ab02-9efcfc43f570"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2617f8a-bb80-45db-9021-a1bd2cc1eec7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b8e84886-0ef4-4f1f-a78a-3cde2de9d0b8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e35bc3b5-878d-4578-ab62-8a18cbee351f"));

            migrationBuilder.DropColumn(
                name: "MainStatus",
                schema: "dbo",
                table: "Users");

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
    }
}
