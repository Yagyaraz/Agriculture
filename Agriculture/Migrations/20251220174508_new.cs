using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "AgricultureEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgricultureEquipment", x => x.Id);
                });

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
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublised = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalSetup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSelect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalSetup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Batch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResumePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameNep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WardId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    FarmerId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
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
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FarmerCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FarmerGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerStore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFromEng = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateToEng = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreviousFiscalYearId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYear", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiscalYear_FiscalYear_PreviousFiscalYearId",
                        column: x => x.PreviousFiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gunasos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gunasos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCenter", x => x.Id);
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
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasuringUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasuringUnit", x => x.Id);
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
                name: "OtherSubsidy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvidedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherSubsidy", x => x.Id);
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
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublised = table.Column<bool>(type: "bit", nullable: false),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
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
                name: "SeedStore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedStore", x => x.Id);
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
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateNameNep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Suchanas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suchanas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Id);
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
                name: "AgriCalendarCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgriCalendarTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriCalendarCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgriCalendarCategory_AgriCalendarType_AgriCalendarTypeId",
                        column: x => x.AgriCalendarTypeId,
                        principalTable: "AgriCalendarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false)
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
                name: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Library_AgriSector_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AgriSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    IsPublised = table.Column<bool>(type: "bit", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageGallery_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerStoreContactPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FertilizerStoreId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerStoreContactPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizerStoreContactPerson_FertilizerStore_FertilizerStoreId",
                        column: x => x.FertilizerStoreId,
                        principalTable: "FertilizerStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false)
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
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PremiumId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrainingTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Organizer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_AgriSector_TrainingTypeId",
                        column: x => x.TrainingTypeId,
                        principalTable: "AgriSector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Training_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MarketPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketPrice_Market_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryUnitId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCategory_MeasuringUnit_CategoryUnitId",
                        column: x => x.CategoryUnitId,
                        principalTable: "MeasuringUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherSubsidyQns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtherSubsidyId = table.Column<int>(type: "int", nullable: false),
                    Qns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherSubsidyQns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherSubsidyQns_OtherSubsidy_OtherSubsidyId",
                        column: x => x.OtherSubsidyId,
                        principalTable: "OtherSubsidy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    IsPublised = table.Column<bool>(type: "bit", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGallery_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeedStoreContactPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeedStoreId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedStoreContactPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeedStoreContactPerson_SeedStore_SeedStoreId",
                        column: x => x.SeedStoreId,
                        principalTable: "SeedStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    DistrictNameNep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistrictCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_District_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AgriCalendarProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgriCalendarTypeId = table.Column<int>(type: "int", nullable: false),
                    AgriCalendarCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgriCalendarProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgriCalendarProduct_AgriCalendarCategory_AgriCalendarCategoryId",
                        column: x => x.AgriCalendarCategoryId,
                        principalTable: "AgriCalendarCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgriCalendarProduct_AgriCalendarType_AgriCalendarTypeId",
                        column: x => x.AgriCalendarTypeId,
                        principalTable: "AgriCalendarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nabikarans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RenewDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReneweFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RasidNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nabikarans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nabikarans_AgricultureFarmerGroup_FirmId",
                        column: x => x.FirmId,
                        principalTable: "AgricultureFarmerGroup",
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

            migrationBuilder.CreateTable(
                name: "AgricultureProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
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
                name: "MarketPriceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketPriceId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WholesalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPriceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketPriceDetails_MarketPrice_MarketPriceId",
                        column: x => x.MarketPriceId,
                        principalTable: "MarketPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Palika",
                columns: table => new
                {
                    PalikaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    PalikaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PalikaNameNep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PalikaCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palika", x => x.PalikaId);
                    table.ForeignKey(
                        name: "FK_Palika_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "FertilizerStoreProduction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FertilizerStoreId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerStoreProduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizerStoreProduction_AgriCalendarCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AgriCalendarCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FertilizerStoreProduction_AgriCalendarProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AgriCalendarProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FertilizerStoreProduction_AgriCalendarType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AgriCalendarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FertilizerStoreProduction_FertilizerStore_FertilizerStoreId",
                        column: x => x.FertilizerStoreId,
                        principalTable: "FertilizerStore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeedStoreProduction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeedStoreId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedStoreProduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeedStoreProduction_AgriCalendarCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AgriCalendarCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeedStoreProduction_AgriCalendarProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AgriCalendarProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeedStoreProduction_AgriCalendarType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AgriCalendarType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeedStoreProduction_SeedStore_SeedStoreId",
                        column: x => x.SeedStoreId,
                        principalTable: "SeedStore",
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
                    ValidTillDateEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
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
                name: "Subsidy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsidy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subsidy_AgricultureProgram_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "AgricultureProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsidy_AgricultureProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "AgricultureProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subsidy_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Farmer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    PalikaId = table.Column<int>(type: "int", nullable: false),
                    WardNo = table.Column<int>(type: "int", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    DOBNep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOBEng = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    EducationLevelId = table.Column<int>(type: "int", nullable: true),
                    TolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenDistricrId = table.Column<int>(type: "int", nullable: false),
                    CitizenIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmerGroupId = table.Column<int>(type: "int", nullable: false),
                    FarmerCategoryId = table.Column<int>(type: "int", nullable: false),
                    HouseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Farmer_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmer_EducationLevel_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmer_Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Education",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmer_FarmerCategory_FarmerCategoryId",
                        column: x => x.FarmerCategoryId,
                        principalTable: "FarmerCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmer_FarmerGroup_FarmerGroupId",
                        column: x => x.FarmerGroupId,
                        principalTable: "FarmerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmer_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmer_Palika_PalikaId",
                        column: x => x.PalikaId,
                        principalTable: "Palika",
                        principalColumn: "PalikaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farmer_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    PalikaId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_Palika_PalikaId",
                        column: x => x.PalikaId,
                        principalTable: "Palika",
                        principalColumn: "PalikaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Office_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
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
                    HarvestEndWeekId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "SubsidyDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubsidyId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsidyDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubsidyDetail_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubsidyDetail_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubsidyDetail_Subsidy_SubsidyId",
                        column: x => x.SubsidyId,
                        principalTable: "Subsidy",
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
                    CitizenPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandOwnershipPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDetailPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PanjikaranPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SthailekhaPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinutePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfdecisionPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approvestatus = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_AgricultureApplicatoionForm_FarmerGroup_AgriGroupId",
                        column: x => x.AgriGroupId,
                        principalTable: "FarmerGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgricultureApplicatoionForm_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
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
                    table.ForeignKey(
                        name: "FK_FamilyDetails_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FarmerFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    ProfilePicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenFrontPicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenFrontPicPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenBackPicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenBackPicPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerFile_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerServiceCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmerServiceCard_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmerServiceCard_FiscalYear_FiscalYearId",
                        column: x => x.FiscalYearId,
                        principalTable: "FiscalYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "KrishiDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    FiscalYearId = table.Column<int>(type: "int", nullable: false),
                    IsSelfJagga = table.Column<bool>(type: "bit", nullable: false),
                    ChooseLand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBigaha = table.Column<int>(type: "int", nullable: true),
                    TotalKattha = table.Column<int>(type: "int", nullable: true),
                    TotalDhur = table.Column<int>(type: "int", nullable: true),
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
                name: "SaveRequestedSubsidy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubsidyId = table.Column<int>(type: "int", nullable: false),
                    SubsidyDetailId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalRequired = table.Column<int>(type: "int", nullable: false),
                    CreatedWardId = table.Column<int>(type: "int", nullable: false),
                    FarmerId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaveRequestedSubsidy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaveRequestedSubsidy_Farmer_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ProcustionUseId = table.Column<int>(type: "int", nullable: true),
                    ProcustionMeasurementId = table.Column<int>(type: "int", nullable: true),
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
                    KrishiFarmTypeId = table.Column<int>(type: "int", nullable: true),
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
                    PhoneNumbar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "IX_AgriCalendarCategory_AgriCalendarTypeId",
                table: "AgriCalendarCategory",
                column: "AgriCalendarTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarProduct_AgriCalendarCategoryId",
                table: "AgriCalendarProduct",
                column: "AgriCalendarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AgriCalendarProduct_AgriCalendarTypeId",
                table: "AgriCalendarProduct",
                column: "AgriCalendarTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureApplicatoionForm_AgriGroupId",
                table: "AgricultureApplicatoionForm",
                column: "AgriGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureApplicatoionForm_FarmerId",
                table: "AgricultureApplicatoionForm",
                column: "FarmerId");

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
                name: "IX_AgricultureDetail_AgriSectorId",
                table: "AgricultureDetail",
                column: "AgriSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureDetail_KrishiDetailsId",
                table: "AgricultureDetail",
                column: "KrishiDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AgricultureFarmerGroup_AgriGroupTypeId",
                table: "AgricultureFarmerGroup",
                column: "AgriGroupTypeId");

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
                name: "IX_AnimalHusbandry_FarmerId",
                table: "AnimalHusbandry",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalHusbandry_FiscalYearId",
                table: "AnimalHusbandry",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BeeCrops_BeeTypeId",
                table: "BeeCrops",
                column: "BeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BeeCrops_CropsInformationId",
                table: "BeeCrops",
                column: "CropsInformationId");

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
                name: "IX_CropsInformation_FarmerId",
                table: "CropsInformation",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_District_StateId",
                table: "District",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_EatableCrops_CropsInformationId",
                table: "EatableCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EatableCrops_CropsTypeId",
                table: "EatableCrops",
                column: "CropsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_FarmerId",
                table: "FamilyDetails",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_FiscalYearId",
                table: "FamilyDetails",
                column: "FiscalYearId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_DistrictId",
                table: "Farmer",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_EducationId",
                table: "Farmer",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_EducationLevelId",
                table: "Farmer",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_FarmerCategoryId",
                table: "Farmer",
                column: "FarmerCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_FarmerGroupId",
                table: "Farmer",
                column: "FarmerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_GenderId",
                table: "Farmer",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_PalikaId",
                table: "Farmer",
                column: "PalikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmer_StateId",
                table: "Farmer",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerFile_FarmerId",
                table: "FarmerFile",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerServiceCard_FarmerId",
                table: "FarmerServiceCard",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmerServiceCard_FiscalYearId",
                table: "FarmerServiceCard",
                column: "FiscalYearId");

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

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerStoreContactPerson_FertilizerStoreId",
                table: "FertilizerStoreContactPerson",
                column: "FertilizerStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerStoreProduction_CategoryId",
                table: "FertilizerStoreProduction",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerStoreProduction_FertilizerStoreId",
                table: "FertilizerStoreProduction",
                column: "FertilizerStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerStoreProduction_ProductId",
                table: "FertilizerStoreProduction",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerStoreProduction_TypeId",
                table: "FertilizerStoreProduction",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDetails_FarmerId",
                table: "FieldDetails",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldDetails_FiscalYearId",
                table: "FieldDetails",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYear_PreviousFiscalYearId",
                table: "FiscalYear",
                column: "PreviousFiscalYearId");

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
                name: "IX_FruitCrops_CropsInformationId",
                table: "FruitCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_FruitCrops_FruitsTypeId",
                table: "FruitCrops",
                column: "FruitsTypeId");

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
                name: "IX_ImageGallery_AlbumId",
                table: "ImageGallery",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_KrishiDetails_AvgMonthForAgriId",
                table: "KrishiDetails",
                column: "AvgMonthForAgriId");

            migrationBuilder.CreateIndex(
                name: "IX_KrishiDetails_FarmerId",
                table: "KrishiDetails",
                column: "FarmerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Library_TypeId",
                table: "Library",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPrice_MarketId",
                table: "MarketPrice",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketPriceDetails_MarketPriceId",
                table: "MarketPriceDetails",
                column: "MarketPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_MushroomCrpos_CropsInformationId",
                table: "MushroomCrpos",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MushroomCrpos_MushroomTypeId",
                table: "MushroomCrpos",
                column: "MushroomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nabikarans_FirmId",
                table: "Nabikarans",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_DistrictId",
                table: "Office",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_PalikaId",
                table: "Office",
                column: "PalikaId");

            migrationBuilder.CreateIndex(
                name: "IX_Office_StateId",
                table: "Office",
                column: "StateId");

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

            migrationBuilder.CreateIndex(
                name: "IX_OtherAnimalInfromation_AnimalHusbandryId",
                table: "OtherAnimalInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherBirdInfromation_AnimalHusbandryId",
                table: "OtherBirdInfromation",
                column: "AnimalHusbandryId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherSubsidyQns_OtherSubsidyId",
                table: "OtherSubsidyQns",
                column: "OtherSubsidyId");

            migrationBuilder.CreateIndex(
                name: "IX_Palika_DistrictId",
                table: "Palika",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_SaveRequestedSubsidy_FarmerId",
                table: "SaveRequestedSubsidy",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedCrops_CropsInformationId",
                table: "SeedCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedCrops_SeedsTypeId",
                table: "SeedCrops",
                column: "SeedsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedStoreContactPerson_SeedStoreId",
                table: "SeedStoreContactPerson",
                column: "SeedStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedStoreProduction_CategoryId",
                table: "SeedStoreProduction",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedStoreProduction_ProductId",
                table: "SeedStoreProduction",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedStoreProduction_SeedStoreId",
                table: "SeedStoreProduction",
                column: "SeedStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedStoreProduction_TypeId",
                table: "SeedStoreProduction",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SilkCrops_CropsInformationId",
                table: "SilkCrops",
                column: "CropsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_SilkCrops_SilkTypeId",
                table: "SilkCrops",
                column: "SilkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryUnitId",
                table: "SubCategory",
                column: "CategoryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsidy_FiscalYearId",
                table: "Subsidy",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsidy_ProgramId",
                table: "Subsidy",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsidy_ProjectId",
                table: "Subsidy",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubsidyDetail_CategoryId",
                table: "SubsidyDetail",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubsidyDetail_SubCategoryId",
                table: "SubsidyDetail",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubsidyDetail_SubsidyId",
                table: "SubsidyDetail",
                column: "SubsidyId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_FiscalYearId",
                table: "Training",
                column: "FiscalYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_TrainingTypeId",
                table: "Training",
                column: "TrainingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGallery_PlaylistId",
                table: "VideoGallery",
                column: "PlaylistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgriCalendarDetail");

            migrationBuilder.DropTable(
                name: "AgricultureApplicatoionForm");

            migrationBuilder.DropTable(
                name: "AgricultureDetail");

            migrationBuilder.DropTable(
                name: "AgricultureEquipment");

            migrationBuilder.DropTable(
                name: "AgricultureServiceAdditional");

            migrationBuilder.DropTable(
                name: "AgriFarmMoreThanOneLocalLevel");

            migrationBuilder.DropTable(
                name: "AnimalSetup");

            migrationBuilder.DropTable(
                name: "ApplicationForms");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BeeCrops");

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
                name: "EatableCrops");

            migrationBuilder.DropTable(
                name: "FamilyDetailsInvolvedInAgri");

            migrationBuilder.DropTable(
                name: "FarmerFile");

            migrationBuilder.DropTable(
                name: "FarmerServiceCardDetail");

            migrationBuilder.DropTable(
                name: "FertilizerStoreContactPerson");

            migrationBuilder.DropTable(
                name: "FertilizerStoreProduction");

            migrationBuilder.DropTable(
                name: "FishInfromation");

            migrationBuilder.DropTable(
                name: "FruitCrops");

            migrationBuilder.DropTable(
                name: "GhaseBaliInfromation");

            migrationBuilder.DropTable(
                name: "GoruInfromation");

            migrationBuilder.DropTable(
                name: "Gunasos");

            migrationBuilder.DropTable(
                name: "HenInfromation");

            migrationBuilder.DropTable(
                name: "ImageGallery");

            migrationBuilder.DropTable(
                name: "InsuranceCenter");

            migrationBuilder.DropTable(
                name: "KrishiFarmInfromation");

            migrationBuilder.DropTable(
                name: "KrishiMechinaryInfromation");

            migrationBuilder.DropTable(
                name: "KrishiSanrachanaInfromation");

            migrationBuilder.DropTable(
                name: "LandOwnership");

            migrationBuilder.DropTable(
                name: "LeasedLandDetail");

            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropTable(
                name: "MarketPriceDetails");

            migrationBuilder.DropTable(
                name: "MushroomCrpos");

            migrationBuilder.DropTable(
                name: "Nabikarans");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "OfficialsDetail");

            migrationBuilder.DropTable(
                name: "OtherAnimalInfromation");

            migrationBuilder.DropTable(
                name: "OtherBirdInfromation");

            migrationBuilder.DropTable(
                name: "OtherSubsidyQns");

            migrationBuilder.DropTable(
                name: "SaveRequestedSubsidy");

            migrationBuilder.DropTable(
                name: "SeedCrops");

            migrationBuilder.DropTable(
                name: "SeedStoreContactPerson");

            migrationBuilder.DropTable(
                name: "SeedStoreProduction");

            migrationBuilder.DropTable(
                name: "SilkCrops");

            migrationBuilder.DropTable(
                name: "SubsidyDetail");

            migrationBuilder.DropTable(
                name: "Suchanas");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "VideoGallery");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "AgriCalendar");

            migrationBuilder.DropTable(
                name: "EcologicalArea");

            migrationBuilder.DropTable(
                name: "Month");

            migrationBuilder.DropTable(
                name: "Week");

            migrationBuilder.DropTable(
                name: "KrishiDetails");

            migrationBuilder.DropTable(
                name: "AgricultureService");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BeeType");

            migrationBuilder.DropTable(
                name: "CropsType");

            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "Relation");

            migrationBuilder.DropTable(
                name: "WorkingArea");

            migrationBuilder.DropTable(
                name: "AgriService");

            migrationBuilder.DropTable(
                name: "FarmerServiceCard");

            migrationBuilder.DropTable(
                name: "FertilizerStore");

            migrationBuilder.DropTable(
                name: "ProcustionMeasurement");

            migrationBuilder.DropTable(
                name: "ProcustionUse");

            migrationBuilder.DropTable(
                name: "FruitsType");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "KrishiFarmType");

            migrationBuilder.DropTable(
                name: "FieldDetails");

            migrationBuilder.DropTable(
                name: "IrrigationSource");

            migrationBuilder.DropTable(
                name: "LandType");

            migrationBuilder.DropTable(
                name: "OwnershipType");

            migrationBuilder.DropTable(
                name: "MarketPrice");

            migrationBuilder.DropTable(
                name: "MushroomType");

            migrationBuilder.DropTable(
                name: "AgricultureFarmerGroup");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "AnimalHusbandry");

            migrationBuilder.DropTable(
                name: "OtherSubsidy");

            migrationBuilder.DropTable(
                name: "SeedsType");

            migrationBuilder.DropTable(
                name: "SeedStore");

            migrationBuilder.DropTable(
                name: "CropsInformation");

            migrationBuilder.DropTable(
                name: "SilkType");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Subsidy");

            migrationBuilder.DropTable(
                name: "AgriSector");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "AgriCalendarProduct");

            migrationBuilder.DropTable(
                name: "AvgMonth");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "AgriGroupType");

            migrationBuilder.DropTable(
                name: "Farmer");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "MeasuringUnit");

            migrationBuilder.DropTable(
                name: "AgricultureProject");

            migrationBuilder.DropTable(
                name: "AgriCalendarCategory");

            migrationBuilder.DropTable(
                name: "EducationLevel");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "FarmerCategory");

            migrationBuilder.DropTable(
                name: "FarmerGroup");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Palika");

            migrationBuilder.DropTable(
                name: "AgricultureProgram");

            migrationBuilder.DropTable(
                name: "AgriCalendarType");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "FiscalYear");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
