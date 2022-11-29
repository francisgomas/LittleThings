using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class UpdateRoleClaimModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("a07189b4-afef-491c-8cea-ef763539fb22"));

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "RoleClaim",
                newName: "ControllerName");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "RoleClaim",
                newName: "ActionName");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("516cd5af-e015-4fbe-b517-0d44030ba9ad"), "Mens" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: new Guid("516cd5af-e015-4fbe-b517-0d44030ba9ad"));

            migrationBuilder.RenameColumn(
                name: "ControllerName",
                table: "RoleClaim",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "ActionName",
                table: "RoleClaim",
                newName: "ClaimType");

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a07189b4-afef-491c-8cea-ef763539fb22"), "Mens" });
        }
    }
}
