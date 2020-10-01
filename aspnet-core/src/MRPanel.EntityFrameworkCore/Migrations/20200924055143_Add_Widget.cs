using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MRPanel.Migrations
{
    public partial class Add_Widget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Widget",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WidgetType = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ImageAddress = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    PageId = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Widget_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Widget_Widget_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Widget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Widget_PageId",
                table: "Widget",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Widget_ParentId",
                table: "Widget",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Widget");
        }
    }
}
