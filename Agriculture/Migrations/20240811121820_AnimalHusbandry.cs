using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class AnimalHusbandry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalHusbandry",
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
                    table.PrimaryKey("PK_AnimalHusbandry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalHusbandry_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimalHusbandry_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KrishiFarmType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrishiFarmType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcustionMeasurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcustionMeasurement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcustionUse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcustionUse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BhedaBakhraInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    BhedaCount = table.Column<int>(type: "int", nullable: false),
                    BhedaKasiCount = table.Column<int>(type: "int", nullable: false),
                    BhedaBokaCount = table.Column<int>(type: "int", nullable: false),
                    BhedaPathaCount = table.Column<int>(type: "int", nullable: false),
                    BakhraCount = table.Column<int>(type: "int", nullable: false),
                    BakhraKasiCount = table.Column<int>(type: "int", nullable: false),
                    BakhraBokaCount = table.Column<int>(type: "int", nullable: false),
                    BakhraPathaCount = table.Column<int>(type: "int", nullable: false),
                    ChangraCount = table.Column<int>(type: "int", nullable: false),
                    ChangraKasiCount = table.Column<int>(type: "int", nullable: false),
                    ChangraBokaCount = table.Column<int>(type: "int", nullable: false),
                    ChangraPathaCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BhedaBakhraInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BhedaBakhraInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuffaloInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    BuffLocCount = table.Column<int>(type: "int", nullable: false),
                    BuffLocMilkMonth = table.Column<int>(type: "int", nullable: false),
                    BuffLocMilkDaily = table.Column<int>(type: "int", nullable: false),
                    BuffUnnatCount = table.Column<int>(type: "int", nullable: false),
                    BuffUnnatMilkMonth = table.Column<int>(type: "int", nullable: false),
                    BuffUnnatMilkDaily = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffaloInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuffaloInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BungurSungurInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    BungurCount = table.Column<int>(type: "int", nullable: false),
                    BungurMaleCount = table.Column<int>(type: "int", nullable: false),
                    BungurPathaCount = table.Column<int>(type: "int", nullable: false),
                    SungurCount = table.Column<int>(type: "int", nullable: false),
                    SungurMaleCount = table.Column<int>(type: "int", nullable: false),
                    SungurPathaCount = table.Column<int>(type: "int", nullable: false),
                    BadelCount = table.Column<int>(type: "int", nullable: false),
                    BadelMaleCount = table.Column<int>(type: "int", nullable: false),
                    BadelPathaCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BungurSungurInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BungurSungurInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CharuiYakInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    ChauriCount = table.Column<int>(type: "int", nullable: false),
                    ChauriMilkMonth = table.Column<int>(type: "int", nullable: false),
                    ChauriMilkDaily = table.Column<int>(type: "int", nullable: false),
                    YakCount = table.Column<int>(type: "int", nullable: false),
                    YakMilkMonth = table.Column<int>(type: "int", nullable: false),
                    YakMilkDaily = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharuiYakInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharuiYakInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CowInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    CowLocCount = table.Column<int>(type: "int", nullable: false),
                    CowLocMilkMonth = table.Column<int>(type: "int", nullable: false),
                    CowLocMilkDaily = table.Column<int>(type: "int", nullable: false),
                    CowUnnatCount = table.Column<int>(type: "int", nullable: false),
                    CowUnnatMilkMonth = table.Column<int>(type: "int", nullable: false),
                    CowUnnatMilkDaily = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CowInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CowInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GhaseBaliInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    HudeJaat = table.Column<int>(type: "int", nullable: false),
                    HudeArea = table.Column<int>(type: "int", nullable: false),
                    HudeGrassProd = table.Column<int>(type: "int", nullable: false),
                    HudeSeedProd = table.Column<int>(type: "int", nullable: false),
                    BarshaJaat = table.Column<int>(type: "int", nullable: false),
                    BarshaArea = table.Column<int>(type: "int", nullable: false),
                    BarshaGrassProd = table.Column<int>(type: "int", nullable: false),
                    BarshaSeedProd = table.Column<int>(type: "int", nullable: false),
                    BahuBarshaJaat = table.Column<int>(type: "int", nullable: false),
                    BahuBarshaArea = table.Column<int>(type: "int", nullable: false),
                    BahuBarshaGrassProd = table.Column<int>(type: "int", nullable: false),
                    BahuBarshaSeedProd = table.Column<int>(type: "int", nullable: false),
                    DaleJaat = table.Column<int>(type: "int", nullable: false),
                    DaleArea = table.Column<int>(type: "int", nullable: false),
                    DaleGrassProd = table.Column<int>(type: "int", nullable: false),
                    DaleSeedProd = table.Column<int>(type: "int", nullable: false),
                    NurseryJaat = table.Column<int>(type: "int", nullable: false),
                    NurseryArea = table.Column<int>(type: "int", nullable: false),
                    NurseryGrassProd = table.Column<int>(type: "int", nullable: false),
                    NurserySeedProd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GhaseBaliInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GhaseBaliInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoruInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    GoruCount = table.Column<int>(type: "int", nullable: false),
                    RagaCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoruInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoruInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HenInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    IsLayers = table.Column<bool>(type: "bit", nullable: false),
                    LayersCount = table.Column<int>(type: "int", nullable: false),
                    LayersEggCount = table.Column<int>(type: "int", nullable: false),
                    LayersChickenProductionCount = table.Column<int>(type: "int", nullable: false),
                    IsBoiler = table.Column<bool>(type: "bit", nullable: false),
                    BoilerCount = table.Column<int>(type: "int", nullable: false),
                    BoilerEggCount = table.Column<int>(type: "int", nullable: false),
                    BoilerChickenProductionCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HenInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HenInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KrishiMechinaryInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    MechinaryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Swamitya = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Potential = table.Column<int>(type: "int", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrishiMechinaryInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KrishiMechinaryInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KrishiSanrachanaInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    SanrachanaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToalCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrishiSanrachanaInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KrishiSanrachanaInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherAnimalInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    GhodaCount = table.Column<int>(type: "int", nullable: false),
                    KhaccedCount = table.Column<int>(type: "int", nullable: false),
                    GadhaCount = table.Column<int>(type: "int", nullable: false),
                    RabbitCount = table.Column<int>(type: "int", nullable: false),
                    DogCount = table.Column<int>(type: "int", nullable: false),
                    CatCount = table.Column<int>(type: "int", nullable: false),
                    OtherCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherAnimalInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherAnimalInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherBirdInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    DuckCount = table.Column<int>(type: "int", nullable: false),
                    DuckEggCount = table.Column<int>(type: "int", nullable: false),
                    DuckProductionCount = table.Column<int>(type: "int", nullable: false),
                    BattaiCount = table.Column<int>(type: "int", nullable: false),
                    BattaiEggCount = table.Column<int>(type: "int", nullable: false),
                    BattaiProductionCount = table.Column<int>(type: "int", nullable: false),
                    AustrichCount = table.Column<int>(type: "int", nullable: false),
                    AustrichEggCount = table.Column<int>(type: "int", nullable: false),
                    AustrichProductionCount = table.Column<int>(type: "int", nullable: false),
                    KalijCount = table.Column<int>(type: "int", nullable: false),
                    KalijEggCount = table.Column<int>(type: "int", nullable: false),
                    KalijProductionCount = table.Column<int>(type: "int", nullable: false),
                    TurkeyCount = table.Column<int>(type: "int", nullable: false),
                    TurkeyEggCount = table.Column<int>(type: "int", nullable: false),
                    TurkeyProductionCount = table.Column<int>(type: "int", nullable: false),
                    LaukatCount = table.Column<int>(type: "int", nullable: false),
                    LaukatEggCount = table.Column<int>(type: "int", nullable: false),
                    LaukatProductionCount = table.Column<int>(type: "int", nullable: false),
                    PegionCount = table.Column<int>(type: "int", nullable: false),
                    PegionEggCount = table.Column<int>(type: "int", nullable: false),
                    PegionProductionCount = table.Column<int>(type: "int", nullable: false),
                    OtherCount = table.Column<int>(type: "int", nullable: false),
                    OtherEggCount = table.Column<int>(type: "int", nullable: false),
                    OtherProductionCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherBirdInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherBirdInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KrishiFarmInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    DartaNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DartaMiti = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KaryalayeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChairpersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KrishiFarmTypeId = table.Column<int>(type: "int", nullable: false),
                    MemberCount = table.Column<int>(type: "int", nullable: false),
                    EmploymentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrishiFarmInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KrishiFarmInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KrishiFarmInfromation_KrishiFarmType_KrishiFarmTypeId",
                        column: x => x.KrishiFarmTypeId,
                        principalTable: "KrishiFarmType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FishInfromation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalHusbandryId = table.Column<int>(type: "int", nullable: false),
                    IsRahu = table.Column<bool>(type: "bit", nullable: false),
                    IsNaini = table.Column<bool>(type: "bit", nullable: false),
                    IsSilvercarp = table.Column<bool>(type: "bit", nullable: false),
                    IsNaibigheadkarpni = table.Column<bool>(type: "bit", nullable: false),
                    IsGrasscarp = table.Column<bool>(type: "bit", nullable: false),
                    IsComoncarp = table.Column<bool>(type: "bit", nullable: false),
                    IsTrout = table.Column<bool>(type: "bit", nullable: false),
                    Ischadi = table.Column<bool>(type: "bit", nullable: false),
                    IsTilapiya = table.Column<bool>(type: "bit", nullable: false),
                    IsPangas = table.Column<bool>(type: "bit", nullable: false),
                    IsLocal = table.Column<bool>(type: "bit", nullable: false),
                    IsOther = table.Column<bool>(type: "bit", nullable: false),
                    PondArea = table.Column<int>(type: "int", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false),
                    ProcustionUseId = table.Column<int>(type: "int", nullable: false),
                    ProcustionMeasurementId = table.Column<int>(type: "int", nullable: false),
                    ProcustionQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishInfromation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FishInfromation_AnimalHusbandry_AnimalHusbandryId",
                        column: x => x.AnimalHusbandryId,
                        principalTable: "AnimalHusbandry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FishInfromation_ProcustionMeasurement_ProcustionMeasurementId",
                        column: x => x.ProcustionMeasurementId,
                        principalTable: "ProcustionMeasurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FishInfromation_ProcustionUse_ProcustionUseId",
                        column: x => x.ProcustionUseId,
                        principalTable: "ProcustionUse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalHusbandry_FarmerId",
                table: "AnimalHusbandry",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalHusbandry_FiscalYearId",
                table: "AnimalHusbandry",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_BhedaBakhraInfromation_AnimalHusbandryId",
                table: "BhedaBakhraInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_BuffaloInfromation_AnimalHusbandryId",
                table: "BuffaloInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_BungurSungurInfromation_AnimalHusbandryId",
                table: "BungurSungurInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_CharuiYakInfromation_AnimalHusbandryId",
                table: "CharuiYakInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_CowInfromation_AnimalHusbandryId",
                table: "CowInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_FishInfromation_AnimalHusbandryId",
                table: "FishInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_FishInfromation_ProcustionMeasurementId",
                table: "FishInfromation",
                column: "ProcustionMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_FishInfromation_ProcustionUseId",
                table: "FishInfromation",
                column: "ProcustionUseId");

            migrationBuilder.CreateIndex(
                name: "IX_GhaseBaliInfromation_AnimalHusbandryId",
                table: "GhaseBaliInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_GoruInfromation_AnimalHusbandryId",
                table: "GoruInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_HenInfromation_AnimalHusbandryId",
                table: "HenInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_KrishiFarmInfromation_AnimalHusbandryId",
                table: "KrishiFarmInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_KrishiFarmInfromation_KrishiFarmTypeId",
                table: "KrishiFarmInfromation",
                column: "KrishiFarmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_KrishiMechinaryInfromation_AnimalHusbandryId",
                table: "KrishiMechinaryInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_KrishiSanrachanaInfromation_AnimalHusbandryId",
                table: "KrishiSanrachanaInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherAnimalInfromation_AnimalHusbandryId",
                table: "OtherAnimalInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherBirdInfromation_AnimalHusbandryId",
                table: "OtherBirdInfromation",
                column: "AnimalHusbandryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BhedaBakhraInfromation");

            migrationBuilder.DropTable(
                name: "BuffaloInfromation");

            migrationBuilder.DropTable(
                name: "BungurSungurInfromation");

            migrationBuilder.DropTable(
                name: "CharuiYakInfromation");

            migrationBuilder.DropTable(
                name: "CowInfromation");

            migrationBuilder.DropTable(
                name: "FishInfromation");

            migrationBuilder.DropTable(
                name: "GhaseBaliInfromation");

            migrationBuilder.DropTable(
                name: "GoruInfromation");

            migrationBuilder.DropTable(
                name: "HenInfromation");

            migrationBuilder.DropTable(
                name: "KrishiFarmInfromation");

            migrationBuilder.DropTable(
                name: "KrishiMechinaryInfromation");

            migrationBuilder.DropTable(
                name: "KrishiSanrachanaInfromation");

            migrationBuilder.DropTable(
                name: "OtherAnimalInfromation");

            migrationBuilder.DropTable(
                name: "OtherBirdInfromation");

            migrationBuilder.DropTable(
                name: "ProcustionMeasurement");

            migrationBuilder.DropTable(
                name: "ProcustionUse");

            migrationBuilder.DropTable(
                name: "KrishiFarmType");

            migrationBuilder.DropTable(
                name: "AnimalHusbandry");
        }
    }
}
