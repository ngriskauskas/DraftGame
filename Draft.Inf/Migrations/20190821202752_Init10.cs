using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Draft.Inf.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Roster_RosterId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Roster_RosterId1",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Roster_RosterId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Roster");

            migrationBuilder.DropIndex(
                name: "IX_Teams_RosterId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "RosterId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "RosterId1",
                table: "Players",
                newName: "TeamId1");

            migrationBuilder.RenameColumn(
                name: "RosterId",
                table: "Players",
                newName: "ArcTeamId1");

            migrationBuilder.RenameIndex(
                name: "IX_Players_RosterId1",
                table: "Players",
                newName: "IX_Players_TeamId1");

            migrationBuilder.RenameIndex(
                name: "IX_Players_RosterId",
                table: "Players",
                newName: "IX_Players_ArcTeamId1");

            migrationBuilder.AddColumn<int>(
                name: "ArcTeamId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_ArcTeamId",
                table: "Players",
                column: "ArcTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_ArcTeams_ArcTeamId",
                table: "Players",
                column: "ArcTeamId",
                principalTable: "ArcTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_ArcTeams_ArcTeamId1",
                table: "Players",
                column: "ArcTeamId1",
                principalTable: "ArcTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId1",
                table: "Players",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_ArcTeams_ArcTeamId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_ArcTeams_ArcTeamId1",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId1",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ArcTeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ArcTeamId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "TeamId1",
                table: "Players",
                newName: "RosterId1");

            migrationBuilder.RenameColumn(
                name: "ArcTeamId1",
                table: "Players",
                newName: "RosterId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId1",
                table: "Players",
                newName: "IX_Players_RosterId1");

            migrationBuilder.RenameIndex(
                name: "IX_Players_ArcTeamId1",
                table: "Players",
                newName: "IX_Players_RosterId");

            migrationBuilder.AddColumn<int>(
                name: "RosterId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roster", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_RosterId",
                table: "Teams",
                column: "RosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Roster_RosterId",
                table: "Players",
                column: "RosterId",
                principalTable: "Roster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Roster_RosterId1",
                table: "Players",
                column: "RosterId1",
                principalTable: "Roster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Roster_RosterId",
                table: "Teams",
                column: "RosterId",
                principalTable: "Roster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
