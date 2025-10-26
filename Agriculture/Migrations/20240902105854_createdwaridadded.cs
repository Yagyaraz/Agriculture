using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class createdwaridadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "VideoGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "Training",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "Subsidy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "SubCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "SeedStore",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SaveRequestedSubsidy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SaveRequestedSubsidy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "SaveRequestedSubsidy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SaveRequestedSubsidy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "SaveRequestedSubsidy",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "Playlist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "OtherSubsidy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "MarketPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "Market",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "Library",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "InsuranceCenter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "ImageGallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "FertilizerStore",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "FarmerServiceCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "Album",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "AgricultureService",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "AgricultureProject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "AgricultureProgram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "AgricultureFarmerGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "AgricultureEquipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedWardId",
                table: "AgricultureApplicatoionForm",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "VideoGallery");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "Training");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "Subsidy");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "SeedStore");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SaveRequestedSubsidy");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SaveRequestedSubsidy");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "SaveRequestedSubsidy");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SaveRequestedSubsidy");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "SaveRequestedSubsidy");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "Playlist");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "OtherSubsidy");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "MarketPrice");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "Market");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "InsuranceCenter");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "ImageGallery");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "FertilizerStore");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "FarmerServiceCard");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "AgricultureService");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "AgricultureProject");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "AgricultureProgram");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "AgricultureFarmerGroup");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "AgricultureEquipment");

            migrationBuilder.DropColumn(
                name: "CreatedWardId",
                table: "AgricultureApplicatoionForm");
        }
    }
}
