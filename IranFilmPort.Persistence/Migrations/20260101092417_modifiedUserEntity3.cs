using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedUserEntity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Idenitifcation",
                schema: "dbo",
                table: "Users",
                newName: "MeliCardStatus");

            migrationBuilder.AddColumn<byte>(
                name: "HeadshotStatus",
                schema: "dbo",
                table: "Users",
                type: "tinyint",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "HeadshotStatus",
                schema: "dbo",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "MeliCardStatus",
                schema: "dbo",
                table: "Users",
                newName: "Idenitifcation");

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
    }
}
