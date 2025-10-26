using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class farmerserrvice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgriService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgriSectorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FarmerServiceCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    ServiceDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerServiceCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FarmerServiceCardDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerServiceCardId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerServiceCardDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerServiceCardDetail_AgriSector_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AgriSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerServiceCardDetail_AgriService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "AgriService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerServiceCardDetail_FarmerServiceCard_FarmerServiceCardId",
                        column: x => x.FarmerServiceCardId,
                        principalTable: "FarmerServiceCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerServiceCardDetail_MeasuringUnit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "MeasuringUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FarmerServiceCardDetail_FarmerServiceCardId",
                table: "FarmerServiceCardDetail",
                column: "FarmerServiceCardId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerServiceCardDetail_ServiceId",
                table: "FarmerServiceCardDetail",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerServiceCardDetail_TypeId",
                table: "FarmerServiceCardDetail",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerServiceCardDetail_UnitId",
                table: "FarmerServiceCardDetail",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FarmerServiceCardDetail");

            migrationBuilder.DropTable(
                name: "AgriService");

            migrationBuilder.DropTable(
                name: "FarmerServiceCard");
        }
    }
}
