using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class _initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descriptionNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_descriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "priceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articleNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColumnPriceList",
                columns: table => new
                {
                    ColumnsId = table.Column<int>(type: "int", nullable: false),
                    priceListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnPriceList", x => new { x.ColumnsId, x.priceListsId });
                    table.ForeignKey(
                        name: "FK_ColumnPriceList_Columns_ColumnsId",
                        column: x => x.ColumnsId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnPriceList_priceLists_priceListsId",
                        column: x => x.priceListsId,
                        principalTable: "priceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionProduct",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    descriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionProduct", x => new { x.ProductsId, x.descriptionsId });
                    table.ForeignKey(
                        name: "FK_DescriptionProduct_descriptions_descriptionsId",
                        column: x => x.descriptionsId,
                        principalTable: "descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptionProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListProduct",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    priceListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListProduct", x => new { x.ProductsId, x.priceListsId });
                    table.ForeignKey(
                        name: "FK_PriceListProduct_priceLists_priceListsId",
                        column: x => x.priceListsId,
                        principalTable: "priceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceListProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "Id", "DataType", "Name" },
                values: new object[] { 1, "Текст", "Название товара" });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "Id", "DataType", "Name" },
                values: new object[] { 2, "Число", "Код товара" });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnPriceList_priceListsId",
                table: "ColumnPriceList",
                column: "priceListsId");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionProduct_descriptionsId",
                table: "DescriptionProduct",
                column: "descriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListProduct_priceListsId",
                table: "PriceListProduct",
                column: "priceListsId");

            migrationBuilder.CreateIndex(
                name: "IX_priceLists_Name",
                table: "priceLists",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_articleNumber",
                table: "Products",
                column: "articleNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnPriceList");

            migrationBuilder.DropTable(
                name: "DescriptionProduct");

            migrationBuilder.DropTable(
                name: "PriceListProduct");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "descriptions");

            migrationBuilder.DropTable(
                name: "priceLists");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
