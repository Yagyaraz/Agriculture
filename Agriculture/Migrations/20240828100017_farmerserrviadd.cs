using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class farmerserrviadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FarmerServiceCard_FiscalYearId",
                table: "FarmerServiceCard",
                column: "FiscalYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_FarmerServiceCard_FiscalYear_FiscalYearId",
                table: "FarmerServiceCard",
                column: "FiscalYearId",
                principalTable: "FiscalYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FarmerServiceCard_FiscalYear_FiscalYearId",
                table: "FarmerServiceCard");

            migrationBuilder.DropIndex(
                name: "IX_FarmerServiceCard_FiscalYearId",
                table: "FarmerServiceCard");
        }
    }
}
