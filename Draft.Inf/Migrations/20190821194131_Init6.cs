using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Draft.Inf.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RosterId",
                table: "Teams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RosterId",
                table: "Players",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RosterId1",
                table: "Players",
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

            migrationBuilder.CreateIndex(
                name: "IX_Players_RosterId",
                table: "Players",
                column: "RosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_RosterId1",
                table: "Players",
                column: "RosterId1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Players_RosterId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_RosterId1",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RosterId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "RosterId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RosterId1",
                table: "Players");
        }
    }
}
