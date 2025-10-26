using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class photoadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Approvestatus",
                table: "AgricultureApplicatoionForm",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CitizenPhotoPath",
                table: "AgricultureApplicatoionForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LandOwnershipPhotoPath",
                table: "AgricultureApplicatoionForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanDetailPhotoPath",
                table: "AgricultureApplicatoionForm",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approvestatus",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropColumn(
                name: "CitizenPhotoPath",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropColumn(
                name: "LandOwnershipPhotoPath",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropColumn(
                name: "PlanDetailPhotoPath",
                table: "AgricultureApplicatoionForm");
        }
    }
}
