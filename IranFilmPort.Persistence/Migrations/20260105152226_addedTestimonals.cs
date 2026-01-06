using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedTestimonals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Testimonials",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("2684988f-829a-415b-bb6d-6cad828acbe8"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6505), "King", null },
                    { new Guid("29d681e7-ae48-462c-8fec-16345313dcfb"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6569), "User", null },
                    { new Guid("3da56702-909c-4d76-b6df-29ce000cccbb"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6562), "Client", null },
                    { new Guid("8734affc-79ab-43c1-99c6-a954766b4f9e"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6551), "SuperAdmin", null },
                    { new Guid("c6521bea-1b94-4e16-8e21-7e3db8aa13f5"), null, new DateTime(2026, 1, 5, 18, 52, 26, 185, DateTimeKind.Local).AddTicks(6558), "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testimonials",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2684988f-829a-415b-bb6d-6cad828acbe8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("29d681e7-ae48-462c-8fec-16345313dcfb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3da56702-909c-4d76-b6df-29ce000cccbb"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8734affc-79ab-43c1-99c6-a954766b4f9e"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c6521bea-1b94-4e16-8e21-7e3db8aa13f5"));

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
    }
}
