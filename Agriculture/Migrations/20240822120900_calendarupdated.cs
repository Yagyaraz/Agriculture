using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class calendarupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgriCalendarTypeId",
                table: "AgriCalendarProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarProduct_AgriCalendarCategoryId",
                table: "AgriCalendarProduct",
                column: "AgriCalendarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarProduct_AgriCalendarTypeId",
                table: "AgriCalendarProduct",
                column: "AgriCalendarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarCategory_AgriCalendarTypeId",
                table: "AgriCalendarCategory",
                column: "AgriCalendarTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgriCalendarCategory_AgriCalendarType_AgriCalendarTypeId",
                table: "AgriCalendarCategory",
                column: "AgriCalendarTypeId",
                principalTable: "AgriCalendarType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AgriCalendarProduct_AgriCalendarCategory_AgriCalendarCategoryId",
                table: "AgriCalendarProduct",
                column: "AgriCalendarCategoryId",
                principalTable: "AgriCalendarCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AgriCalendarProduct_AgriCalendarType_AgriCalendarTypeId",
                table: "AgriCalendarProduct",
                column: "AgriCalendarTypeId",
                principalTable: "AgriCalendarType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgriCalendarCategory_AgriCalendarType_AgriCalendarTypeId",
                table: "AgriCalendarCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_AgriCalendarProduct_AgriCalendarCategory_AgriCalendarCategoryId",
                table: "AgriCalendarProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_AgriCalendarProduct_AgriCalendarType_AgriCalendarTypeId",
                table: "AgriCalendarProduct");

            migrationBuilder.DropIndex(
                name: "IX_AgriCalendarProduct_AgriCalendarCategoryId",
                table: "AgriCalendarProduct");

            migrationBuilder.DropIndex(
                name: "IX_AgriCalendarProduct_AgriCalendarTypeId",
                table: "AgriCalendarProduct");

            migrationBuilder.DropIndex(
                name: "IX_AgriCalendarCategory_AgriCalendarTypeId",
                table: "AgriCalendarCategory");

            migrationBuilder.DropColumn(
                name: "AgriCalendarTypeId",
                table: "AgriCalendarProduct");
        }
    }
}
