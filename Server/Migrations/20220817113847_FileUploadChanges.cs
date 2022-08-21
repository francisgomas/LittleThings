using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class FileUploadChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FileUpload",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ErrorCode",
                table: "FileUpload",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StoredFileName",
                table: "FileUpload",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Uploaded",
                table: "FileUpload",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("16535bbb-c7da-42a5-9b5c-bf0222df7c04"), "Mens" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "FileUploadId", "Name", "SubCategoryId" },
                values: new object[] { new Guid("a1e85aeb-4943-4658-a0c4-d0dc27d3485c"), new Guid("00000000-0000-0000-0000-000000000000"), "Shirts", new Guid("16535bbb-c7da-42a5-9b5c-bf0222df7c04") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a1e85aeb-4943-4658-a0c4-d0dc27d3485c"));

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("16535bbb-c7da-42a5-9b5c-bf0222df7c04"));

            migrationBuilder.DropColumn(
                name: "ErrorCode",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "StoredFileName",
                table: "FileUpload");

            migrationBuilder.DropColumn(
                name: "Uploaded",
                table: "FileUpload");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FileUpload",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
