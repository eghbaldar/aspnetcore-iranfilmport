using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class somechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_CategoryId",
                schema: "dbo",
                table: "News");

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

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "News",
                newName: "NewsCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_News_CategoryId",
                schema: "dbo",
                table: "News",
                newName: "IX_News_NewsCategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FutureDateTime",
                schema: "dbo",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("5aabeadb-4f56-4787-bc6f-a253fbb548e3"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8683), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("75918b63-9d8d-46be-ad39-70da56d0bae4"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8725), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cbdcbd5e-7a94-4d0c-887d-db7cea7f8816"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8730), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea28ff58-c301-4084-b517-dcbf2e680a8d"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8753), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc031c5c-712d-4a9e-b7e3-5e3d9a9d570b"), null, new DateTime(2025, 12, 26, 21, 32, 1, 859, DateTimeKind.Local).AddTicks(8748), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                schema: "dbo",
                table: "News",
                column: "NewsCategoryId",
                principalSchema: "dbo",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                schema: "dbo",
                table: "News");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5aabeadb-4f56-4787-bc6f-a253fbb548e3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("75918b63-9d8d-46be-ad39-70da56d0bae4"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cbdcbd5e-7a94-4d0c-887d-db7cea7f8816"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ea28ff58-c301-4084-b517-dcbf2e680a8d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fc031c5c-712d-4a9e-b7e3-5e3d9a9d570b"));

            migrationBuilder.RenameColumn(
                name: "NewsCategoryId",
                schema: "dbo",
                table: "News",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_News_NewsCategoryId",
                schema: "dbo",
                table: "News",
                newName: "IX_News_CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FutureDateTime",
                schema: "dbo",
                table: "News",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                schema: "dbo",
                table: "News",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_CategoryId",
                schema: "dbo",
                table: "News",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "NewsCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
