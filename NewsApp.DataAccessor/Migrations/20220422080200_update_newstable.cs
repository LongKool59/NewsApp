using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsApp.DataAccessor.Migrations
{
    public partial class update_newstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Type");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "News",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AuthorName",
                table: "News");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "News",
                newName: "CreatorId");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Type",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Pictures",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
