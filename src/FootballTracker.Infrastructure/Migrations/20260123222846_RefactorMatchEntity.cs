using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorMatchEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApprovedOrRejectedByUserId",
                table: "Matches",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "CompetitionId",
                table: "Matches",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Matches",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserId",
                table: "Matches",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Matches",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CompetitionId",
                table: "Matches",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchDate_StadiumId",
                table: "Matches",
                columns: new[] { "MatchDate", "StadiumId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Competitions_CompetitionId",
                table: "Matches",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Competitions_CompetitionId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CompetitionId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_MatchDate_StadiumId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ApprovedOrRejectedByUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Matches");
        }
    }
}
