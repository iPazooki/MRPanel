using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MRPanel.Migrations
{
    public partial class Add_Update_Classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Widget_Pages_PageId",
                table: "Widget");

            migrationBuilder.DropForeignKey(
                name: "FK_Widget_Widget_ParentId",
                table: "Widget");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Widget",
                table: "Widget");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Widget");

            migrationBuilder.RenameTable(
                name: "Widget",
                newName: "Widgets");

            migrationBuilder.RenameIndex(
                name: "IX_Widget_ParentId",
                table: "Widgets",
                newName: "IX_Widgets_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Widget_PageId",
                table: "Widgets",
                newName: "IX_Widgets_PageId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PageId",
                table: "Widgets",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Widgets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SizeType",
                table: "Widgets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Widgets",
                table: "Widgets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_Pages_PageId",
                table: "Widgets",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Widgets_Widgets_ParentId",
                table: "Widgets",
                column: "ParentId",
                principalTable: "Widgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Widgets_Pages_PageId",
                table: "Widgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Widgets_Widgets_ParentId",
                table: "Widgets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Widgets",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Widgets");

            migrationBuilder.DropColumn(
                name: "SizeType",
                table: "Widgets");

            migrationBuilder.RenameTable(
                name: "Widgets",
                newName: "Widget");

            migrationBuilder.RenameIndex(
                name: "IX_Widgets_ParentId",
                table: "Widget",
                newName: "IX_Widget_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Widgets_PageId",
                table: "Widget",
                newName: "IX_Widget_PageId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PageId",
                table: "Widget",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Widget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Widget",
                table: "Widget",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Widget_Pages_PageId",
                table: "Widget",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Widget_Widget_ParentId",
                table: "Widget",
                column: "ParentId",
                principalTable: "Widget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
