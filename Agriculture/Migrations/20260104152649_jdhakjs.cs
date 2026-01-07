using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class jdhakjs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VideoGallery",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ImageGallery",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VideoGallery");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ImageGallery");
        }
    }
}
