using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class ChangeToSingleFileUploadProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("0361e4b9-a370-4443-9b5d-2aba6f7c3442"));

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Product",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d0a40596-4ad1-4e7f-bda3-3997f2673548"), "Mens" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("d0a40596-4ad1-4e7f-bda3-3997f2673548"));

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Product",
                newName: "Images");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0361e4b9-a370-4443-9b5d-2aba6f7c3442"), "Mens" });
        }
    }
}
