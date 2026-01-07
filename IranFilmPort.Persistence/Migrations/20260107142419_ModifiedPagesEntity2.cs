using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IranFilmPort.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedPagesEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2dcc5aca-baaf-4523-8703-4933e38b984d"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6ac316ba-b2c9-49f0-938b-c4c8a6881467"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c18d806a-099b-4c3c-8a3b-2a4497f79b93"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d7bffb17-12c5-403b-a996-22189b9e6d51"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f9755536-efd2-4af2-9849-83eb1827463d"));

            migrationBuilder.DropColumn(
                name: "Resume",
                schema: "dbo",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "ResumeEN",
                schema: "dbo",
                table: "Pages",
                newName: "ResumeEn");

            migrationBuilder.AlterColumn<string>(
                name: "ScriptFa",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ResumeEn",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ParticipatePlan",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Features",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AgentsFa",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AgentsEn",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Advertisements",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AboutFa",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AboutEn",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ResumeFa",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("3fa19e77-4f87-43f9-8f94-03662b8356be"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7884), "SuperAdmin", null },
                    { new Guid("5a90bbdf-7aef-44cb-9401-419b10d1d56a"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7827), "King", null },
                    { new Guid("761203ff-3c1a-4bc0-9225-d86ed04c3a4c"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7899), "User", null },
                    { new Guid("8f2ead31-e380-4093-b332-600d435a09d5"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7895), "Client", null },
                    { new Guid("a2c753fd-05c6-435c-94b4-8683d1e7be40"), null, new DateTime(2026, 1, 7, 17, 54, 18, 499, DateTimeKind.Local).AddTicks(7890), "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3fa19e77-4f87-43f9-8f94-03662b8356be"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5a90bbdf-7aef-44cb-9401-419b10d1d56a"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("761203ff-3c1a-4bc0-9225-d86ed04c3a4c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8f2ead31-e380-4093-b332-600d435a09d5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a2c753fd-05c6-435c-94b4-8683d1e7be40"));

            migrationBuilder.DropColumn(
                name: "ResumeFa",
                schema: "dbo",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "ResumeEn",
                schema: "dbo",
                table: "Pages",
                newName: "ResumeEN");

            migrationBuilder.AlterColumn<string>(
                name: "ScriptFa",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResumeEN",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParticipatePlan",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Features",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentsFa",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AgentsEn",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Advertisements",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutFa",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AboutEn",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                schema: "dbo",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "DeleteDateTime", "InsertDateTime", "Title", "UpdateDateTime" },
                values: new object[,]
                {
                    { new Guid("2dcc5aca-baaf-4523-8703-4933e38b984d"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3227), "King", null },
                    { new Guid("6ac316ba-b2c9-49f0-938b-c4c8a6881467"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3299), "Client", null },
                    { new Guid("c18d806a-099b-4c3c-8a3b-2a4497f79b93"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3280), "Admin", null },
                    { new Guid("d7bffb17-12c5-403b-a996-22189b9e6d51"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3274), "SuperAdmin", null },
                    { new Guid("f9755536-efd2-4af2-9849-83eb1827463d"), null, new DateTime(2026, 1, 7, 17, 36, 8, 808, DateTimeKind.Local).AddTicks(3303), "User", null }
                });
        }
    }
}
