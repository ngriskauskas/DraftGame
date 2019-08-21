using Microsoft.EntityFrameworkCore.Migrations;

namespace Draft.Inf.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "Teams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_RecordId",
                table: "Teams",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Records_RecordId",
                table: "Teams",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Records_RecordId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_RecordId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Teams");
        }
    }
}
