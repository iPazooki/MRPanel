using Microsoft.EntityFrameworkCore.Migrations;

namespace MRPanel.Migrations
{
    public partial class Site_Setting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(maxLength: 256, nullable: false),
                    Slogan = table.Column<string>(maxLength: 256, nullable: true),
                    FacebookUrl = table.Column<string>(maxLength: 256, nullable: true),
                    TwitterUrl = table.Column<string>(maxLength: 256, nullable: true),
                    InstagramUrl = table.Column<string>(maxLength: 256, nullable: true),
                    GithubUrl = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteSettings");
        }
    }
}
