using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVisitIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitedAt",
                table: "Visits",
                column: "VisitedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visits_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_VisitedAt",
                table: "Visits");
        }
    }
}
