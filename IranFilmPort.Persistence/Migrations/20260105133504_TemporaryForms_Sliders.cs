using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TemporaryForms_Sliders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Sliders",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemporaryForms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporaryForms", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("1616a33b-e4ff-4fe8-a877-361b5be19ef9"), null, new DateTime(2026, 1, 5, 17, 5, 3, 213, DateTimeKind.Local).AddTicks(4213), "Admin", null },
                    { new Guid("47fcd162-df49-49d4-ae55-4f4bd240877e"), null, new DateTime(2026, 1, 5, 17, 5, 3, 213, DateTimeKind.Local).AddTicks(4207), "SuperAdmin", null },
                    { new Guid("746ef936-8fb6-4236-b36a-bd19401b2834"), null, new DateTime(2026, 1, 5, 17, 5, 3, 213, DateTimeKind.Local).AddTicks(4234), "User", null },
                    { new Guid("956722e3-b126-4af7-8a8b-74f313443c6e"), null, new DateTime(2026, 1, 5, 17, 5, 3, 213, DateTimeKind.Local).AddTicks(4229), "Client", null },
                    { new Guid("c9a124ec-0d49-4cfc-9562-5f0c4d262ba3"), null, new DateTime(2026, 1, 5, 17, 5, 3, 213, DateTimeKind.Local).AddTicks(4162), "King", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TemporaryForms",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1616a33b-e4ff-4fe8-a877-361b5be19ef9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("47fcd162-df49-49d4-ae55-4f4bd240877e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("746ef936-8fb6-4236-b36a-bd19401b2834"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("956722e3-b126-4af7-8a8b-74f313443c6e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9a124ec-0d49-4cfc-9562-5f0c4d262ba3"));

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
    }
}
