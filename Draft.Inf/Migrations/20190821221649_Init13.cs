using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Draft.Inf.Migrations
{
    public partial class Init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Standings_StandingsId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Standings_StandingsId1",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_StandingsId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_StandingsId1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StandingsId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StandingsId1",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "StandingsId",
                table: "Seasons",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Seasons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DefRating",
                table: "ArcTeams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Division",
                table: "ArcTeams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameTeamGameId",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameTeamTeamId",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OffRating",
                table: "ArcTeams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandingsId",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandingsId1",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameTeam",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    TeamSide = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTeam", x => new { x.TeamId, x.GameId });
                    table.ForeignKey(
                        name: "FK_GameTeam_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_StandingsId",
                table: "Seasons",
                column: "StandingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArcTeams_RecordId",
                table: "ArcTeams",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_ArcTeams_StandingsId",
                table: "ArcTeams",
                column: "StandingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArcTeams_StandingsId1",
                table: "ArcTeams",
                column: "StandingsId1");

            migrationBuilder.CreateIndex(
                name: "IX_ArcTeams_TeamId",
                table: "ArcTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ArcTeams_GameTeamTeamId_GameTeamGameId",
                table: "ArcTeams",
                columns: new[] { "GameTeamTeamId", "GameTeamGameId" });

            migrationBuilder.CreateIndex(
                name: "IX_GameTeam_GameId",
                table: "GameTeam",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArcTeams_Records_RecordId",
                table: "ArcTeams",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId",
                table: "ArcTeams",
                column: "StandingsId",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId1",
                table: "ArcTeams",
                column: "StandingsId1",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArcTeams_Teams_TeamId",
                table: "ArcTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArcTeams_GameTeam_GameTeamTeamId_GameTeamGameId",
                table: "ArcTeams",
                columns: new[] { "GameTeamTeamId", "GameTeamGameId" },
                principalTable: "GameTeam",
                principalColumns: new[] { "TeamId", "GameId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Standings_StandingsId",
                table: "Seasons",
                column: "StandingsId",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArcTeams_Records_RecordId",
                table: "ArcTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId",
                table: "ArcTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId1",
                table: "ArcTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_ArcTeams_Teams_TeamId",
                table: "ArcTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_ArcTeams_GameTeam_GameTeamTeamId_GameTeamGameId",
                table: "ArcTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Standings_StandingsId",
                table: "Seasons");

            migrationBuilder.DropTable(
                name: "GameTeam");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_StandingsId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_ArcTeams_RecordId",
                table: "ArcTeams");

            migrationBuilder.DropIndex(
                name: "IX_ArcTeams_StandingsId",
                table: "ArcTeams");

            migrationBuilder.DropIndex(
                name: "IX_ArcTeams_StandingsId1",
                table: "ArcTeams");

            migrationBuilder.DropIndex(
                name: "IX_ArcTeams_TeamId",
                table: "ArcTeams");

            migrationBuilder.DropIndex(
                name: "IX_ArcTeams_GameTeamTeamId_GameTeamGameId",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "StandingsId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "DefRating",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "Division",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "GameTeamGameId",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "GameTeamTeamId",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "OffRating",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "StandingsId",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "StandingsId1",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "ArcTeams");

            migrationBuilder.AddColumn<int>(
                name: "StandingsId",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandingsId1",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StandingsId",
                table: "Teams",
                column: "StandingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StandingsId1",
                table: "Teams",
                column: "StandingsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Standings_StandingsId",
                table: "Teams",
                column: "StandingsId",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Standings_StandingsId1",
                table: "Teams",
                column: "StandingsId1",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
