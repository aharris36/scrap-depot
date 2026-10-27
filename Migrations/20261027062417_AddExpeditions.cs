using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scrap_depot.Migrations
{
    /// <inheritdoc />
    public partial class AddExpeditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expeditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewNumber = table.Column<int>(type: "int", nullable: false),
                    Moon = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ScrapIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expeditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpeditionScrap",
                columns: table => new
                {
                    ExpeditionsId = table.Column<int>(type: "int", nullable: false),
                    ScrapCollectedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpeditionScrap", x => new { x.ExpeditionsId, x.ScrapCollectedId });
                    table.ForeignKey(
                        name: "FK_ExpeditionScrap_Expeditions_ExpeditionsId",
                        column: x => x.ExpeditionsId,
                        principalTable: "Expeditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpeditionScrap_Scrap_ScrapCollectedId",
                        column: x => x.ScrapCollectedId,
                        principalTable: "Scrap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionScrap_ScrapCollectedId",
                table: "ExpeditionScrap",
                column: "ScrapCollectedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpeditionScrap");

            migrationBuilder.DropTable(
                name: "Expeditions");
        }
    }
}
