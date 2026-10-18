using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scrap_depot.Migrations
{
    /// <inheritdoc />
    public partial class TwoHanded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TwoHanded",
                table: "Scrap",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 1,
                column: "TwoHanded",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 2,
                column: "TwoHanded",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 3,
                column: "TwoHanded",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 4,
                column: "TwoHanded",
                value: null);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 5,
                column: "TwoHanded",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TwoHanded",
                table: "Scrap");
        }
    }
}
