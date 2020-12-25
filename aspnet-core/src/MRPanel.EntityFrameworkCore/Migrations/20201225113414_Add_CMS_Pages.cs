using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MRPanel.Migrations
{
    public partial class Add_CMS_Pages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MrpMenus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsExternal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrpMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MrpMenus_MrpMenus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MrpMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MrpSiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    GithubUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrpSiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MrpPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Summery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageType = table.Column<int>(type: "int", nullable: false),
                    IsHomePage = table.Column<bool>(type: "bit", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrpPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MrpPages_MrpMenus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MrpMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MrpWidgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WidgetType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeType = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrpWidgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MrpWidgets_MrpPages_PageId",
                        column: x => x.PageId,
                        principalTable: "MrpPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MrpWidgets_MrpWidgets_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MrpWidgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MrpMenus_ParentId",
                table: "MrpMenus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MrpPages_MenuId",
                table: "MrpPages",
                column: "MenuId",
                unique: true,
                filter: "[MenuId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MrpWidgets_PageId",
                table: "MrpWidgets",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_MrpWidgets_ParentId",
                table: "MrpWidgets",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MrpSiteSettings");

            migrationBuilder.DropTable(
                name: "MrpWidgets");

            migrationBuilder.DropTable(
                name: "MrpPages");

            migrationBuilder.DropTable(
                name: "MrpMenus");
        }
    }
}
