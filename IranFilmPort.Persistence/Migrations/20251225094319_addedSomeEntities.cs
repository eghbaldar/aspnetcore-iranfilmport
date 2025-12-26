using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedSomeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3b3788dc-2110-4093-bb73-fe67e5d1ad26"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7f9672f2-468a-4ac2-b391-20fa1e410ecc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b8ea90ed-d5fc-4713-bc1a-749c91463930"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c591431e-dcda-4a96-ad70-732527c91bb4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ded6774a-6a6e-4b0f-b6e9-74c2b1487837"));

            migrationBuilder.CreateTable(
                name: "UserRefreshToken",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRevoke = table.Column<bool>(type: "bit", nullable: false),
                    Exp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersLogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auth = table.Column<bool>(type: "bit", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersLogs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersSuspicious",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSuspicious", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersSuspicious_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("0bd3acfc-198f-4966-96b6-a44e94b2e456"), null, new DateTime(2025, 12, 25, 13, 13, 19, 402, DateTimeKind.Local).AddTicks(1379), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59ee2340-e9bc-4467-8328-ebb7884354c9"), null, new DateTime(2025, 12, 25, 13, 13, 19, 402, DateTimeKind.Local).AddTicks(1327), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("90d98fbe-97a0-4f0a-9e72-993c1203b2ed"), null, new DateTime(2025, 12, 25, 13, 13, 19, 402, DateTimeKind.Local).AddTicks(1401), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c284d07c-fbcb-40b7-af95-4d99142d4661"), null, new DateTime(2025, 12, 25, 13, 13, 19, 402, DateTimeKind.Local).AddTicks(1373), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("edb0b16a-cd59-40af-94a3-08c7c7f7cad5"), null, new DateTime(2025, 12, 25, 13, 13, 19, 402, DateTimeKind.Local).AddTicks(1384), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshToken_UserId",
                schema: "dbo",
                table: "UserRefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLogs_UserId",
                schema: "dbo",
                table: "UsersLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSuspicious_UsersId",
                schema: "dbo",
                table: "UsersSuspicious",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshToken",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsersLogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsersSuspicious",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0bd3acfc-198f-4966-96b6-a44e94b2e456"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("59ee2340-e9bc-4467-8328-ebb7884354c9"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("90d98fbe-97a0-4f0a-9e72-993c1203b2ed"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c284d07c-fbcb-40b7-af95-4d99142d4661"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("edb0b16a-cd59-40af-94a3-08c7c7f7cad5"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("3b3788dc-2110-4093-bb73-fe67e5d1ad26"), null, new DateTime(2025, 12, 24, 13, 39, 30, 359, DateTimeKind.Local).AddTicks(1775), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7f9672f2-468a-4ac2-b391-20fa1e410ecc"), null, new DateTime(2025, 12, 24, 13, 39, 30, 359, DateTimeKind.Local).AddTicks(1911), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8ea90ed-d5fc-4713-bc1a-749c91463930"), null, new DateTime(2025, 12, 24, 13, 39, 30, 359, DateTimeKind.Local).AddTicks(1916), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c591431e-dcda-4a96-ad70-732527c91bb4"), null, new DateTime(2025, 12, 24, 13, 39, 30, 359, DateTimeKind.Local).AddTicks(1888), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ded6774a-6a6e-4b0f-b6e9-74c2b1487837"), null, new DateTime(2025, 12, 24, 13, 39, 30, 359, DateTimeKind.Local).AddTicks(1895), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
