using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class farmergroupadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgriGroupType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriGroupType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgricultureFarmerGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmNameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmEstdDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmPalikaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmWardNo = table.Column<int>(type: "int", nullable: false),
                    FirmTolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgriGroupTypeId = table.Column<int>(type: "int", nullable: false),
                    FirmPanNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmDartaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmRegDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmHitKoshAmt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SadsyeMaleCount = table.Column<int>(type: "int", nullable: false),
                    SadsyeFemaleCount = table.Column<int>(type: "int", nullable: false),
                    SadsyeOtherCount = table.Column<int>(type: "int", nullable: false),
                    SamuhaAim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamuhaDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamuhaWardNo = table.Column<int>(type: "int", nullable: false),
                    KaryalayeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureFarmerGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureFarmerGroup_AgriGroupType_AgriGroupTypeId",
                        column: x => x.AgriGroupTypeId,
                        principalTable: "AgriGroupType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficialsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgricultureFarmerGroupId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    LiterateLevelId = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialsDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialsDetail_AgricultureFarmerGroup_AgricultureFarmerGroupId",
                        column: x => x.AgricultureFarmerGroupId,
                        principalTable: "AgricultureFarmerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialsDetail_EducationLevel_LiterateLevelId",
                        column: x => x.LiterateLevelId,
                        principalTable: "EducationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfficialsDetail_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureFarmerGroup_AgriGroupTypeId",
                table: "AgricultureFarmerGroup",
                column: "AgriGroupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialsDetail_AgricultureFarmerGroupId",
                table: "OfficialsDetail",
                column: "AgricultureFarmerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialsDetail_LiterateLevelId",
                table: "OfficialsDetail",
                column: "LiterateLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialsDetail_PostId",
                table: "OfficialsDetail",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficialsDetail");

            migrationBuilder.DropTable(
                name: "AgricultureFarmerGroup");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "AgriGroupType");
        }
    }
}
