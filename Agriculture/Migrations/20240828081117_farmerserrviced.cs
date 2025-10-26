using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class farmerserrviced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FarmerServiceCard_FarmerId",
                table: "FarmerServiceCard",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerServiceCard_Farmer_FarmerId",
                table: "FarmerServiceCard",
                column: "FarmerId",
                principalTable: "Farmer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerServiceCard_Farmer_FarmerId",
                table: "FarmerServiceCard");

            migrationBuilder.DropIndex(
                name: "IX_FarmerServiceCard_FarmerId",
                table: "FarmerServiceCard");
        }
    }
}
