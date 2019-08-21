using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Draft.Inf.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArcTeams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArcTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Draft",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draft", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HomeScore = table.Column<int>(nullable: false),
                    AwayScore = table.Column<int>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    Ties = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChampionId = table.Column<int>(nullable: true),
                    EastChampId = table.Column<int>(nullable: true),
                    WestChampId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standings_ArcTeams_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "ArcTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Standings_ArcTeams_EastChampId",
                        column: x => x.EastChampId,
                        principalTable: "ArcTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Standings_ArcTeams_WestChampId",
                        column: x => x.WestChampId,
                        principalTable: "ArcTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DraftId = table.Column<int>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Draft_DraftId",
                        column: x => x.DraftId,
                        principalTable: "Draft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Division = table.Column<int>(nullable: false),
                    OffRating = table.Column<int>(nullable: false),
                    DefRating = table.Column<int>(nullable: false),
                    StandingsId = table.Column<int>(nullable: true),
                    StandingsId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Standings_StandingsId",
                        column: x => x.StandingsId,
                        principalTable: "Standings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Standings_StandingsId1",
                        column: x => x.StandingsId1,
                        principalTable: "Standings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VeteranRating = table.Column<int>(nullable: false),
                    RookieRating = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    IsRetired = table.Column<bool>(nullable: false),
                    Experience = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Injury",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injury", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Injury_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Injury_PlayerId",
                table: "Injury",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_DraftId",
                table: "Seasons",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_ChampionId",
                table: "Standings",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_EastChampId",
                table: "Standings",
                column: "EastChampId");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_WestChampId",
                table: "Standings",
                column: "WestChampId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StandingsId",
                table: "Teams",
                column: "StandingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_StandingsId1",
                table: "Teams",
                column: "StandingsId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Injury");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Draft");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.DropTable(
                name: "ArcTeams");
        }
    }
}
