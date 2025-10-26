using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class krishiyojanaupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AgricultureApplicatoionForm_AgriGroupId",
                table: "AgricultureApplicatoionForm",
                column: "AgriGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureApplicatoionForm_FarmerId",
                table: "AgricultureApplicatoionForm",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgricultureApplicatoionForm_FarmerGroup_AgriGroupId",
                table: "AgricultureApplicatoionForm",
                column: "AgriGroupId",
                principalTable: "FarmerGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AgricultureApplicatoionForm_Farmer_FarmerId",
                table: "AgricultureApplicatoionForm",
                column: "FarmerId",
                principalTable: "Farmer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgricultureApplicatoionForm_FarmerGroup_AgriGroupId",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropForeignKey(
                name: "FK_AgricultureApplicatoionForm_Farmer_FarmerId",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropIndex(
                name: "IX_AgricultureApplicatoionForm_AgriGroupId",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropIndex(
                name: "IX_AgricultureApplicatoionForm_FarmerId",
                table: "AgricultureApplicatoionForm");
        }
    }
}
