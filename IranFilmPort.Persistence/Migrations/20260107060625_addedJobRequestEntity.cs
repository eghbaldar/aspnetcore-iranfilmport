using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedJobRequestEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0fb23b8a-2036-4345-8eb2-7c4955354edd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4c4641a1-04a3-4017-b60c-7a28159262d9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4d7980b8-726f-4176-9188-86a5a1100cd5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5bef0858-b3d7-4d39-9ae3-3c0e98f3020c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bf78bf88-13f7-439d-a61f-b2600089e19c"));

            migrationBuilder.AddColumn<string>(
                name: "IP",
                schema: "dbo",
                table: "SendInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "JobRequests",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequests", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("557386ad-9208-4c14-b33c-adc91fec3975"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4923), "King", null },
                    { new Guid("6e805c94-bbbc-429a-a5a3-ece37acf85e5"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4966), "Admin", null },
                    { new Guid("89d1374c-3063-49ae-8fa8-c7a227e88730"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4980), "Client", null },
                    { new Guid("9638e388-b771-41b5-a1ed-4f1e15b5f82a"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4985), "User", null },
                    { new Guid("b931c0e0-6355-4ce8-aee2-9fb134c1be19"), null, new DateTime(2026, 1, 7, 9, 36, 25, 217, DateTimeKind.Local).AddTicks(4960), "SuperAdmin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobRequests",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("557386ad-9208-4c14-b33c-adc91fec3975"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6e805c94-bbbc-429a-a5a3-ece37acf85e5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("89d1374c-3063-49ae-8fa8-c7a227e88730"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9638e388-b771-41b5-a1ed-4f1e15b5f82a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b931c0e0-6355-4ce8-aee2-9fb134c1be19"));

            migrationBuilder.DropColumn(
                name: "IP",
                schema: "dbo",
                table: "SendInformation");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("0fb23b8a-2036-4345-8eb2-7c4955354edd"), null, new DateTime(2026, 1, 6, 17, 2, 3, 258, DateTimeKind.Local).AddTicks(9885), "Admin", null },
                    { new Guid("4c4641a1-04a3-4017-b60c-7a28159262d9"), null, new DateTime(2026, 1, 6, 17, 2, 3, 258, DateTimeKind.Local).AddTicks(9828), "King", null },
                    { new Guid("4d7980b8-726f-4176-9188-86a5a1100cd5"), null, new DateTime(2026, 1, 6, 17, 2, 3, 258, DateTimeKind.Local).AddTicks(9890), "Client", null },
                    { new Guid("5bef0858-b3d7-4d39-9ae3-3c0e98f3020c"), null, new DateTime(2026, 1, 6, 17, 2, 3, 258, DateTimeKind.Local).AddTicks(9897), "User", null },
                    { new Guid("bf78bf88-13f7-439d-a61f-b2600089e19c"), null, new DateTime(2026, 1, 6, 17, 2, 3, 258, DateTimeKind.Local).AddTicks(9880), "SuperAdmin", null }
                });
        }
    }
}
