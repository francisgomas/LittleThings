using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class UpdateProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("86115f51-41ca-44c1-8d75-8d63efefb65e"));

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f2c29d0b-993f-4a8a-92eb-1d849f2d281e"), "Mens" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("f2c29d0b-993f-4a8a-92eb-1d849f2d281e"));

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
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("86115f51-41ca-44c1-8d75-8d63efefb65e"), "Mens" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");
        }
    }
}
