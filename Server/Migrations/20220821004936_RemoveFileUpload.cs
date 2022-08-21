using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class RemoveFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_FileUpload_FileUploadId",
                table: "Category");

            migrationBuilder.DropTable(
                name: "FileUpload");

            migrationBuilder.DropIndex(
                name: "IX_Category_FileUploadId",
                table: "Category");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fda92ff7-a150-49e1-856a-b329d7859996"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("99a6b30d-1961-4441-80d8-b9bded0d602a"));

            migrationBuilder.DropColumn(
                name: "FileUploadId",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cf952f81-8352-42dd-b7c4-32804c173138"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Image", "Name", "SubCategoryId" },
                values: new object[] { new Guid("38b1820c-9edf-4c92-b403-8afeb2db5337"), "ss", "Shirts", new Guid("cf952f81-8352-42dd-b7c4-32804c173138") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("38b1820c-9edf-4c92-b403-8afeb2db5337"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("cf952f81-8352-42dd-b7c4-32804c173138"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Category");

            migrationBuilder.AddColumn<Guid>(
                name: "FileUploadId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FileUpload",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ErrorCode = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoredFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uploaded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.Id);
                });

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
    }
}
