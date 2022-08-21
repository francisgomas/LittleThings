using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class RemoveRequiredFromSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a4abceb9-22ba-4de2-ad57-a3400d3c84ca"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("efe0ee6d-fdbf-4606-ac6e-912eecce7960"));

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("649c4f84-1251-4e5b-98bd-b70d8bb724a1"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImageURL", "Name", "SubCategoryId" },
                values: new object[] { new Guid("05cb6b6b-3284-4c35-afd7-b51eb376b542"), "ss", "Shirts", new Guid("649c4f84-1251-4e5b-98bd-b70d8bb724a1") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("05cb6b6b-3284-4c35-afd7-b51eb376b542"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("649c4f84-1251-4e5b-98bd-b70d8bb724a1"));

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("efe0ee6d-fdbf-4606-ac6e-912eecce7960"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImageURL", "Name", "SubCategoryId" },
                values: new object[] { new Guid("a4abceb9-22ba-4de2-ad57-a3400d3c84ca"), "ss", "Shirts", new Guid("efe0ee6d-fdbf-4606-ac6e-912eecce7960") });
        }
    }
}
