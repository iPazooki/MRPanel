using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MRPanel.Migrations
{
    public partial class Add_CMS_Objects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    PageId = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    IsExternal = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Summery = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    PageType = table.Column<int>(nullable: false),
                    IsHomePage = table.Column<bool>(nullable: false),
                    MenuId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Widgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WidgetType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ImageAddress = table.Column<string>(nullable: true),
                    SizeType = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    PageId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Widgets_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Widgets_Widgets_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Widgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentId",
                table: "Menus",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_MenuId",
                table: "Pages",
                column: "MenuId",
                unique: true,
                filter: "[MenuId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_PageId",
                table: "Widgets",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Widgets_ParentId",
                table: "Widgets",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Widgets");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
