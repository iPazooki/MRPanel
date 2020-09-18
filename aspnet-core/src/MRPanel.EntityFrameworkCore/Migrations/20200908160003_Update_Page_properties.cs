using Microsoft.EntityFrameworkCore.Migrations;

namespace MRPanel.Migrations
{
    public partial class Update_Page_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContentPlace",
                table: "Pages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsMainPage",
                table: "Pages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentPlace",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsMainPage",
                table: "Pages");
        }
    }
}
