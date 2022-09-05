using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class AddDisplayImageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploadResult");

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("527f8e36-8fb1-4edb-ac65-9629e04abe5a"));

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0361e4b9-a370-4443-9b5d-2aba6f7c3442"), "Mens" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("0361e4b9-a370-4443-9b5d-2aba6f7c3442"));

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "UploadResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoredFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadResult_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("527f8e36-8fb1-4edb-ac65-9629e04abe5a"), "Mens" });

            migrationBuilder.CreateIndex(
                name: "IX_UploadResult_ProductId",
                table: "UploadResult",
                column: "ProductId");
        }
    }
}
