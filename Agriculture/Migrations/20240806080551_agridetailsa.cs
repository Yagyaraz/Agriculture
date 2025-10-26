using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class agridetailsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalKanwa",
                table: "KrishiDetails");

            migrationBuilder.DropColumn(
                name: "TotalKanwai",
                table: "KrishiDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalKanwa",
                table: "KrishiDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalKanwai",
                table: "KrishiDetails",
                type: "int",
                nullable: true);
        }
    }
}
