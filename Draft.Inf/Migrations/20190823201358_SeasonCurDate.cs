using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Draft.Inf.Migrations
{
    public partial class SeasonCurDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId1",
                table: "ArcTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId2",
                table: "ArcTeams");

            migrationBuilder.DropIndex(
                name: "IX_ArcTeams_StandingsId1",
                table: "ArcTeams");

            migrationBuilder.DropIndex(
                name: "IX_ArcTeams_StandingsId2",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "StandingsId1",
                table: "ArcTeams");

            migrationBuilder.DropColumn(
                name: "StandingsId2",
                table: "ArcTeams");

            migrationBuilder.AddColumn<DateTime>(
                name: "CurDate",
                table: "Seasons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurDate",
                table: "Seasons");

            migrationBuilder.AddColumn<int>(
                name: "StandingsId1",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandingsId2",
                table: "ArcTeams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArcTeams_StandingsId1",
                table: "ArcTeams",
                column: "StandingsId1");

            migrationBuilder.CreateIndex(
                name: "IX_ArcTeams_StandingsId2",
                table: "ArcTeams",
                column: "StandingsId2");

            migrationBuilder.AddForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId1",
                table: "ArcTeams",
                column: "StandingsId1",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArcTeams_Standings_StandingsId2",
                table: "ArcTeams",
                column: "StandingsId2",
                principalTable: "Standings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
