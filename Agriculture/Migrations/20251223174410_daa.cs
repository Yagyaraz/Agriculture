using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class daa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Training",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Suchanas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Subsidy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SeedStoreProduction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SeedStore",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SaveRequestedSubsidy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OtherSubsidy",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Nabikarans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Market",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Library",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "KrishiDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "InsuranceCenter",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Gunasos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FieldDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FertilizerStore",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FarmerServiceCard",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Farmer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FamilyDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CropsInformation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApplicationForms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AnimalHusbandry",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgriService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgricultureServiceAdditional",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgricultureService",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgricultureProject",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgricultureProgram",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgricultureFarmerGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgricultureApplicatoionForm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgriCalendarType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgriCalendarProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgriCalendarCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AgriCalendar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Suchanas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Subsidy");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SeedStoreProduction");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SeedStore");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SaveRequestedSubsidy");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OtherSubsidy");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Nabikarans");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "KrishiDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "InsuranceCenter");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Gunasos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FieldDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FertilizerStore");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FarmerServiceCard");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Farmer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FamilyDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CropsInformation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApplicationForms");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AnimalHusbandry");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgriService");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgricultureServiceAdditional");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgricultureService");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgricultureProject");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgricultureProgram");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgricultureFarmerGroup");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgricultureApplicatoionForm");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgriCalendarType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgriCalendarProduct");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgriCalendarCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AgriCalendar");
        }
    }
}
