using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class storekofertilization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FertilizerStoreContactPerson");

            migrationBuilder.DropTable(
                name: "FertilizerStoreProduction");

            migrationBuilder.DropTable(
                name: "FertilizerStore");
        }
    }
}
