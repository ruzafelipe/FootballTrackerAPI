using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorClubEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Club",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Club",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Club",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundedAt",
                table: "Club",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Club",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Club",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Club",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Club",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "FoundedAt",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Club");
        }
    }
}
