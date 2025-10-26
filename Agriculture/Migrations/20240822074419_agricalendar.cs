using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class agricalendar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FamilyDetailsInvolvedInAgri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "FamilyDetailsInvolvedInAgri",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "FamilyDetailsInvolvedInAgri",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "FamilyDetailsInvolvedInAgri",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgriCalendarCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriCalendarCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgriCalendarProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriCalendarProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgriCalendarType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriCalendarType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EcologicalArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcologicalArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Month",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Month", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Week",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Week", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgriCalendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Variety = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgriCalendar_AgriCalendarCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AgriCalendarCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendar_AgriCalendarProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AgriCalendarProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendar_AgriCalendarType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AgriCalendarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgriCalendarDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgriCalendarId = table.Column<int>(type: "int", nullable: false),
                    EcologicalAreaId = table.Column<int>(type: "int", nullable: false),
                    ElevationFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ElevationTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SowingStartMonthId = table.Column<int>(type: "int", nullable: false),
                    SowingEndMonthId = table.Column<int>(type: "int", nullable: false),
                    SowingStartWeekId = table.Column<int>(type: "int", nullable: false),
                    SowingEndWeekId = table.Column<int>(type: "int", nullable: false),
                    HarvestStartMonthId = table.Column<int>(type: "int", nullable: false),
                    HarvestEndMonthId = table.Column<int>(type: "int", nullable: false),
                    HarvestStartWeekId = table.Column<int>(type: "int", nullable: false),
                    HarvestEndWeekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriCalendarDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_AgriCalendar_AgriCalendarId",
                        column: x => x.AgriCalendarId,
                        principalTable: "AgriCalendar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_EcologicalArea_EcologicalAreaId",
                        column: x => x.EcologicalAreaId,
                        principalTable: "EcologicalArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_Month_HarvestEndMonthId",
                        column: x => x.HarvestEndMonthId,
                        principalTable: "Month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_Month_HarvestStartMonthId",
                        column: x => x.HarvestStartMonthId,
                        principalTable: "Month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_Month_SowingEndMonthId",
                        column: x => x.SowingEndMonthId,
                        principalTable: "Month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_Month_SowingStartMonthId",
                        column: x => x.SowingStartMonthId,
                        principalTable: "Month",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_Week_HarvestEndWeekId",
                        column: x => x.HarvestEndWeekId,
                        principalTable: "Week",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_Week_HarvestStartWeekId",
                        column: x => x.HarvestStartWeekId,
                        principalTable: "Week",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_Week_SowingEndWeekId",
                        column: x => x.SowingEndWeekId,
                        principalTable: "Week",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarDetail_Week_SowingStartWeekId",
                        column: x => x.SowingStartWeekId,
                        principalTable: "Week",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendar_CategoryId",
                table: "AgriCalendar",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendar_ProductId",
                table: "AgriCalendar",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendar_TypeId",
                table: "AgriCalendar",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_AgriCalendarId",
                table: "AgriCalendarDetail",
                column: "AgriCalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_EcologicalAreaId",
                table: "AgriCalendarDetail",
                column: "EcologicalAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_HarvestEndMonthId",
                table: "AgriCalendarDetail",
                column: "HarvestEndMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_HarvestEndWeekId",
                table: "AgriCalendarDetail",
                column: "HarvestEndWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_HarvestStartMonthId",
                table: "AgriCalendarDetail",
                column: "HarvestStartMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_HarvestStartWeekId",
                table: "AgriCalendarDetail",
                column: "HarvestStartWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_SowingEndMonthId",
                table: "AgriCalendarDetail",
                column: "SowingEndMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_SowingEndWeekId",
                table: "AgriCalendarDetail",
                column: "SowingEndWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_SowingStartMonthId",
                table: "AgriCalendarDetail",
                column: "SowingStartMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarDetail_SowingStartWeekId",
                table: "AgriCalendarDetail",
                column: "SowingStartWeekId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgriCalendarDetail");

            migrationBuilder.DropTable(
                name: "AgriCalendar");

            migrationBuilder.DropTable(
                name: "EcologicalArea");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Week");

            migrationBuilder.DropTable(
                name: "AgriCalendarCategory");

            migrationBuilder.DropTable(
                name: "AgriCalendarProduct");

            migrationBuilder.DropTable(
                name: "AgriCalendarType");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FamilyDetailsInvolvedInAgri");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "FamilyDetailsInvolvedInAgri");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "FamilyDetailsInvolvedInAgri");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "FamilyDetailsInvolvedInAgri");
        }
    }
}
