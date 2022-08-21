using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class FileUploadModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a1e85aeb-4943-4658-a0c4-d0dc27d3485c"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("16535bbb-c7da-42a5-9b5c-bf0222df7c04"));

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6956be7a-c958-4d3d-a279-31260c303fc1"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "SubCategoryId" },
                values: new object[] { new Guid("fde20057-d3ff-42b7-80dc-8aaa6dfdc7d9"), "Shirts", new Guid("6956be7a-c958-4d3d-a279-31260c303fc1") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fde20057-d3ff-42b7-80dc-8aaa6dfdc7d9"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("6956be7a-c958-4d3d-a279-31260c303fc1"));

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("16535bbb-c7da-42a5-9b5c-bf0222df7c04"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "SubCategoryId" },
                values: new object[] { new Guid("a1e85aeb-4943-4658-a0c4-d0dc27d3485c"), "Shirts", new Guid("16535bbb-c7da-42a5-9b5c-bf0222df7c04") });
        }
    }
}
