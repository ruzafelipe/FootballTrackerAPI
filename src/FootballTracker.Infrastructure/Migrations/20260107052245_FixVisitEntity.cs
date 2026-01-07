using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixVisitEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Club_AwayClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Club_HomeClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadium_StadiumId",
                table: "Matches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stadium",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Stadium",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Club",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Club_AwayClubId",
                table: "Matches",
                column: "AwayClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Club_HomeClubId",
                table: "Matches",
                column: "HomeClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadium_StadiumId",
                table: "Matches",
                column: "StadiumId",
                principalTable: "Stadium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Club_AwayClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Club_HomeClubId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadium_StadiumId",
                table: "Matches");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stadium",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Stadium",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Club",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Club_AwayClubId",
                table: "Matches",
                column: "AwayClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Club_HomeClubId",
                table: "Matches",
                column: "HomeClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadium_StadiumId",
                table: "Matches",
                column: "StadiumId",
                principalTable: "Stadium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
