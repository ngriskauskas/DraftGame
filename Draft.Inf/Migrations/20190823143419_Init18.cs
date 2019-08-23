using Microsoft.EntityFrameworkCore.Migrations;

namespace Draft.Inf.Migrations
{
    public partial class Init18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StandingsId2",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArcTeams_StandingsId2",
                table: "ArcTeams",
                column: "StandingsId2");

            migrationBuilder.AddForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId2",
                table: "ArcTeams",
                column: "StandingsId2",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId2",
                table: "ArcTeams");

            migrationBuilder.DropIndex(
                name: "IX_ArcTeams_StandingsId2",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "StandingsId2",
                table: "ArcTeams");
        }
    }
}
