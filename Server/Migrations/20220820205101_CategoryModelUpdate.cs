using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class CategoryModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fde20057-d3ff-42b7-80dc-8aaa6dfdc7d9"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("6956be7a-c958-4d3d-a279-31260c303fc1"));

            migrationBuilder.AddColumn<Guid>(
                name: "FileUploadId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "FileUpload",
                columns: new[] { "Id", "ErrorCode", "FileName", "StoredFileName", "Uploaded" },
                values: new object[] { new Guid("adc6fe75-f713-4ad1-a324-74ba71003319"), 0, "xyz", "xyz", true });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("99a6b30d-1961-4441-80d8-b9bded0d602a"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "FileUploadId", "Name", "SubCategoryId" },
                values: new object[] { new Guid("fda92ff7-a150-49e1-856a-b329d7859996"), new Guid("adc6fe75-f713-4ad1-a324-74ba71003319"), "Shirts", new Guid("99a6b30d-1961-4441-80d8-b9bded0d602a") });

            migrationBuilder.CreateIndex(
                name: "IX_Category_FileUploadId",
                table: "Category",
                column: "FileUploadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_FileUpload_FileUploadId",
                table: "Category",
                column: "FileUploadId",
                principalTable: "FileUpload",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_FileUpload_FileUploadId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_FileUploadId",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fda92ff7-a150-49e1-856a-b329d7859996"));

            migrationBuilder.DeleteData(
                table: "FileUpload",
                keyColumn: "Id",
                keyValue: new Guid("adc6fe75-f713-4ad1-a324-74ba71003319"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("99a6b30d-1961-4441-80d8-b9bded0d602a"));

            migrationBuilder.DropColumn(
                name: "FileUploadId",
                table: "Category");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6956be7a-c958-4d3d-a279-31260c303fc1"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "SubCategoryId" },
                values: new object[] { new Guid("fde20057-d3ff-42b7-80dc-8aaa6dfdc7d9"), "Shirts", new Guid("6956be7a-c958-4d3d-a279-31260c303fc1") });
        }
    }
}
