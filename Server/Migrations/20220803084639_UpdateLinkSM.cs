using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleThings.Server.Migrations
{
    public partial class UpdateLinkSM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SocialMedia",
                keyColumn: "Id",
                keyValue: 1,
                column: "Link",
                value: "https://www.facebook.com/");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SocialMedia",
                keyColumn: "Id",
                keyValue: 1,
                column: "Link",
                value: "ss");
        }
    }
}
