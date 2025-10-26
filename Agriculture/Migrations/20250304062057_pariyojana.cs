using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class pariyojana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MinutePhotoPath",
                table: "AgricultureApplicatoionForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanjikaranPhotoPath",
                table: "AgricultureApplicatoionForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelfdecisionPhotoPath",
                table: "AgricultureApplicatoionForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SthailekhaPhotoPath",
                table: "AgricultureApplicatoionForm",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxPhotoPath",
                table: "AgricultureApplicatoionForm",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinutePhotoPath",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropColumn(
                name: "PanjikaranPhotoPath",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropColumn(
                name: "SelfdecisionPhotoPath",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropColumn(
                name: "SthailekhaPhotoPath",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropColumn(
                name: "TaxPhotoPath",
                table: "AgricultureApplicatoionForm");
        }
    }
}
