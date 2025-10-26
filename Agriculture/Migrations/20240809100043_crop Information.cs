using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class cropInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeeType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropsInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropsInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropsInformation_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CropsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FruitsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MushroomType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MushroomType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeedsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SilkType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SilkType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeeCrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropsInformationId = table.Column<int>(type: "int", nullable: false),
                    BeeTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeeCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeeCrops_BeeType_BeeTypeId",
                        column: x => x.BeeTypeId,
                        principalTable: "BeeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeeCrops_CropsInformation_CropsInformationId",
                        column: x => x.CropsInformationId,
                        principalTable: "CropsInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EatableCrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropsInformationId = table.Column<int>(type: "int", nullable: false),
                    CropsTypeId = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatableCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EatableCrops_CropsInformation_CropsInformationId",
                        column: x => x.CropsInformationId,
                        principalTable: "CropsInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EatableCrops_CropsType_CropsTypeId",
                        column: x => x.CropsTypeId,
                        principalTable: "CropsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FruitCrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropsInformationId = table.Column<int>(type: "int", nullable: false),
                    FruitsTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalPlant = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FruitCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FruitCrops_CropsInformation_CropsInformationId",
                        column: x => x.CropsInformationId,
                        principalTable: "CropsInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FruitCrops_FruitsType_FruitsTypeId",
                        column: x => x.FruitsTypeId,
                        principalTable: "FruitsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MushroomCrpos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropsInformationId = table.Column<int>(type: "int", nullable: false),
                    MushroomTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MushroomCrpos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MushroomCrpos_CropsInformation_CropsInformationId",
                        column: x => x.CropsInformationId,
                        principalTable: "CropsInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MushroomCrpos_MushroomType_MushroomTypeId",
                        column: x => x.MushroomTypeId,
                        principalTable: "MushroomType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeedCrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropsInformationId = table.Column<int>(type: "int", nullable: false),
                    SeedsTypeId = table.Column<int>(type: "int", nullable: false),
                    Jaat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeedCrops_CropsInformation_CropsInformationId",
                        column: x => x.CropsInformationId,
                        principalTable: "CropsInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeedCrops_SeedsType_SeedsTypeId",
                        column: x => x.SeedsTypeId,
                        principalTable: "SeedsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SilkCrops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropsInformationId = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SilkTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SilkCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SilkCrops_CropsInformation_CropsInformationId",
                        column: x => x.CropsInformationId,
                        principalTable: "CropsInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SilkCrops_SilkType_SilkTypeId",
                        column: x => x.SilkTypeId,
                        principalTable: "SilkType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeeCrops_BeeTypeId",
                table: "BeeCrops",
                column: "BeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeCrops_CropsInformationId",
                table: "BeeCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CropsInformation_FarmerId",
                table: "CropsInformation",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_EatableCrops_CropsInformationId",
                table: "EatableCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EatableCrops_CropsTypeId",
                table: "EatableCrops",
                column: "CropsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FruitCrops_CropsInformationId",
                table: "FruitCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_FruitCrops_FruitsTypeId",
                table: "FruitCrops",
                column: "FruitsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MushroomCrpos_CropsInformationId",
                table: "MushroomCrpos",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MushroomCrpos_MushroomTypeId",
                table: "MushroomCrpos",
                column: "MushroomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedCrops_CropsInformationId",
                table: "SeedCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedCrops_SeedsTypeId",
                table: "SeedCrops",
                column: "SeedsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SilkCrops_CropsInformationId",
                table: "SilkCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_SilkCrops_SilkTypeId",
                table: "SilkCrops",
                column: "SilkTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeeCrops");

            migrationBuilder.DropTable(
                name: "EatableCrops");

            migrationBuilder.DropTable(
                name: "FruitCrops");

            migrationBuilder.DropTable(
                name: "MushroomCrpos");

            migrationBuilder.DropTable(
                name: "SeedCrops");

            migrationBuilder.DropTable(
                name: "SilkCrops");

            migrationBuilder.DropTable(
                name: "BeeType");

            migrationBuilder.DropTable(
                name: "CropsType");

            migrationBuilder.DropTable(
                name: "FruitsType");

            migrationBuilder.DropTable(
                name: "MushroomType");

            migrationBuilder.DropTable(
                name: "SeedsType");

            migrationBuilder.DropTable(
                name: "CropsInformation");

            migrationBuilder.DropTable(
                name: "SilkType");
        }
    }
}
