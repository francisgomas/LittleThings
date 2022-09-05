using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class UpdateImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("43007bd7-2684-4881-afc0-b5c93aedb4c9"), "Mens" });

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Product_ProductId",
                table: "Image",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Product_ProductId",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("43007bd7-2684-4881-afc0-b5c93aedb4c9"));

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
    }
}
