using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedCourseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2ff8bf84-894b-47a7-af40-498590d2a9e0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("46a8a8e5-9f23-496a-b83d-6b823bbfa469"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c02ce5af-3c50-485d-8765-c1438e3ecc5a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ea72f172-ac4f-48a3-b747-02994d785768"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f97d0101-8a13-4ba2-bf23-2274365feab5"));

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherHeadshot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses",
                schema: "dbo");

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("2ff8bf84-894b-47a7-af40-498590d2a9e0"), null, new DateTime(2026, 1, 6, 16, 28, 57, 80, DateTimeKind.Local).AddTicks(9982), "King", null },
                    { new Guid("46a8a8e5-9f23-496a-b83d-6b823bbfa469"), null, new DateTime(2026, 1, 6, 16, 28, 57, 81, DateTimeKind.Local).AddTicks(53), "Client", null },
                    { new Guid("c02ce5af-3c50-485d-8765-c1438e3ecc5a"), null, new DateTime(2026, 1, 6, 16, 28, 57, 81, DateTimeKind.Local).AddTicks(31), "SuperAdmin", null },
                    { new Guid("ea72f172-ac4f-48a3-b747-02994d785768"), null, new DateTime(2026, 1, 6, 16, 28, 57, 81, DateTimeKind.Local).AddTicks(38), "Admin", null },
                    { new Guid("f97d0101-8a13-4ba2-bf23-2274365feab5"), null, new DateTime(2026, 1, 6, 16, 28, 57, 81, DateTimeKind.Local).AddTicks(58), "User", null }
                });
        }
    }
}
