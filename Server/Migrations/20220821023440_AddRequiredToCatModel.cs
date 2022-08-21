using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class AddRequiredToCatModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("38b1820c-9edf-4c92-b403-8afeb2db5337"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("cf952f81-8352-42dd-b7c4-32804c173138"));

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a863c962-207f-4486-9c0c-6bbd95de18f2"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Image", "Name", "SubCategoryId" },
                values: new object[] { new Guid("e0ef2ca8-7dc1-4bb2-8eff-1509d9d7d8ee"), "ss", "Shirts", new Guid("a863c962-207f-4486-9c0c-6bbd95de18f2") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e0ef2ca8-7dc1-4bb2-8eff-1509d9d7d8ee"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("a863c962-207f-4486-9c0c-6bbd95de18f2"));

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cf952f81-8352-42dd-b7c4-32804c173138"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Image", "Name", "SubCategoryId" },
                values: new object[] { new Guid("38b1820c-9edf-4c92-b403-8afeb2db5337"), "ss", "Shirts", new Guid("cf952f81-8352-42dd-b7c4-32804c173138") });
        }
    }
}
