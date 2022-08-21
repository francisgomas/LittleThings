using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class ChangeImageUrlColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e0ef2ca8-7dc1-4bb2-8eff-1509d9d7d8ee"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("a863c962-207f-4486-9c0c-6bbd95de18f2"));

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Category",
                newName: "ImageURL");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("efe0ee6d-fdbf-4606-ac6e-912eecce7960"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImageURL", "Name", "SubCategoryId" },
                values: new object[] { new Guid("a4abceb9-22ba-4de2-ad57-a3400d3c84ca"), "ss", "Shirts", new Guid("efe0ee6d-fdbf-4606-ac6e-912eecce7960") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a4abceb9-22ba-4de2-ad57-a3400d3c84ca"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("efe0ee6d-fdbf-4606-ac6e-912eecce7960"));

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Category",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a863c962-207f-4486-9c0c-6bbd95de18f2"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Image", "Name", "SubCategoryId" },
                values: new object[] { new Guid("e0ef2ca8-7dc1-4bb2-8eff-1509d9d7d8ee"), "ss", "Shirts", new Guid("a863c962-207f-4486-9c0c-6bbd95de18f2") });
        }
    }
}
