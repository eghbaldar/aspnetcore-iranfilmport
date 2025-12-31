using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class modifiedBaseEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("37d2924a-406a-45a8-92bc-7216a49009af"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5183bf43-fbf8-4eaf-8420-9b018bb36f55"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b96bc713-f26b-4f7b-aefd-5a4a093e5ea8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9b0a857-67be-45b8-be97-0734228e7982"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ec4a824d-404a-4f7e-89fc-1c6d07b6e9ae"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "UsersSuspicious",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "UsersLogs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "NewsTags",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Newsletters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "NewsComments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "NewsCategories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "News",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "FestivalSections",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Festivals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "FestivalDeadlines",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Countries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Contacts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("4aba8f8e-9782-4e63-8c55-f7d1f67b823d"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6708), "SuperAdmin", null },
                    { new Guid("7453bcd8-70df-4051-8713-f1e81fd81768"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6727), "Client", null },
                    { new Guid("882fbd4b-5c24-454a-a197-2a66331910e8"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6718), "Admin", null },
                    { new Guid("89185ff7-6a85-4893-a00a-e0497074bc44"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6800), "User", null },
                    { new Guid("9f90cd1f-49fe-465f-a2c8-e85a247f19bb"), null, new DateTime(2025, 12, 30, 10, 33, 11, 290, DateTimeKind.Local).AddTicks(6646), "King", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4aba8f8e-9782-4e63-8c55-f7d1f67b823d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7453bcd8-70df-4051-8713-f1e81fd81768"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("882fbd4b-5c24-454a-a197-2a66331910e8"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("89185ff7-6a85-4893-a00a-e0497074bc44"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9f90cd1f-49fe-465f-a2c8-e85a247f19bb"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "UsersSuspicious",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "UsersLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "NewsTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Newsletters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "NewsComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "NewsCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "FestivalSections",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Festivals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "FestivalDeadlines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Countries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "dbo",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("37d2924a-406a-45a8-92bc-7216a49009af"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6509), "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5183bf43-fbf8-4eaf-8420-9b018bb36f55"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6499), "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b96bc713-f26b-4f7b-aefd-5a4a093e5ea8"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6479), "SuperAdmin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9b0a857-67be-45b8-be97-0734228e7982"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6441), "King", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec4a824d-404a-4f7e-89fc-1c6d07b6e9ae"), null, new DateTime(2025, 12, 30, 10, 7, 1, 450, DateTimeKind.Local).AddTicks(6504), "Client", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
