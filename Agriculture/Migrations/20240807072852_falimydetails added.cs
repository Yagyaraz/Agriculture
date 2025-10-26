using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class falimydetailsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSelfJagga",
                table: "KrishiDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FamilyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    TotalMale = table.Column<int>(type: "int", nullable: false),
                    TotalFemale = table.Column<int>(type: "int", nullable: false),
                    TotalMember = table.Column<int>(type: "int", nullable: false),
                    TotalMaleInAgri = table.Column<int>(type: "int", nullable: false),
                    TotalFemaleInAgri = table.Column<int>(type: "int", nullable: false),
                    TotalMemberInAgri = table.Column<int>(type: "int", nullable: false),
                    TotalInvolvedinAgi = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyDetails_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingArea",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingArea", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDetailsInvolvedInAgri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyDetailsId = table.Column<int>(type: "int", nullable: false),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    WorkingAreaId = table.Column<int>(type: "int", nullable: false),
                    CitizenNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumbar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetailsInvolvedInAgri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyDetailsInvolvedInAgri_FamilyDetails_FamilyDetailsId",
                        column: x => x.FamilyDetailsId,
                        principalTable: "FamilyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyDetailsInvolvedInAgri_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyDetailsInvolvedInAgri_Relation_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyDetailsInvolvedInAgri_WorkingArea_WorkingAreaId",
                        column: x => x.WorkingAreaId,
                        principalTable: "WorkingArea",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_FarmerId",
                table: "FamilyDetails",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetailsInvolvedInAgri_FamilyDetailsId",
                table: "FamilyDetailsInvolvedInAgri",
                column: "FamilyDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetailsInvolvedInAgri_GenderId",
                table: "FamilyDetailsInvolvedInAgri",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetailsInvolvedInAgri_RelationId",
                table: "FamilyDetailsInvolvedInAgri",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetailsInvolvedInAgri_WorkingAreaId",
                table: "FamilyDetailsInvolvedInAgri",
                column: "WorkingAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDetailsInvolvedInAgri");

            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropTable(
                name: "WorkingArea");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSelfJagga",
                table: "KrishiDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
