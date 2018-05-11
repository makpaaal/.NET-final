using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace final.Migrations
{
    public partial class mainMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryTable",
                columns: table => new
                {
                    Category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTable", x => x.Category_id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTable",
                columns: table => new
                {
                    Product_id = table.Column<int>(nullable: false),
                    Category_id = table.Column<int>(nullable: true),
                    fromPoint = table.Column<string>(nullable: true),
                    seatNumber = table.Column<int>(nullable: false),
                    toPoint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTable", x => x.Product_id);
                    table.ForeignKey(
                        name: "FK_ProductTable_CategoryTable_Category_id",
                        column: x => x.Category_id,
                        principalTable: "CategoryTable",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductTable_CategoryTable_Product_id",
                        column: x => x.Product_id,
                        principalTable: "CategoryTable",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterTable",
                columns: table => new
                {
                    Master_id = table.Column<int>(nullable: false),
                    Customer_id = table.Column<int>(nullable: true),
                    Detail_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTable", x => x.Master_id);
                    table.ForeignKey(
                        name: "FK_MasterTable_CustomerTable_Customer_id",
                        column: x => x.Customer_id,
                        principalTable: "CustomerTable",
                        principalColumn: "Customer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MasterTable_CustomerTable_Master_id",
                        column: x => x.Master_id,
                        principalTable: "CustomerTable",
                        principalColumn: "Customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailTable",
                columns: table => new
                {
                    Detail_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Master_id = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    dateOfFlight = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailTable", x => x.Detail_id);
                    table.ForeignKey(
                        name: "FK_DetailTable_MasterTable_Master_id",
                        column: x => x.Master_id,
                        principalTable: "MasterTable",
                        principalColumn: "Master_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailTable_Master_id",
                table: "DetailTable",
                column: "Master_id");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTable_Customer_id",
                table: "MasterTable",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_MasterTable_Detail_id",
                table: "MasterTable",
                column: "Detail_id",
                unique: true,
                filter: "[Detail_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTable_Category_id",
                table: "ProductTable",
                column: "Category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTable_DetailTable_Product_id",
                table: "ProductTable",
                column: "Product_id",
                principalTable: "DetailTable",
                principalColumn: "Detail_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterTable_DetailTable_Detail_id",
                table: "MasterTable",
                column: "Detail_id",
                principalTable: "DetailTable",
                principalColumn: "Detail_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailTable_MasterTable_Master_id",
                table: "DetailTable");

            migrationBuilder.DropTable(
                name: "ProductTable");

            migrationBuilder.DropTable(
                name: "CategoryTable");

            migrationBuilder.DropTable(
                name: "MasterTable");

            migrationBuilder.DropTable(
                name: "DetailTable");
        }
    }
}
