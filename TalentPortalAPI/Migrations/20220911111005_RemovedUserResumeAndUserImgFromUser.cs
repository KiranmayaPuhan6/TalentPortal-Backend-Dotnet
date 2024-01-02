using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentPortalAPI.Migrations
{
    public partial class RemovedUserResumeAndUserImgFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImg",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserResume",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "UserImg",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "UserResume",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
