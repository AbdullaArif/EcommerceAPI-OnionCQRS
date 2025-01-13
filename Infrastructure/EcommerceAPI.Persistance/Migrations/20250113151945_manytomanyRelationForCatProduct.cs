using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class manytomanyRelationForCatProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 13, 19, 19, 45, 630, DateTimeKind.Local).AddTicks(588), "Baby" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 13, 19, 19, 45, 630, DateTimeKind.Local).AddTicks(725), "Toys, Toys & Tools" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 13, 19, 19, 45, 630, DateTimeKind.Local).AddTicks(734), "Jewelery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 13, 19, 19, 45, 630, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 1, 13, 19, 19, 45, 630, DateTimeKind.Local).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 1, 13, 19, 19, 45, 630, DateTimeKind.Local).AddTicks(4845));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 1, 13, 19, 19, 45, 630, DateTimeKind.Local).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 13, 19, 19, 45, 633, DateTimeKind.Local).AddTicks(9498), "Accusantium libero neque inventore quibusdam.", "Odio." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 13, 19, 19, 45, 633, DateTimeKind.Local).AddTicks(9542), "Eveniet cupiditate nostrum quia dignissimos.", "Provident nulla." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Description", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 13, 19, 19, 45, 633, DateTimeKind.Local).AddTicks(9577), "Laboriosam nulla maiores aut quisquam.", "Aut." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 13, 19, 19, 45, 638, DateTimeKind.Local).AddTicks(886), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 7.09131407183668m, 612.768916406886400m, "Intelligent Cotton Pizza" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 13, 19, 19, 45, 638, DateTimeKind.Local).AddTicks(916), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 9.086132047210489m, 984.598682687621200m, "Tasty Soft Table" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 9, 19, 35, 20, 218, DateTimeKind.Local).AddTicks(5865), "Grocery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 9, 19, 35, 20, 218, DateTimeKind.Local).AddTicks(6416), "Books & Books" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 9, 19, 35, 20, 218, DateTimeKind.Local).AddTicks(6435), "Home, Music & Music" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 9, 19, 35, 20, 218, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 1, 9, 19, 35, 20, 218, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 1, 9, 19, 35, 20, 218, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 1, 9, 19, 35, 20, 218, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 9, 19, 35, 20, 222, DateTimeKind.Local).AddTicks(2325), "Expedita voluptates mollitia id consequatur.", "Voluptates." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 9, 19, 35, 20, 222, DateTimeKind.Local).AddTicks(2374), "Ea velit sit quia dolorem.", "Rerum id." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "Description", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 9, 19, 35, 20, 222, DateTimeKind.Local).AddTicks(2404), "Placeat et eum sequi facere.", "Et." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 9, 19, 35, 20, 225, DateTimeKind.Local).AddTicks(5056), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 8.284953021602041m, 275.556055709736100m, "Intelligent Metal Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "Description", "Discount", "Price", "Tittle" },
                values: new object[] { new DateTime(2025, 1, 9, 19, 35, 20, 225, DateTimeKind.Local).AddTicks(5088), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 8.523396258429475m, 516.067771209198400m, "Rustic Steel Pants" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
