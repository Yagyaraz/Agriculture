using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class fielddetailsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    IsKrishakDarta = table.Column<bool>(type: "bit", nullable: false),
                    DartaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SanjhutaMiti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SanjhutaDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SamjhutaEndMiti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamjhutaEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CitizenNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldDetails_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldDetails_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IrrigationSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IrrigationSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgriFarmMoreThanOneLocalLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldDetailsId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIrrigationAvailiable = table.Column<bool>(type: "bit", nullable: false),
                    SectorId = table.Column<int>(type: "int", nullable: false),
                    SubSector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipId = table.Column<int>(type: "int", nullable: false),
                    DetailOfLandOwner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriFarmMoreThanOneLocalLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgriFarmMoreThanOneLocalLevel_AgriSector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "AgriSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriFarmMoreThanOneLocalLevel_FieldDetails_FieldDetailsId",
                        column: x => x.FieldDetailsId,
                        principalTable: "FieldDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriFarmMoreThanOneLocalLevel_OwnershipType_OwnershipId",
                        column: x => x.OwnershipId,
                        principalTable: "OwnershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LandOwnership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldDetailsId = table.Column<int>(type: "int", nullable: false),
                    OwnershipId = table.Column<int>(type: "int", nullable: false),
                    LandTypeId = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIrrigartionAvilable = table.Column<bool>(type: "bit", nullable: false),
                    IrrigartionArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IrrigationSourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandOwnership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandOwnership_FieldDetails_FieldDetailsId",
                        column: x => x.FieldDetailsId,
                        principalTable: "FieldDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LandOwnership_IrrigationSource_IrrigationSourceId",
                        column: x => x.IrrigationSourceId,
                        principalTable: "IrrigationSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LandOwnership_LandType_LandTypeId",
                        column: x => x.LandTypeId,
                        principalTable: "LandType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LandOwnership_OwnershipType_OwnershipId",
                        column: x => x.OwnershipId,
                        principalTable: "OwnershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeasedLandDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldDetailsId = table.Column<int>(type: "int", nullable: false),
                    OwnershipId = table.Column<int>(type: "int", nullable: false),
                    LandTypeId = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIrrigartionAvilable = table.Column<bool>(type: "bit", nullable: false),
                    IrrigartionArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IrrigationSourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasedLandDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeasedLandDetail_FieldDetails_FieldDetailsId",
                        column: x => x.FieldDetailsId,
                        principalTable: "FieldDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeasedLandDetail_IrrigationSource_IrrigationSourceId",
                        column: x => x.IrrigationSourceId,
                        principalTable: "IrrigationSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeasedLandDetail_LandType_LandTypeId",
                        column: x => x.LandTypeId,
                        principalTable: "LandType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeasedLandDetail_OwnershipType_OwnershipId",
                        column: x => x.OwnershipId,
                        principalTable: "OwnershipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgriFarmMoreThanOneLocalLevel_FieldDetailsId",
                table: "AgriFarmMoreThanOneLocalLevel",
                column: "FieldDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriFarmMoreThanOneLocalLevel_OwnershipId",
                table: "AgriFarmMoreThanOneLocalLevel",
                column: "OwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriFarmMoreThanOneLocalLevel_SectorId",
                table: "AgriFarmMoreThanOneLocalLevel",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDetails_FarmerId",
                table: "FieldDetails",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDetails_FiscalYearId",
                table: "FieldDetails",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_LandOwnership_FieldDetailsId",
                table: "LandOwnership",
                column: "FieldDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_LandOwnership_IrrigationSourceId",
                table: "LandOwnership",
                column: "IrrigationSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LandOwnership_LandTypeId",
                table: "LandOwnership",
                column: "LandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LandOwnership_OwnershipId",
                table: "LandOwnership",
                column: "OwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasedLandDetail_FieldDetailsId",
                table: "LeasedLandDetail",
                column: "FieldDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasedLandDetail_IrrigationSourceId",
                table: "LeasedLandDetail",
                column: "IrrigationSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasedLandDetail_LandTypeId",
                table: "LeasedLandDetail",
                column: "LandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasedLandDetail_OwnershipId",
                table: "LeasedLandDetail",
                column: "OwnershipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgriFarmMoreThanOneLocalLevel");

            migrationBuilder.DropTable(
                name: "LandOwnership");

            migrationBuilder.DropTable(
                name: "LeasedLandDetail");

            migrationBuilder.DropTable(
                name: "FieldDetails");

            migrationBuilder.DropTable(
                name: "IrrigationSource");

            migrationBuilder.DropTable(
                name: "LandType");

            migrationBuilder.DropTable(
                name: "OwnershipType");
        }
    }
}
