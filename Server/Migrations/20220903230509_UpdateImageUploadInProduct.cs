using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class UpdateImageUploadInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("f2c29d0b-993f-4a8a-92eb-1d849f2d281e"));

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "ImageUpload",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c1e0fe6c-ad3a-45d8-8376-79f189f6ada7"), "Mens" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("c1e0fe6c-ad3a-45d8-8376-79f189f6ada7"));

            migrationBuilder.DropColumn(
                name: "ImageUpload",
                table: "Product");

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
    }
}
