using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionIntoCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "LK_Categories",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "LK_Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Personal");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "LK_Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Work");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "LK_Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Others");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "LK_Categories");
        }
    }
}
