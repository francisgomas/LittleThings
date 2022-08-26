using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class UpdateImagesListInProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("8facf81d-3832-42cd-ba14-f23449f4d250"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("cd7d3973-6915-4e50-b900-b78a4509d2f4"));

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ebba7362-a18c-4800-b0a1-6ccc31a0f204"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImageURL", "LinkUrl", "Name", "SubCategoryId" },
                values: new object[] { new Guid("f27b533a-0735-4e0d-84b3-f4d0962c885c"), "ss", "shirts", "Shirts", new Guid("ebba7362-a18c-4800-b0a1-6ccc31a0f204") });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f27b533a-0735-4e0d-84b3-f4d0962c885c"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("ebba7362-a18c-4800-b0a1-6ccc31a0f204"));

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cd7d3973-6915-4e50-b900-b78a4509d2f4"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImageURL", "LinkUrl", "Name", "SubCategoryId" },
                values: new object[] { new Guid("8facf81d-3832-42cd-ba14-f23449f4d250"), "ss", "shirts", "Shirts", new Guid("cd7d3973-6915-4e50-b900-b78a4509d2f4") });
        }
    }
}
