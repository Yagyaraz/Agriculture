using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class krishiyojana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgricultureProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureProgram_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgricultureProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureProject_AgricultureProgram_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "AgricultureProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgricultureProject_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgricultureService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ValidTillDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureService_AgricultureProgram_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "AgricultureProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgricultureService_AgricultureProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "AgricultureProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgricultureService_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgricultureApplicatoionForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    FarmerTypeId = table.Column<int>(type: "int", nullable: false),
                    FarmerId = table.Column<int>(type: "int", nullable: true),
                    AgriGroupId = table.Column<int>(type: "int", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureApplicatoionForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureApplicatoionForm_AgricultureProgram_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "AgricultureProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgricultureApplicatoionForm_AgricultureProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "AgricultureProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgricultureApplicatoionForm_AgricultureService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "AgricultureService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgricultureApplicatoionForm_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgricultureServiceAdditional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Questions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureServiceAdditional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgricultureServiceAdditional_AgricultureService_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "AgricultureService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_FiscalYearId",
                table: "FamilyDetails",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureApplicatoionForm_FiscalYearId",
                table: "AgricultureApplicatoionForm",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureApplicatoionForm_ProgramId",
                table: "AgricultureApplicatoionForm",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureApplicatoionForm_ProjectId",
                table: "AgricultureApplicatoionForm",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureApplicatoionForm_ServiceId",
                table: "AgricultureApplicatoionForm",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureProgram_FiscalYearId",
                table: "AgricultureProgram",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureProject_FiscalYearId",
                table: "AgricultureProject",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureProject_ProgramId",
                table: "AgricultureProject",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureService_FiscalYearId",
                table: "AgricultureService",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureService_ProgramId",
                table: "AgricultureService",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureService_ProjectId",
                table: "AgricultureService",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureServiceAdditional_ServiceId",
                table: "AgricultureServiceAdditional",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyDetails_FiscalYear_FiscalYearId",
                table: "FamilyDetails",
                column: "FiscalYearId",
                principalTable: "FiscalYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyDetails_FiscalYear_FiscalYearId",
                table: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "AgricultureApplicatoionForm");

            migrationBuilder.DropTable(
                name: "AgricultureServiceAdditional");

            migrationBuilder.DropTable(
                name: "AgricultureService");

            migrationBuilder.DropTable(
                name: "AgricultureProject");

            migrationBuilder.DropTable(
                name: "AgricultureProgram");

            migrationBuilder.DropIndex(
                name: "IX_FamilyDetails_FiscalYearId",
                table: "FamilyDetails");
        }
    }
}
