using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedFestivalEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("154850e0-84c5-43ab-bc66-8489e83e35c3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3cf5c248-ed04-4579-8ca4-3175ed4d6c7f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7e7919e8-1990-4db7-9698-063476483f5d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ab0f4bd6-bda8-4baa-bc47-3f11b024e138"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dad2573b-9de5-4872-9491-4328d48615ce"));

            migrationBuilder.CreateTable(
                name: "Festivals",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortFeature = table.Column<byte>(type: "tinyint", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleFa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<byte>(type: "tinyint", nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attribute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Premiere = table.Column<byte>(type: "tinyint", nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<byte>(type: "tinyint", nullable: false),
                    Submitway = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FestivalSections",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FestivalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FestivalSections_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalSchema: "dbo",
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FestivalDeadlines",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FestivalSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fee = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FestivalDeadlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FestivalDeadlines_FestivalSections_FestivalSectionId",
                        column: x => x.FestivalSectionId,
                        principalSchema: "dbo",
                        principalTable: "FestivalSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("0f96b598-9c41-41f8-9c9f-0de4823c5b17"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1386), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("49a0b5ce-dee3-4477-8f26-a88bfb84cee7"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1392), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4e0bd103-2834-4160-808e-85ae87ac3539"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1367), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("97ea0939-a26e-4bc7-9b13-2c7212f60229"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1324), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c73005fe-0254-4cf0-9a9e-3943f0c74dab"), null, new DateTime(2025, 12, 29, 9, 13, 36, 277, DateTimeKind.Local).AddTicks(1360), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FestivalDeadlines_FestivalSectionId",
                schema: "dbo",
                table: "FestivalDeadlines",
                column: "FestivalSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FestivalSections_FestivalId",
                schema: "dbo",
                table: "FestivalSections",
                column: "FestivalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FestivalDeadlines",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FestivalSections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Festivals",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0f96b598-9c41-41f8-9c9f-0de4823c5b17"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("49a0b5ce-dee3-4477-8f26-a88bfb84cee7"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4e0bd103-2834-4160-808e-85ae87ac3539"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("97ea0939-a26e-4bc7-9b13-2c7212f60229"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c73005fe-0254-4cf0-9a9e-3943f0c74dab"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("154850e0-84c5-43ab-bc66-8489e83e35c3"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(235), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3cf5c248-ed04-4579-8ca4-3175ed4d6c7f"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(303), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7e7919e8-1990-4db7-9698-063476483f5d"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(284), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab0f4bd6-bda8-4baa-bc47-3f11b024e138"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(307), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dad2573b-9de5-4872-9491-4328d48615ce"), null, new DateTime(2025, 12, 28, 13, 33, 53, 91, DateTimeKind.Local).AddTicks(279), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
