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
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "priceLists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priceLists", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ColumnPriceList",
                columns: table => new
                {
                    Columnsid = table.Column<int>(type: "int", nullable: false),
                    priceListsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnPriceList", x => new { x.Columnsid, x.priceListsid });
                    table.ForeignKey(
                        name: "FK_ColumnPriceList_Columns_Columnsid",
                        column: x => x.Columnsid,
                        principalTable: "Columns",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColumnPriceList_priceLists_priceListsid",
                        column: x => x.priceListsid,
                        principalTable: "priceLists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListProduct",
                columns: table => new
                {
                    Productsid = table.Column<int>(type: "int", nullable: false),
                    priceListsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListProduct", x => new { x.Productsid, x.priceListsid });
                    table.ForeignKey(
                        name: "FK_PriceListProduct_priceLists_priceListsid",
                        column: x => x.priceListsid,
                        principalTable: "priceLists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceListProduct_Products_Productsid",
                        column: x => x.Productsid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "id", "DataType", "Name" },
                values: new object[] { 1, "Текст", "Название товара" });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "id", "DataType", "Name" },
                values: new object[] { 2, "Число", "Код товара" });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnPriceList_priceListsid",
                table: "ColumnPriceList",
                column: "priceListsid");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListProduct_priceListsid",
                table: "PriceListProduct",
                column: "priceListsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnPriceList");

            migrationBuilder.DropTable(
                name: "PriceListProduct");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "priceLists");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
