using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class calandeaded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgriCalendarCategoryId",
                table: "AgriCalendarProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AgriCalendarTypeId",
                table: "AgriCalendarCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgriCalendarCategoryId",
                table: "AgriCalendarProduct");

            migrationBuilder.DropColumn(
                name: "AgriCalendarTypeId",
                table: "AgriCalendarCategory");
        }
    }
}
