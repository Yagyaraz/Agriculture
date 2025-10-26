using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class agridetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgriSector",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriSector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AvgMonth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvgMonth", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KrishiDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    IsSelfJagga = table.Column<bool>(type: "bit", nullable: true),
                    ChooseLand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBigaha = table.Column<int>(type: "int", nullable: true),
                    TotalKattha = table.Column<int>(type: "int", nullable: true),
                    TotalDhur = table.Column<int>(type: "int", nullable: true),
                    TotalKanwai = table.Column<int>(type: "int", nullable: true),
                    TotalKanwa = table.Column<int>(type: "int", nullable: true),
                    TotalBigaSquareMiter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalRopani = table.Column<int>(type: "int", nullable: true),
                    TotalAana = table.Column<int>(type: "int", nullable: true),
                    TotalPaisa = table.Column<int>(type: "int", nullable: true),
                    TotalDam = table.Column<int>(type: "int", nullable: true),
                    TotalRopaniSquareMiter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomeFromAgri = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IncomeFromNonAgri = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AvgMonthForAgriId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrishiDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KrishiDetails_AvgMonth_AvgMonthForAgriId",
                        column: x => x.AvgMonthForAgriId,
                        principalTable: "AvgMonth",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KrishiDetails_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgricultureDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KrishiDetailsId = table.Column<int>(type: "int", nullable: false),
                    AgriWardNo = table.Column<int>(type: "int", nullable: false),
                    AgriAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgriSectorId = table.Column<int>(type: "int", nullable: false),
                    AgriSubSector = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureDetail_AgriSector_AgriSectorId",
                        column: x => x.AgriSectorId,
                        principalTable: "AgriSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgricultureDetail_KrishiDetails_KrishiDetailsId",
                        column: x => x.KrishiDetailsId,
                        principalTable: "KrishiDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureDetail_AgriSectorId",
                table: "AgricultureDetail",
                column: "AgriSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureDetail_KrishiDetailsId",
                table: "AgricultureDetail",
                column: "KrishiDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_KrishiDetails_AvgMonthForAgriId",
                table: "KrishiDetails",
                column: "AvgMonthForAgriId");

            migrationBuilder.CreateIndex(
                name: "IX_KrishiDetails_FarmerId",
                table: "KrishiDetails",
                column: "FarmerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgricultureDetail");

            migrationBuilder.DropTable(
                name: "AgriSector");

            migrationBuilder.DropTable(
                name: "KrishiDetails");

            migrationBuilder.DropTable(
                name: "AvgMonth");
        }
    }
}
