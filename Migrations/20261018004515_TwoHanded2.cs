using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scrap_depot.Migrations
{
    /// <inheritdoc />
    public partial class TwoHanded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "TwoHanded",
                table: "Scrap",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 1,
                column: "TwoHanded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 2,
                column: "TwoHanded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 3,
                column: "TwoHanded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 4,
                column: "TwoHanded",
                value: false);

            migrationBuilder.UpdateData(
                table: "Scrap",
                keyColumn: "Id",
                keyValue: 5,
                column: "TwoHanded",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "TwoHanded",
                table: "Scrap",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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
    }
}
