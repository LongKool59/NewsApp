using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.DataAccessor.Migrations
{
    public partial class update_Pictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_News_NewsId",
                table: "Pictures");

            migrationBuilder.AlterColumn<Guid>(
                name: "NewsId",
                table: "Pictures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_News_NewsId",
                table: "Pictures",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_News_NewsId",
                table: "Pictures");

            migrationBuilder.AlterColumn<Guid>(
                name: "NewsId",
                table: "Pictures",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_News_NewsId",
                table: "Pictures",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id");
        }
    }
}
