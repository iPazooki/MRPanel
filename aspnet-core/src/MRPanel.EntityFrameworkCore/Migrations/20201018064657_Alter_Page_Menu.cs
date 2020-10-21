using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MRPanel.Migrations
{
    public partial class Alter_Page_Menu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Pages_PageId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_PageId",
                table: "Menus");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "Pages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_MenuId",
                table: "Pages",
                column: "MenuId",
                unique: true,
                filter: "[MenuId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Menus_MenuId",
                table: "Pages",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Menus_MenuId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_MenuId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Pages");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_PageId",
                table: "Menus",
                column: "PageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Pages_PageId",
                table: "Menus",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
