using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedUserProjectEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("28e24f1c-fa28-427d-85d0-eb1fbea62944"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("430a307c-0b1f-4c07-b808-b7bf038fe02d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a4ce3392-04a5-4908-b780-29b4b8a44250"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df29e227-0dd7-457a-945d-405dd8e4a746"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("faf42f18-cf58-4b49-acb8-ef1d88379e2a"));

            migrationBuilder.CreateTable(
                name: "UserProjects",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    TitleFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SynopsisFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SynopsisEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Writer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Producer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genuine = table.Column<bool>(type: "bit", nullable: false),
                    ArtworkLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtworkPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProjectPhotos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    UserProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjectPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjectPhotos_UserProjects_UserProjectsId",
                        column: x => x.UserProjectsId,
                        principalSchema: "dbo",
                        principalTable: "UserProjects",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectPhotos_UserProjectsId",
                schema: "dbo",
                table: "UserProjectPhotos",
                column: "UserProjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProjectPhotos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserProjects",
                schema: "dbo");

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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("28e24f1c-fa28-427d-85d0-eb1fbea62944"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6088), "SuperAdmin", null },
                    { new Guid("430a307c-0b1f-4c07-b808-b7bf038fe02d"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6098), "Client", null },
                    { new Guid("a4ce3392-04a5-4908-b780-29b4b8a44250"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6047), "King", null },
                    { new Guid("df29e227-0dd7-457a-945d-405dd8e4a746"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6093), "Admin", null },
                    { new Guid("faf42f18-cf58-4b49-acb8-ef1d88379e2a"), null, new DateTime(2026, 1, 1, 14, 56, 26, 331, DateTimeKind.Local).AddTicks(6115), "User", null }
                });
        }
    }
}
