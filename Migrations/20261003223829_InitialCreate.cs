using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace scrap_depot.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scrap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Deposited = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scrap", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Scrap",
                columns: new[] { "Id", "Credits", "Deposited", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, 25, 0, "A large metal bolt.", "Big Bolt", 19 },
                    { 2, 46, 0, "A large geared axle made of metal.", "Large Axel", 16 },
                    { 3, 31, 0, "A flat-bottomed round glass flask.", "Flask", 16 },
                    { 4, 36, 0, "A detached, octaganal sign reading 'STOP'", "Stop Sign", 29 },
                    { 5, 61, 0, "A yellow rubber duck.", "Rubber Ducky", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scrap");
        }
    }
}
