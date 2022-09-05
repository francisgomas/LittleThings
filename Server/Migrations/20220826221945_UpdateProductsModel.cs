using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class UpdateProductsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Product_ProductId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f27b533a-0735-4e0d-84b3-f4d0962c885c"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("ebba7362-a18c-4800-b0a1-6ccc31a0f204"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1415b4e1-80ff-45f5-bed5-5dbbce206c26"), "Mens" });

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Product_ProductId",
                table: "Image",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Product_ProductId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("1415b4e1-80ff-45f5-bed5-5dbbce206c26"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ebba7362-a18c-4800-b0a1-6ccc31a0f204"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImageURL", "LinkUrl", "Name", "SubCategoryId" },
                values: new object[] { new Guid("f27b533a-0735-4e0d-84b3-f4d0962c885c"), "ss", "shirts", "Shirts", new Guid("ebba7362-a18c-4800-b0a1-6ccc31a0f204") });

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Product_ProductId",
                table: "Image",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
