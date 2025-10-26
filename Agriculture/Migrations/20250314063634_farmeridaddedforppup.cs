using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class farmeridaddedforppup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmerId",
                table: "SaveRequestedSubsidy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaveRequestedSubsidy_FarmerId",
                table: "SaveRequestedSubsidy",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaveRequestedSubsidy_Farmer_FarmerId",
                table: "SaveRequestedSubsidy",
                column: "FarmerId",
                principalTable: "Farmer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaveRequestedSubsidy_Farmer_FarmerId",
                table: "SaveRequestedSubsidy");

            migrationBuilder.DropIndex(
                name: "IX_SaveRequestedSubsidy_FarmerId",
                table: "SaveRequestedSubsidy");

            migrationBuilder.DropColumn(
                name: "FarmerId",
                table: "SaveRequestedSubsidy");
        }
    }
}
