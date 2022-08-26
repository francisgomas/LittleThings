using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class AddLinkURLFieldCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("05cb6b6b-3284-4c35-afd7-b51eb376b542"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("649c4f84-1251-4e5b-98bd-b70d8bb724a1"));

            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("448ed1fc-19ab-46b3-a74f-c6b3f44c1f6e"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImageURL", "LinkUrl", "Name", "SubCategoryId" },
                values: new object[] { new Guid("58ae2bf7-a6c1-4d66-895c-317092d56931"), "ss", "shirts", "Shirts", new Guid("448ed1fc-19ab-46b3-a74f-c6b3f44c1f6e") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("58ae2bf7-a6c1-4d66-895c-317092d56931"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("448ed1fc-19ab-46b3-a74f-c6b3f44c1f6e"));

            migrationBuilder.DropColumn(
                name: "LinkUrl",
                table: "Category");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("649c4f84-1251-4e5b-98bd-b70d8bb724a1"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "ImageURL", "Name", "SubCategoryId" },
                values: new object[] { new Guid("05cb6b6b-3284-4c35-afd7-b51eb376b542"), "ss", "Shirts", new Guid("649c4f84-1251-4e5b-98bd-b70d8bb724a1") });
        }
    }
}
