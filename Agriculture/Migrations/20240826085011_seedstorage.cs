using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agriculture.Migrations
{
    /// <inheritdoc />
    public partial class seedstorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeedStoreContactPerson");

            migrationBuilder.DropTable(
                name: "SeedStoreProduction");

            migrationBuilder.DropTable(
                name: "SeedStore");
        }
    }
}
