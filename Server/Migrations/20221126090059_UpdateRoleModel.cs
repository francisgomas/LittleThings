using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class UpdateRoleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("d0a40596-4ad1-4e7f-bda3-3997f2673548"));

            migrationBuilder.AddColumn<string>(
                name: "RoleDescription",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleDescription",
                value: "Custom role for Customer");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleDescription", "RoleName" },
                values: new object[] { 3, "Custom role for Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("577c37ca-2972-4e81-bfff-5efb7705290c"), "Mens" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("577c37ca-2972-4e81-bfff-5efb7705290c"));

            migrationBuilder.DropColumn(
                name: "RoleDescription",
                table: "Role");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d0a40596-4ad1-4e7f-bda3-3997f2673548"), "Mens" });
        }
    }
}
