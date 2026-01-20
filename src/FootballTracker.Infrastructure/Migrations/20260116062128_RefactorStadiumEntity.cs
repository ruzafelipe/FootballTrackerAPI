using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorStadiumEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Stadium",
                keyColumn: "City",
                keyValue: null,
                column: "City",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Stadium",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Stadium",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Stadium",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Stadium",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Stadium",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenedDate",
                table: "Stadium",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Stadium",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Stadium",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Stadium",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stadium_City",
                table: "Stadium",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Stadium_Name",
                table: "Stadium",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stadium_City",
                table: "Stadium");

            migrationBuilder.DropIndex(
                name: "IX_Stadium_Name",
                table: "Stadium");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Stadium");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Stadium");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Stadium");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Stadium");

            migrationBuilder.DropColumn(
                name: "OpenedDate",
                table: "Stadium");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Stadium");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Stadium");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Stadium");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Stadium",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
