using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.DataAccessor.Migrations
{
    public partial class update_Usertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_UserId",
                table: "News");

            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: new Guid("8fb7d205-18b5-4acf-aebe-a6f8d3b71183"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "News");

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "CreatedDate", "Desc", "Name", "Published", "UpdatedDate" },
                values: new object[] { new Guid("4cd51d5c-e49e-41a7-b3fa-abcaeaa33a51"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "day la test, can thi bo sung trong code", "test", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Type",
                keyColumn: "Id",
                keyValue: new Guid("4cd51d5c-e49e-41a7-b3fa-abcaeaa33a51"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "News",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Type",
                columns: new[] { "Id", "CreatedDate", "Desc", "Name", "Published", "UpdatedDate" },
                values: new object[] { new Guid("8fb7d205-18b5-4acf-aebe-a6f8d3b71183"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "day la test, can thi bo sung trong code", "test", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_UserId",
                table: "News",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
